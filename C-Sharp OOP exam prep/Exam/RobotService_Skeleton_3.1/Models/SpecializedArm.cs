using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int InterfaceStandardDefault = 10045;
        private const int BatteryUsageDefault = 10000;
        public SpecializedArm() : base(InterfaceStandardDefault, BatteryUsageDefault)
        {

        }
    }
}
