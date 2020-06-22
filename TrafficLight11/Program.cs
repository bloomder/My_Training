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
            //IApp _app = new App(new TrafficLight(new ConsoleOutput()), new ConsoleInput());
            //IApp _app = new App(new TrafficLightV1(new ConsoleOutput()), new ConsoleInput());
            //IApp _app = new App(new TrumTrafficLight(new TrumConsoleOutput(new TrumTextClass())), new TrumConsoleInput(new TrumTextClass()));
            //IApp _app = new App1()
            //_app.Run();
        }
    }

    enum ETrumSignal
    {
        Left,
        Right,
        Up,
        Stop,
        LeftRight,
        LeftUp,
        UpRight,
        LeftUpRight,
        Off,
        Error
    }

    internal static class SettingsApp
    {
        internal static ETrumSignal eTrumSignal = ETrumSignal.Off;
    }

    class App1 : IApp
    {
        private readonly ITrafficLight1 _trafficLight;
        public App1(ITrafficLight1 trafficLight)
        {
            _trafficLight = trafficLight;
        }
        public void Run()
        {
            
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

    class TrafficLight : ITrafficLight
    {
        private bool _downState = true;
        private readonly IOutput _output;
        private ConsoleColor _consoleColor;
        public TrafficLight(IOutput output)
        {
            _output = output;
            _consoleColor = ConsoleColor.Yellow;
            SwitchState();
        }
        public void SwitchState()
        {
            switch (_consoleColor)
            {
                case ConsoleColor.Red:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Yellow;
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = _downState == true ? ConsoleColor.Green : ConsoleColor.Red;
                    _downState = !_downState;
                    break;
                case ConsoleColor.Green:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Yellow;
                    break;
            }
        }
    }

    class TrafficLightV1 : ITrafficLight
    {
        private ConsoleColor _consoleColor;
        private bool _downState = true;
        private readonly IOutput _output;
        public TrafficLightV1(IOutput output)
        {
            _output = output;
            _consoleColor = ConsoleColor.Yellow;
            SwitchState();
        }
        public void SwitchState()
        {
            switch(_consoleColor)
            {
                case ConsoleColor.Red:
                    _output.ShowInformation(ConsoleColor.Yellow);
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Green;
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = _downState ? ConsoleColor.Green : ConsoleColor.Red;
                    _downState = !_downState;
                    break;
                case ConsoleColor.Green:
                    _output.ShowInformation(ConsoleColor.Yellow);
                    _output.ShowInformation(_consoleColor);
                    _consoleColor = ConsoleColor.Red;
                    break;
            }
        }
    }

    class TrumConsoleInput : ITrumInput, IInput
    {
        private readonly ITextClass _textClass;
        public TrumConsoleInput(ITextClass textClass)
        {
            _textClass = textClass;
        }
        public bool NeedToExit()
        {
            Console.WriteLine(_textClass.GetFirstInformation());
            string _stroka = Console.ReadLine();
            if (_stroka == "q") return true;
            else
            {
                SettingsApp.eTrumSignal = _textClass.GetMode(_stroka);
                return false;
            }
        }
    }

    class TrumConsoleOutput : ITrumOutput
    {
        private readonly ITextClass _textClass;
        public TrumConsoleOutput(ITextClass textClass)
        {
            _textClass = textClass;
            
        }

        public void ClearInformation()
        {
            Console.Clear();
        }

        public void ShowInformation()
        {
            Console.WriteLine(_textClass.GetSignalTrafficLight(SettingsApp.eTrumSignal));
        }
    }

    class TrumTrafficLight : ITrafficLight
    {
        private readonly ITrumOutput _trumOutput;
        public TrumTrafficLight(ITrumOutput trumOutput)
        {
            _trumOutput = trumOutput;
            _trumOutput.ShowInformation();
        }
        public void SwitchState()
        {
            _trumOutput.ClearInformation();
            _trumOutput.ShowInformation();
        }
    }

    class TrumTextClass : ITextClass
    {
        public string GetFirstInformation()
        {
            string _message = "";
            _message = "Выберете действие:\r\n";
            _message += "0. Выключить светофор.\r\n";
            _message += "1. Включить светофор, который разрешает движения во все направления.\r\n";
            _message += "2. Включить светофор, который разрешает движение только прямо.\r\n";
            _message += "3. Включить светофор, который разрешает движение только налево.\r\n";
            _message += "4. Включить светофор, который разрешает движение только направо.\r\n";
            _message += "5. Включить светофор, который разрешает движение только прямо и налево.\r\n";
            _message += "6. Включить светофор, который разрешает движение только прямо и направо.\r\n";
            _message += "7. Включить светофор, который разрешает движение только налево и направо.\r\n";
            _message += "8. Включить светофор, который запрещает движение в любых направлениях.\r\n";
            _message += "q. Выйти из программы.";
            return _message;
        }

        public ETrumSignal GetMode(string stroka)
        {
            switch (stroka)
            {
                case "0":
                    return ETrumSignal.Off;
                case "1":
                    return ETrumSignal.LeftUpRight;
                case "2":
                    return ETrumSignal.Up;
                case "3":
                    return ETrumSignal.Left;
                case "4":
                    return ETrumSignal.Right;
                case "5":
                    return ETrumSignal.LeftUp;
                case "6":
                    return ETrumSignal.UpRight;
                case "7":
                    return ETrumSignal.LeftRight;
                case "8":
                    return ETrumSignal.Stop;
                default:
                    return ETrumSignal.Error;
            }
        }

        public string GetSignalTrafficLight(ETrumSignal eTrumSignal)
        {
            string _text = "";
            switch (eTrumSignal)
            {
                case ETrumSignal.Left:
                    _text = (string)("|O| | |\r\n  |O|");
                    break;
                case ETrumSignal.Right:
                    _text = (string)("| | |O|\r\n  |O|");
                    break;
                case ETrumSignal.Up:
                    _text = (string)("| |O| |\r\n  |O|");
                    break;
                case ETrumSignal.Stop:
                    _text = (string)("|O|O|O|\r\n  | |");
                    break;
                case ETrumSignal.LeftRight:
                    _text = (string)("|O| |O|\r\n  |O|");
                    break;
                case ETrumSignal.LeftUp:
                    _text = (string)("|O|O| |\r\n  |O|");
                    break;
                case ETrumSignal.UpRight:
                    _text = (string)("| |O|O|\r\n  |O|");
                    break;
                case ETrumSignal.LeftUpRight:
                    _text = (string)("|O|O|O|\r\n  |O|");
                    break;
                case ETrumSignal.Off:
                    _text = (string)("| | | |\r\n  | |");
                    break;
                case ETrumSignal.Error:
                    _text = (string)("Ввели недопустимую комманду!");
                    break;
            }
            return _text;
        }
    }

    interface ITextClass
    {
        string GetSignalTrafficLight(ETrumSignal eTrumSignal);
        string GetFirstInformation();
        ETrumSignal GetMode(string stroka);
    }

    interface ITrumOutput
    {
        void ShowInformation();
        void ClearInformation();
    }

    interface ITrumInput
    {
        bool NeedToExit();
    }

    class ConsoleOutput : IOutput
    {
        public void ShowInformation(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine("O");
        }
    }

    class ConsoleInput : IInput
    {
        public bool NeedToExit()
        {
            return Console.ReadLine() == "q";
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
        void ShowInformation(ConsoleColor consoleColor);
    }
    interface ITrafficLight
    {
        void SwitchState();
    } 
    interface ITrafficLight1
    {
        void SwitchState();
        
    }
}