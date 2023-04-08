using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int InterfaceStandardDefault = 20082;
        private const int BatteryUsageDefault = 5000;
        public LaserRadar() : base(InterfaceStandardDefault, BatteryUsageDefault)
        {

        }
    }
}
