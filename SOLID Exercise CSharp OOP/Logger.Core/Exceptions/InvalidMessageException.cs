using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Exceptions
{
    public class InvalidMessageException : Exception
    {
        private const string DefaultMessage
            = "Message cannot be null, empty or whitespace!";
        public InvalidMessageException() : base(DefaultMessage)
        {

        }

        public InvalidMessageException(string message) : base(message)
        {

        }
    }
}
