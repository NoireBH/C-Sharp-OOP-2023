using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models
{
    public class LogFile : ILogFile
    {
        private readonly StringBuilder log = new StringBuilder();
        public LogFile()
        {
            log = new StringBuilder();
        }

        public int Size => log.ToString()
            .Where(char.IsLetter)
            .Sum(x => x);

        public void Write(string message)
        {
            log.Append(message);
        }
    }
}
