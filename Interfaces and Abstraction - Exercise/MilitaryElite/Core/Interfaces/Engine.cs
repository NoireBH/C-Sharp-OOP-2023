using MilitaryElite.Enums;
using MilitaryElite.Interfaces;
using MilitaryElite.IO.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MilitaryElite.Core.Interfaces
{

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICollection<ISoldier> soldiers;

        private Engine()
        {
            soldiers = new HashSet<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;

        }

        public void Run()
        {
            CreateSoldier();
            PrintSoldiers();
        }

        private string CreateSoldier()
        {
            string input;
            while ((input = reader.ReadLine()) != "End")
            {
                string[] inputInfo = input.Split();
                string soldierType = inputInfo[0];
                int id = int.Parse(inputInfo[1]);
                string firstName = inputInfo[2];
                string lastName = inputInfo[3];

                ISoldier soldier = null;

                if (soldierType == "Private")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }

                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    ICollection<IPrivate> privates = FindPrivates(inputInfo);
                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }

                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpsInfo = inputInfo[5];
                    bool isValidCorps = Enum.TryParse<Corps>(corpsInfo, true, out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IRepair> repairs = AddRepairs(inputInfo);
                        soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    }

                }

                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(inputInfo[4]);
                    string corpsInfo = inputInfo[5];
                    bool isValidCorps = Enum.TryParse<Corps>(corpsInfo, false, out Corps corps);

                    if (isValidCorps)
                    {
                        ICollection<IMission> missions = AddMissions(inputInfo);
                        soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                    }
                }

                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(inputInfo[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }

                else
                {
                    continue;
                }

                soldiers.Add(soldier);

            }

            return input;
        }




        private ICollection<IPrivate> FindPrivates(string[] inputInfo)
        {
            int[] privateIds = inputInfo.Skip(5)
                .Select(int.Parse)
                .ToArray();

            var privates = new HashSet<IPrivate>();

            foreach (int privateId in privateIds)
            {
                IPrivate currPrivate = (IPrivate)soldiers
                    .FirstOrDefault(s => s.Id == privateId);

                privates.Add(currPrivate);
            }

            return privates;
        }

        private ICollection<IRepair> AddRepairs(string[] inputInfo)
        {
            string[] repairsToAdd = inputInfo.Skip(6).ToArray();

            var repairs = new HashSet<IRepair>();

            for (int i = 0; i < repairsToAdd.Length; i += 2)
            {
                string repairName = repairsToAdd[i];
                int hoursToRepair = int.Parse(repairsToAdd[i + 1]);

                IRepair repair = new Repair(repairName, hoursToRepair);
                repairs.Add(repair);
            }

            return repairs;
        }

        private ICollection<IMission> AddMissions(string[] inputInfo)
        {
            string[] missionsToAdd = inputInfo.Skip(6).ToArray();

            var missions = new HashSet<IMission>();

            for (int i = 0; i < missionsToAdd.Length; i += 2)
            {
                string missionName = missionsToAdd[i];
                string missionState = missionsToAdd[i + 1];
                bool IsStateValid = Enum.TryParse<State>(missionName, false, out State state);

                if (missionState == "inProgress" || missionState == "Finished")
                {
                    IMission mission = new Mission(missionName, state);
                    missions.Add(mission);
                }

                
            }

            return missions;
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }
    }
}
