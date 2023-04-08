using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> robots;

        public RobotRepository()
        {
            robots = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            robots.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robots.FirstOrDefault(x => x.InterfaceStandards.Any(x => x == interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return robots.AsReadOnly();
        }

        public bool RemoveByName(string robotModel)
        {
            var robotToRemove = robots.FirstOrDefault(x => x.Model == robotModel);

            if (robotToRemove == default)
            {
                return false;
            }

            robots.Remove(robotToRemove);

            return true;
        }
    }
}
