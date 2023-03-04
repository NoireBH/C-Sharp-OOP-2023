using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models
{
    public class SimpleLayout : ILayout
    {
        private  const string SimpleLayoutFormat = "{0} - {1} - {2}";

        public SimpleLayout(string format = SimpleLayoutFormat)
        {
            Format = format;
        }

        public string Format {get; private set;}
    }
}
