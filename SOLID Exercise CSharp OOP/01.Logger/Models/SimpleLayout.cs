using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models
{
    public class SimpleLayout : ISimpleLayout
    {   


        public DateTime DateTime {get; private set;}

        public Enum ReportLevel { get; private set; }

        public string Message { get; private set; }
    }
}
