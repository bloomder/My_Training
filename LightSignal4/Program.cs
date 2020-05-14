using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSignal4
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    enum EColor
    {
        Red, Yellow, Green
    }
    interface ITrafficLight
    {
        void SwitchState();
        EColor GetCurrentLight();
    }
    interface IInput
    {
        bool NeedToExit();
    }
    interface IOutput
    {
        void ShowCurentColor(EColor color);
    }
    public class TrafficLight
    {
        private readonly ITrafficLight _trafficLight;
        private readonly IInput _input;
        private readonly IOutput _output;
        public TrafficLight(ITrafficLight trafficLight, IInput input, IOutput output)
        {
            _trafficLight = trafficLight;
            _input = input;
            _output = output;
        }
    }

}
