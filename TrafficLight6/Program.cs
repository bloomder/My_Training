using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight6
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    
    enum Ecolor
    {
        Red, Yellow, Green
    }
    interface ITrafficLight
    {
        void SwitchState();
        Ecolor GetCurrentColor();
    }
    interface IInput
    {
        bool NeedToExit();
    }
    interface IOutput
    {
        void ShowCurrentColor(Ecolor color);
    }
    interface IApp
    {
        void Run();
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
                
            }
        }
    }

    class TrafficLight : ITrafficLight
    {
        Ecolor _ecolor = Ecolor.Yellow;
        bool _downState = true;
        public Ecolor GetCurrentColor()
        {
            return _ecolor;
        }

        public void SwitchState()
        {
            switch (_ecolor)
            {
                case Ecolor.Red:
                    _ecolor = Ecolor.Yellow;
                    break;
                case Ecolor.Yellow:
                    _ecolor = _downState ? Ecolor.Green : Ecolor.Red;
                    _downState = !_downState;
                    break;
                case Ecolor.Green:
                    _ecolor = Ecolor.Yellow;
                    break;
            }
        }
    }

}
