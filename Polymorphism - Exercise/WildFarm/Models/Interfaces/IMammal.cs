﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Interfaces
{
    public interface IMammal : IAnimal
    {
        public string LivingRegion { get; }
    }
}
