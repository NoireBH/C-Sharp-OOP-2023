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
            if (typeName != nameof(DomesticAssistant) || typeName != nameof(IndustrialAssistant))
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

            return $"{robot.GetType().Name} is not compatible with our robots.";
        }

        public string CreateSupplement(string typeName)
        {
            if (typeName != nameof(LaserRadar) || typeName != nameof(SpecializedArm))
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
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

            return $"{supplement.GetType().Name} is not compatible with our robots.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }

        public string RobotRecovery(string model, int minutes)
        {
            throw new NotImplementedException();
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            throw new NotImplementedException();
        }
    }
}
