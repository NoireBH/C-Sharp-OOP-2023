using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;
        private int batteryLevel;
        private List<int> interfaceStandards;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandards = new List<int>();
        }

        public string Model
        {
            get { return model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }

                model = value; 
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
           private set
            {
                if (value < 0) // may be wrong
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel {get; private set;} // may be wrong

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;

        public void Eating(int minutes)
        {
            var producedEnergy = ConvertionCapacityIndex * minutes;

            if (producedEnergy + BatteryLevel > BatteryCapacity)
            {
                BatteryLevel = BatteryCapacity;
            }
            else
            {
                BatteryLevel += producedEnergy;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;

                return true;
            }

            else
            {
                return false;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandards.Add(supplement.InterfaceStandard);
            BatteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} {Model}:");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");

            if (InterfaceStandards.Count > 0)
            {
                sb.AppendLine($"--Supplements installed: {string.Join(" ", this.InterfaceStandards)}");
            }
            else
            {
                sb.AppendLine($"--Supplements installed: none");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
