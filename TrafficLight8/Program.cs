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
        void ShowCurrentColor(EColor color);
    }
    interface ITrafficLight
    {
        void SwitchState();
        EColor GetCurrentColor();
        ConsoleColor GetCurrentColor(EColor color);
    }

    class TrafficLight : ITrafficLight
    {
        EColor _ecolor = EColor.Yellow;
        bool _downColor = true;
        public EColor GetCurrentColor()
        {
            return _ecolor;
        }

        public ConsoleColor GetCurrentColor(EColor color)
        {
            ConsoleColor _consoleColor;
            
            
            
        }

        public void SwitchState()
        {
            switch (_ecolor)
            {
                case EColor.Red:
                    _ecolor = EColor.Yellow;
                    break;
                case EColor.Yellow:
                    _ecolor = _downColor ? EColor.Red : EColor.Green;
                    _downColor = !_downColor;
                    break;
                case EColor.Green:
                    _ecolor = EColor.Yellow;
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
        public void ShowCurrentColor(EColor color)
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
            while(true)
            {
                _output.ShowCurrentColor(_trafficLight.GetCurrentColor());
                if (_input.NeedToExit()) return;
                _trafficLight.SwitchState();
            }
        }
    }
}