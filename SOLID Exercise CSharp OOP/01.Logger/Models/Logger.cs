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
            Log(ReportLevel.Critical, message);
        }


        public void Error(string message)
        {
            Log(ReportLevel.Error, message);
        }

        public void Fatal(string message)
        {
            Log(ReportLevel.Fatal, message);
        }

        public void Info(string message)
        {
            Log(ReportLevel.Info, message);
        }

        public void Warning(string message)
        {
            Log(ReportLevel.Warning, message);
        }

        private void Log(ReportLevel level, string message)
        {
            foreach (var appender in Appenders)
            {
                if (level >= appender.ReportLevel)
                {
                    appender.Append(DateTime.Now, level, message);
                }
            }
        }
    }
}
