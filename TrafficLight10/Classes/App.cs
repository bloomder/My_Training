using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes
{
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
            while(true)
            {
                if (_input.NeedToExit()) return;
                _trafficLight.SwitchState();
            }
        }
    }
}
