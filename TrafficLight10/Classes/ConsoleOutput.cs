using System;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes
{
    class ConsoleOutput : IOutput
    {
        public void ShowInformation(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("O");
        }
    }
}
