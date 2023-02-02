using MilitaryElite.Core.Interfaces;
using MilitaryElite.Interfaces;
using MilitaryElite.IO;
using MilitaryElite.IO.Interfaces;
using MilitaryElite.Models;
using System;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
