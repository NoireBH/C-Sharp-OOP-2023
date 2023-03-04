using _01.Logger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Logger.Models.Layouts
{
    internal class XmlLayout : ILayout
    {
        private const string xmlLayout =
@"<log>
   <date>{0}</date>
   <level>{1}</level>
<message>{2}</message>
</log>";

        public XmlLayout(string format = xmlLayout)
        {
            Format = format;
        }

        public string Format { get; private set; }
    }
}
