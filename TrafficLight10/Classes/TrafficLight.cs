using System;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes
{
    class TrafficLight : ITrafficLight
    {
        private readonly IOutput _output;
        private readonly ITextOutput _textOutput;
        private ConsoleColor _consoleColor = ConsoleColor.Yellow;
        private bool _downState = true;
        public TrafficLight(IOutput output)
        {
            _output = output;
            SwitchState();
        }
        public void SwitchState()
        {
            switch(_consoleColor)
            {
                case ConsoleColor.Red:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Yellow;
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowInformation(_consoleColor);
                    if (_downState) _consoleColor = ConsoleColor.Green;
                    else _consoleColor = ConsoleColor.Red;
                    _downState = !_downState;
                    break;
                case ConsoleColor.Green:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Yellow;
                    break;
            }
        }
    }
}
