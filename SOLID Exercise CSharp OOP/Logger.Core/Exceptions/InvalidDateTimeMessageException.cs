using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Exceptions
{
    public class InvalidDateTimeMessageException : Exception
    {
        private const string DefaultMessage
            = "DateTime cannot be null, empty or whitespace!";
        public InvalidDateTimeMessageException() : base(DefaultMessage)
        {

        }

        public InvalidDateTimeMessageException(string message) : base(message)
        {

        }
    }
}
