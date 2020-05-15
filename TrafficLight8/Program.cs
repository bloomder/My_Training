using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight8
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new TrafficLight(), new ConsoleInput(), new ConsoleOutput());
            _app.Run();
        }
    }
    enum EColor
    {
        Red, Yellow, Green, Blue
    }
    interface IApp
    {
        void Run();
    }
    interface IInput
    {
        bool NeedToExit();
    }
    interface IOutput
    {
        void ShowCurrentColor(ConsoleColor color);
    }
    interface ITrafficLight
    {
        void SwitchState();
        ConsoleColor GetCurrentColor();
    }

    class TrafficLight : ITrafficLight
    {
        ConsoleColor _ecolor = ConsoleColor.Yellow;
        bool _downColor = true;
        public ConsoleColor GetCurrentColor()
        {
            return _ecolor;
        }
        public void SwitchState()
        {
            switch (_ecolor)
            {
                case ConsoleColor.Red:
                    _ecolor = ConsoleColor.Yellow;
                    break;
                case ConsoleColor.Yellow:
                    _ecolor = _downColor ? ConsoleColor.Red : ConsoleColor.Green;
                    _downColor = !_downColor;
                    break;
                case ConsoleColor.Green:
                    _ecolor = ConsoleColor.Yellow;
                    break;
            }
        }
    }
    class ConsoleInput : IInput
    {
        public bool NeedToExit()
        {
            return Console.ReadLine() == "q";
        }
    }
    class ConsoleOutput : IOutput
    {
        public void ShowCurrentColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine("O");
        }
    }
    class App : IApp
    {
        private readonly ITrafficLight _trafficLight;
        private readonly IInput _input;
        private readonly IOutput _output;
        public App(ITrafficLight trafficLight, IInput input, IOutput output)
        {
            _trafficLight = trafficLight;
            _input = input;
            _output = output;
        }
        public void Run()
        {
            if (MethodPartLogic()) return;
            while (true)
            {
                if (MethodPartLogic()) return;
                _output.ShowCurrentColor(_trafficLight.GetCurrentColor());
                _trafficLight.SwitchState();
            }
        }
        private bool MethodPartLogic()
        {
            _output.ShowCurrentColor(_trafficLight.GetCurrentColor());
            if (_input.NeedToExit()) return true;
            _trafficLight.SwitchState();
            return false;
        }
    }
}