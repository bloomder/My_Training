using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight11
{
    class Program
    {
        static void Main(string[] args)
        {
            //IApp _app = new App(new TrumTrafficLight(new TrumConsoleOutput(), new TrumTextClass()), new TrumConsoleInput());
            //_app.Run();
        }
    }

    class App : IApp
    {
        private readonly ITrafficLight _trafficLight;
        private readonly IInput _input;
        public App(ITrafficLight trafficLight, IInput input)
        {
            _trafficLight = trafficLight;
            _input = input;
        }
        public void Run()
        {
            while (true)
            {
                if (_input.NeedToExit()) return;
                _trafficLight.SwitchState();
            }
        }
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
        void ShowInformation();
    }
    interface ITrafficLight
    {
        void SwitchState();
    }

}
