using FakeAxeAndDummy.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Models
{
    public class Target : Itarget
    {
        public int Hp { get; private set; }
    }
}
