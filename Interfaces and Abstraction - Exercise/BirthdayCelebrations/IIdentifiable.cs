using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IIdentifiable
    {
        public string Name { get;}
        public string ID { get; }

        public void CheckID(string fakeID);
    }
}
