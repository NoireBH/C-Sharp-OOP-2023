using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IIdentifiable
    {
        public string Name { get;}
        public string ID { get; }

        public void CheckID(string fakeID);
    }
}
