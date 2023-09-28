using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Loggers
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string value)
        {
            Console.WriteLine(value);
        }
    }
}
