using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()
        {
            pilotRepository = new PilotRepository();
            raceRepository = new RaceRepository();
            carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var car = carRepository.Models.FirstOrDefault(c => c.Model == carModel);
            var pilot = pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotName);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }

            else if (car == null)
            {
                throw new NullReferenceException
                    (string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }

            else
            {
                pilot.AddCar(car);
                return String.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);
            }
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);
            var pilot = pilotRepository.Models.FirstOrDefault(p => p.FullName == pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException
                    (string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            else if (pilot == null || !pilot.CanRace || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException
                    (string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }

            else
            {   
                race.Pilots.Add(pilot);
                return String.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
            }
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            else if (type != "Ferrari" && type != "Williams")
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }

            else
            {
                IFormulaOneCar car;

                if (type == "Ferrari")
                {
                    carRepository.Add(car = new Ferrari(model, horsepower, engineDisplacement));
                }

                else
                {
                    carRepository.Add(car = new Williams(model, horsepower, engineDisplacement));
                }

                return string.Format(OutputMessages.SuccessfullyCreateCar, type,model);
            }
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }

            else
            {
                IPilot pilot = new Pilot(fullName);
                pilotRepository.Add(pilot);
                return (string.Format(OutputMessages.SuccessfullyCreatePilot, fullName));
            }
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (raceRepository.Models.Any(r => r.RaceName == raceName))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }

            IRace race = new Race(raceName, numberOfLaps);
            raceRepository.Add(race);
            return (string.Format(OutputMessages.SuccessfullyCreateRace, raceName));
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IPilot> pilots = pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();

            foreach (var pilot in pilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            List<IRace> finishedRaces = raceRepository.Models.Where(r => r.TookPlace).ToList();

            foreach (var race in finishedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.Models.FirstOrDefault(r => r.RaceName == raceName);

            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }

            else if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }

            else if (race.TookPlace)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }

            else
            {
                race.TookPlace = true;

                List<IPilot> pilots = race.Pilots
                    .OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps))
                    .ToList();

                pilots[0].WinRace();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Pilot {pilots[0].FullName} wins the {raceName} race.");
                sb.AppendLine($"Pilot {pilots[1].FullName} is second in the {raceName} race.");
                sb.AppendLine($"Pilot {pilots[2].FullName} is third in the {raceName} race.");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
