using Logger.Core.Enums;
using Logger.Core.Exceptions;
using Logger.Core.Models.Interfaces;
using Logger.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Models
{
    public class Message : IMessage
    {
        private string? messageText;
        private string? dateTime;
        public Message(string messageText, string dateTime, ReportLevel reportLevel)
        {
            MessageText = messageText;
            DateTime = dateTime;
            ReportLevel = reportLevel;
        }


        public string MessageText
        {
            get { return MessageText; }

            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidMessageException();
                }

                messageText = value;
            }
        }


        public string DateTime 
        {
            get
            {
                return dateTime!;
            }
           private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidDateTimeMessageException();
                }

                if (!DateTimeValidator.isDateTimeValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }

                dateTime = value;
            } 
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
