using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models.Interfaces
{
    public interface ISimpleLayout
    {
        public DateTime DateTime { get; }
        public Enum ReportLevel { get; }
        public string Message { get; }
    }
}
