using _01.Logger.Enums;
using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Appenders.Models.Interfaces
{
    public interface IAppender
    {   
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; }
        void Append(DateTime datetime, ReportLevel ReportLevel, string message); 
    }
}
