using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage
            = "DateTime format is invalid!";
        public InvalidDateTimeFormatException() : base(DefaultMessage)
        {

        }

        public InvalidDateTimeFormatException(string message) : base(message)
        {

        }
    }
}
