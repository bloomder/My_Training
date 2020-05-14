using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrafficLight7
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
        Green, Yellow, Red, White, Blue
    }
    interface IApp
    {
        void Run();
    }
    interface ITrafficLight
    {
        void SWitchState();
        EColor GetCurrentColor();
    }
    interface IInput
    {
        bool NeedToExit();
    }
    interface IOutput
    {
        void ShowCurrentColor(EColor color);
    }


    class TrafficLight : ITrafficLight
    {
        EColor _ecolor = EColor.Yellow;
        bool _downColor = true;
        public EColor GetCurrentColor()
        {
            return _ecolor;
        }

        public void SWitchState()
        {
            switch (_ecolor)
            {
                case EColor.Green:
                    _ecolor = EColor.Red;
                    break;
                case EColor.Yellow:
                    _ecolor = _downColor ? EColor.Red : EColor.Green;
                    _downColor = !_downColor;
                    break;
                case EColor.Red:
                    _ecolor = EColor.Green;
                    break;
            }
        }
    }

    class RailRoadTrafficLight : ITrafficLight
    {
        EColor _ecolor = EColor.White;
        public EColor GetCurrentColor()
        {
            return _ecolor;
        }

        public void SWitchState()
        {
            _ecolor = _ecolor == EColor.White ? EColor.Blue : EColor.White;
        }
    }

    class PeopleRoadTrafficLight : ITrafficLight
    {
        EColor _ecolor = EColor.Red;

        public EColor GetCurrentColor()
        {
            return _ecolor;
        }

        public void SWitchState()
        {
            _ecolor = _ecolor == EColor.Red ? EColor.Green : EColor.Red;
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
            if (color != EColor.Yellow)
            {
                Console.WriteLine(EColor.Yellow);
                Thread.Sleep(1000);
            }
            Console.WriteLine(color);
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
            while (true)
            {
                _output.ShowCurrentColor(_trafficLight.GetCurrentColor());
                if (_input.NeedToExit()) return;
                _trafficLight.SWitchState();
            }
        }
    }
}