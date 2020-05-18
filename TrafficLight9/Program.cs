﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight9;

namespace TrafficLight9
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new TrafficLightV1(new ConsoleOutput()), new ConsoleInput());
            _app.Run();
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
        void ShowCurrentColor(ConsoleColor color);
    }
    interface ITrafficLight
    {
        void SwitchState();
    }
    class TrafficLight : ITrafficLight
    {
        protected ConsoleColor _color;
        protected bool _downColor;
        protected readonly IOutput _output;
        public TrafficLight(IOutput output)
        {
            _output = output;
            _color = ConsoleColor.Yellow;
            _downColor = true;
            _output.ShowCurrentColor(_color);
        }

        public virtual void SwitchState()
        {
            switch(_color)
            {
                case ConsoleColor.Green:
                    _color = ConsoleColor.Yellow;
                    _output.ShowCurrentColor(_color);
                    break;
                case ConsoleColor.Yellow:
                    _color = _downColor ? ConsoleColor.Green : ConsoleColor.Red;
                    _downColor = !_downColor;
                    _output.ShowCurrentColor(_color);
                    break;
                case ConsoleColor.Red:
                    _color = ConsoleColor.Yellow;
                    _output.ShowCurrentColor(_color);
                    break;
            }
        }
    }
    class TrafficLightV1 : TrafficLight
    {
        public TrafficLightV1(IOutput output) : base(output)
        {
        }
        public override void SwitchState()
        {
            switch (_color)
            {
                case ConsoleColor.Green:
                    _color = ConsoleColor.Yellow;
                    _output.ShowCurrentColor(_color);
                    goto case ConsoleColor.Yellow;
                case ConsoleColor.Yellow:
                    _color = _downColor ? ConsoleColor.Green : ConsoleColor.Red;
                    _downColor = !_downColor;
                    _output.ShowCurrentColor(_color);
                    break;
                case ConsoleColor.Red:
                    _color = ConsoleColor.Yellow;
                    _output.ShowCurrentColor(_color);
                    goto case ConsoleColor.Yellow;
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
 