using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int BatteryCapacityDefault = 20000;
        private const int ConvertionCapacityIndexDefault = 20000;
        public DomesticAssistant(string model) : base(model, BatteryCapacityDefault, ConvertionCapacityIndexDefault)
        {

        }
    }
}
