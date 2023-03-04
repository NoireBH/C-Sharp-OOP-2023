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
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get;}

        public void Append(DateTime datetime, ReportLevel ReportLevel, string message)
        {
            string output = string.Format(Layout.Format, datetime, ReportLevel, message);
            Console.WriteLine(output);
        }

    }
}
