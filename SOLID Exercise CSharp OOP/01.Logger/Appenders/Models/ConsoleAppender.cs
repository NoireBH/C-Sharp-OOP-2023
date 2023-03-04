using _01.Logger.Appenders.Models.Interfaces;
using _01.Logger.Enums;
using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Appenders.Models
{
    public class ConsoleAppender : IAppender
    {
        private readonly ILogFile logFile;
        public ConsoleAppender(ILayout layout, ILogFile logFile)
        {
            Layout = layout;
            this.logFile = logFile;
        }

        public ILayout Layout { get;}

        public ReportLevel ReportLevel { get; set; }

        public void Append(DateTime datetime, ReportLevel ReportLevel, string message)
        {
            string output = string.Format(Layout.Format, datetime, ReportLevel, message);
            logFile.Write(output);
            Console.WriteLine(output);
        }

    }
}
