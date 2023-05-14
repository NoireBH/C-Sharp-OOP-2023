using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (typeName != nameof(DomesticAssistant) && typeName != nameof(IndustrialAssistant))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            IRobot robot;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }

            else
            {
                robot = new IndustrialAssistant(model);
            }

            robots.AddNew(robot);

            return String.Format(OutputMessages.RobotCreatedSuccessfully, robot.GetType().Name, model);
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) && typeName != nameof(SpecializedArm))
            {
                return String.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            ISupplement supplement;

            if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }

            else
            {
                supplement = new SpecializedArm();
            }

            supplements.AddNew(supplement);

            return String.Format(OutputMessages.SupplementCreatedSuccessfully, supplement.GetType().Name);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotsSupportingTheInterface = 
                robots.Models()
                .Where(x => x.InterfaceStandards
                .Any(x => x == intefaceStandard)).ToList();

            if (robotsSupportingTheInterface.Count <= 0)
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            var orderedRobots = robotsSupportingTheInterface.OrderByDescending(x => x.BatteryLevel);
            int batteryLevelSum = orderedRobots.Sum(x => x.BatteryLevel);

            if (batteryLevelSum < totalPowerNeeded)
            {
                int powerNeeded = totalPowerNeeded - batteryLevelSum;
                return String.Format(OutputMessages.MorePowerNeeded, serviceName,powerNeeded);
            }

            int robotCounter = 0;

            foreach (var robot in orderedRobots)
            {
                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotCounter++;
                    break;
                }

                else
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    robotCounter++;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCounter);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var robot in robots
                .Models()
                .OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity))
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {   
            
            var robotsToFeed = robots.Models()
                .Where(x => x.Model == model && x.BatteryLevel < x.BatteryCapacity / 2)
                .ToList();

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

            if (robotsToUpgrade.Count <= 0)
            {
                return String.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotsToUpgrade.First().InstallSupplement(supplement);
            supplements.RemoveByName(supplement.GetType().Name);

            return String.Format(OutputMessages.UpgradeSuccessful, model, supplement.GetType().Name);
        }
    }
}
