using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }
        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidOperationException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        => phoneNumber.All(ch => char.IsDigit(ch));

        
    }
}
