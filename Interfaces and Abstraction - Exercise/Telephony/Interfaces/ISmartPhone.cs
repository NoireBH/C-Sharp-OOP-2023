using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Interfaces
{
    public interface ISmartPhone : IStationaryPhone
    {
        string BrowseSite(string url);
    }
}
