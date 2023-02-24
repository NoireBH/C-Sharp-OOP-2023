using ProductTrackingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTrackingSystem.Models
{
    public class Product : IProduct
    {
        public string Label { get; private set; }

        public int Price {get; private set; }
    }
}
