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
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public ReportLevel ReportLevel { get; }

        public void Critical(string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(DateTime.Now, ReportLevel.Critical, message);
            }
        }


        public void Error(string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(DateTime.Now, ReportLevel.Error, message);
            }
        }

        public void Fatal(string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(DateTime.Now, ReportLevel.Fatal, message);
            }
        }

        public void Info(string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(DateTime.Now, ReportLevel.Info, message);
            }
        }

        public void Warning(string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(DateTime.Now, ReportLevel.Warning, message);
            }
        }

    }
}
