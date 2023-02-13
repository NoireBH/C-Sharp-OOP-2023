using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Car
    {
        public Car(string manifacturer, string model, int year)
        {
            Manifacturer = manifacturer;
            Model = model;
            Year = year;
        }

        public string Manifacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Manifacturer} {Model} ({Year})".Trim();
        }
    }
}
