using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;
using TrafficLight10.Interfaces.ITrum;

namespace TrafficLight10.Classes.Trum
{
    class TrumConsoleOutput : ITrumOutput
    {
        public void ClearConsole()
        {
            Console.Clear();
        }

        public void ShowInfo(string text)
        {
            Console.WriteLine(text);
        }
    }
}
