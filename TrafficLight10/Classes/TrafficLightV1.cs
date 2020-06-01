using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes
{
    class TrafficLightV1 : ITrafficLight
    {
        private readonly IOutput _output;
        private ConsoleColor _consoleColor = ConsoleColor.Yellow;
        private bool _downState = true;
        public TrafficLightV1(IOutput output)
        {
            _output = output;
            SwitchState();
        }
        public void SwitchState()
        {
            switch(_consoleColor)
            {
                case ConsoleColor.Red:
                    _output.ShowInformation(ConsoleColor.Yellow);
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Green;
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowInformation(_consoleColor);
                    if (_downState) _consoleColor = ConsoleColor.Green;
                    else _consoleColor = ConsoleColor.Red;
                    _downState = !_downState;
                    break;
                case ConsoleColor.Green:
                    _output.ShowInformation(ConsoleColor.Yellow);
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Red;
                    break;
            }
        }
    }
}
