using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telephony.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : IStationaryPhone, ISmartPhone
    {

        public Smartphone()
        {

        }
        public string BrowseSite(string url)
        {
            if (!ValidateURL(url))
            {
                throw new InvalidOperationException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidOperationException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        => phoneNumber.All(ch => char.IsDigit(ch));
        private bool ValidateURL(string url)
            => url.All(ch => !char.IsDigit(ch));
    }
}
