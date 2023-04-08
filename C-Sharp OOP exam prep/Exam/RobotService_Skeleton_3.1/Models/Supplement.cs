﻿using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Supplement : ISupplement
    {
        private int interfaceStandard;
        private int battaryUsage;
        protected Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        public int InterfaceStandard {get; private set;}

        public int BatteryUsage { get; private set; }
    }
}
