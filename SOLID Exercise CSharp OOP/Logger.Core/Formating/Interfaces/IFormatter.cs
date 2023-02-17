using Logger.Core.Formating.Layouts.Interfaces;
using Logger.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Formating.Interfaces
{
    public interface IFormatter
    {
        string Format(IMessage message, ILayout layout);
    }
}
