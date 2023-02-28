using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Exceptions
{
    public class DeadDummyException : Exception
    {
        public const string DeadDummy = "Dummy has been destroyed";

        public DeadDummyException() : base(DeadDummy)
        {

        }

        public DeadDummyException(string message) : base(message)   
        {

        }
    }
}
