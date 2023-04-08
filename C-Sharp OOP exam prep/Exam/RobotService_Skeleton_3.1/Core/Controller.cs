using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private SupplementRepository supplements;
        private RobotRepository robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;

            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return String.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
                robots.AddNew(robot);
            }

            else
            {
                robot = new IndustrialAssistant(model);
                robots.AddNew(robot);
            }

            return String.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;

            if (typeName != nameof(SpecializedArm) && typeName != nameof(LaserRadar))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
                supplements.AddNew(supplement);
            }

            else
            {
                supplement = new LaserRadar();
                supplements.AddNew(supplement);
            }

            return String.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsSupportingTheInterface = robots.Models().Where(x => x.InterfaceStandards.Any(x => x == intefaceStandard)).ToList();

            if (robotsSupportingTheInterface.Count == 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            List<IRobot> orderedRobots = robotsSupportingTheInterface.OrderByDescending(x => x.BatteryLevel).ToList();
           var sumOfRobots = orderedRobots.Sum(x => x.BatteryLevel);

            int power = Math.Abs(totalPowerNeeded - sumOfRobots);

            if (sumOfRobots >= totalPowerNeeded)
            {
                int counter = 0;

                foreach (var robot in orderedRobots)
                {
                    if (robot.BatteryLevel >= totalPowerNeeded)
                    {
                        robot.ExecuteService(totalPowerNeeded);
                        counter++;
                        break;
                    }

                    else
                    {   
                        totalPowerNeeded -= robot.BatteryLevel;
                        robot.ExecuteService(robot.BatteryLevel);
                        counter++;

                        
                    }
                }

                return string.Format(OutputMessages.PerformedSuccessfully, serviceName, counter);
            }

            else
            {
                return String.Format(OutputMessages.MorePowerNeeded, serviceName, power);
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var orderedRobots = robots.Models()
                .OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity);

            foreach (var robot in orderedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToFeed = robots.Models()
                .Where(x => x.Model == model && x.BatteryLevel < x.BatteryCapacity / 2).ToList();

            foreach (var robot in robotsToFeed)
            {
                robot.Eating(minutes);
            }

            return String.Format(OutputMessages.RobotsFed, robotsToFeed.Count);
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var supplement = supplements.Models()
                .FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            int supplementValue = supplements.Models()
                .FirstOrDefault(x => x.GetType().Name == supplementTypeName).InterfaceStandard;

            List<IRobot> robotsToGet = robots.Models().Where(x => !x.InterfaceStandards.Contains(supplementValue)).ToList();
            List<IRobot> robotsToUpgrade = robotsToGet.Where(x => x.Model == model).ToList();

            if (robotsToUpgrade.Count == 0)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotsToUpgrade.First().InstallSupplement(supplement);
            supplements.RemoveByName(supplement.GetType().Name);

            return String.Format(OutputMessages.UpgradeSuccessful, model, supplement.GetType().Name);
        }
    }
}
