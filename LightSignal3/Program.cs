using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSignal3
{
    enum EColor
    {
        Green, Yellow, Red
    }
    interface IApp
    {
        void Run();
    }
    interface ITrafficControl
    {
        void SwitchState();
        EColor GetCurrentColor();
    }
    interface IOutput
    {
        void ShowCurrentColor(EColor color);
    }
    interface IInput
    {
        bool NeedToExit();
    }
    class App : IApp
    {
        private readonly ITrafficControl _trafficControl;
        private readonly IOutput _output;
        private readonly IInput _input;
        public App(ITrafficControl trafficControl, IOutput output, IInput input)
        {
            _trafficControl = trafficControl;
            _output = output;
            _input = input;
        }
        public void Run()
        {
            while(true)
            {
                _output.ShowCurrentColor(_trafficControl.GetCurrentColor());
                if (_input.NeedToExit()) return;
                _trafficControl.SwitchState();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
