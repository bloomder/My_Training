using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes
{
    class ConsoleInput : IInput
    {
        public bool NeedToExit()
        {
            return Console.ReadLine() == "q";
        }
    }
}
