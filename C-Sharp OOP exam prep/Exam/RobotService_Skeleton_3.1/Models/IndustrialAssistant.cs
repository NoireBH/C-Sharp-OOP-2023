using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int BatteryCapacityDefault = 40000;
        private const int ConvertionCapacityIndexDefault = 5000;
        public IndustrialAssistant(string model) : base(model, BatteryCapacityDefault, ConvertionCapacityIndexDefault)
        {

        }
    }
}
