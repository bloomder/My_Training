using System;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes.Trum
{
    class TrumConsoleInput : IInput
    {
        public bool NeedToExit()
        {
            string _stroka = Console.ReadLine();
            if (_stroka == "q") return true;
            else
            {
                Settings.Settings.stroka = _stroka;
                return false;
            }
        }
    }
}
