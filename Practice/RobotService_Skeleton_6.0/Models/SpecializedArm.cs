using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm : Supplement
    {
        private const int InterfaceStandardDefault = 10045;
        private const int BatteryUsageDefault = 10000;

        public SpecializedArm(int interfaceStandard, int batteryUsage) : base(InterfaceStandardDefault, BatteryUsageDefault)
        {

        }
    }
}
