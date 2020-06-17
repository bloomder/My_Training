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
        }
    }

    class App : IApp
    {
        private readonly ITrafficLight _trafficLight;
        public App(ITrafficLight trafficLight)
        {
            _trafficLight = trafficLight;
        }
        public void Run()
        {

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
