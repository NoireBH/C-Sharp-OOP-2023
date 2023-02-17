using Logger.Core.Formating.Interfaces;
using Logger.Core.Formating.Layouts.Interfaces;
using Logger.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Formating
{
    internal class MessageFormatter : IFormatter
    {
        public string Format(IMessage message, ILayout layout)
        {
            return string.Format(layout.Format, message.DateTime, message.ReportLevel.ToString(), message.MessageText);
        }
    }
}
