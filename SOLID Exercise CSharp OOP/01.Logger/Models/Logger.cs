using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Enums;
using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models
{
    public class Logger : ILogger
    {
        public Logger(IAppender appender)
        {
            Appender = appender;
        }

        public IAppender Appender { get;}

        public ReportLevel ReportLevel { get; }

        public void Critical(string message)
        {
            Appender.Append(DateTime.Now, ReportLevel.Critical, message);
        }


        public void Error(string message)
        {
            Appender.Append(DateTime.Now, ReportLevel.Error, message);
        }

        public void Fatal(string message)
        {
            Appender.Append(DateTime.Now, ReportLevel.Fatal, message);
        }

        public void Info(string message)
        {
            Appender.Append(DateTime.Now, ReportLevel.Info, message);
        }

        public void Warning(string message)
        {
            Appender.Append(DateTime.Now, ReportLevel.Warning, message);
        }

    }
}
