using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models.Interfaces
{
    public interface ILogger
    {      
        public IAppender Appender { get; }
        public ReportLevel ReportLevel { get; }
        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);
        void Fatal(string message);
    }
}
