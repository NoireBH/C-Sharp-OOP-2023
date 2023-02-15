using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Utilities
{
    public class DateTimeValidator
    {
        private static ICollection<string> allowedDateTimeFormats = new HashSet<string>
        {
           "MM/dd/yyyy HH:mm:ss tt",
           "MM/dd/yyyy HH:mm:ss"
        };
        public static bool isDateTimeValid(string dateTime)
        {
            bool isValid = false;

            foreach (var currentFormat in allowedDateTimeFormats)
            {
                bool isCurrentFormat = DateTime.TryParseExact(dateTime,currentFormat,
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);

                if (isCurrentFormat)
                {
                    isValid = true;
                    break;
                }

            }

            return isValid;
        }

        public static void RegisterDateTimeFormat(string format) // add custom DateTimeFormats
        {
            allowedDateTimeFormats.Add(format);
        }
    }
}
