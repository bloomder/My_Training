using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    enum EColor
    {
        Red, Green, Yellow, Blue
    }

    class App : IApp
    {
        private readonly ITrafficLight _trafficLight;
        private readonly IOutput _output;
        private readonly IInput _input;

        public App(ITrafficLight trafficLight, IOutput output, IInput input)
        {
            _trafficLight = trafficLight;
            _output = output;
            _input = input;
        }
        public void Run()
        {
            while (true)
            {
                _output.ShowCurrentColor(_trafficLight.GetCurrentColor());
                if (_input.NeedToExit()) return;
                _trafficLight.SwitchLight();
            }

        }
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
        void SwitchLight();
        EColor GetCurrentColor();
    }

    interface IApp
    {
        void Run();
    }

    class ConsoleOutput : IOutput
    {
        public void ShowCurrentColor(EColor color)
        {
            Console.WriteLine(color);
        }
    }

    class MyRailroadLight : ITrafficLight
    {
        public void SwitchLight()
        {

        }

        public EColor GetCurrentColor()
        {
            return EColor.Blue;
        }
    }

    class MyTrafficLight : ITrafficLight
    {
        private EColor _currentColor = EColor.Red;
        public MyTrafficLight(EColor startColor)
        {
            _currentColor = startColor;
        }

        public void SwitchLight()
        {
            _currentColor = _currentColor == EColor.Red ? EColor.Green : EColor.Red;
        }

        public EColor GetCurrentColor()
        {
            return _currentColor;
        }
    }

    class ConsoleInput : IInput
    {
        public bool NeedToExit()
        {
            return Console.ReadLine() == "q";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            IApp app = new App(new MyRailroadLight(), new ConsoleOutput(), new ConsoleInput());

            app.Run();

        }
    }
}