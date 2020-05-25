using System;

namespace TrafficLight9
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new TrafficLightTrum(new ConsoleOutputTrum()), new ConsoleInputTrum());
            _app.Run();
        }
    }

    public static class Settings
    {
        public static string stroka;
    }
    
    interface IApp
    {
        void Run();
    }
    interface IInput
    {
        bool NeedToExit();
    }
    interface IOutputTrum
    {
        void ShowMessage(string stroka);
        void OutputClear();
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
            SwitchState();
        }

        public virtual void SwitchState()
        {
            switch(_color)
            {
                case ConsoleColor.Green:
                    _output.ShowCurrentColor(_color);
                    _color = ConsoleColor.Yellow;                    
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowCurrentColor(_color);
                    _color = _downColor ? ConsoleColor.Green : ConsoleColor.Red;
                    _downColor = !_downColor;
                    break;
                case ConsoleColor.Red:
                    _output.ShowCurrentColor(_color);
                    _color = ConsoleColor.Yellow;
                    break;
            }
        }
    }
    class TrafficLightV1 : TrafficLight
    {
        public TrafficLightV1(IOutput output) : base(output) { }
        public override void SwitchState()
        {
            switch (_color)
            {
                case ConsoleColor.Green:
                    _output.ShowCurrentColor(ConsoleColor.Yellow);
                    _output.ShowCurrentColor(_color);
                    _color = ConsoleColor.Red;
                    break;
                case ConsoleColor.Yellow:
                    _output.ShowCurrentColor(_color);
                    _color = _downColor ? ConsoleColor.Green : ConsoleColor.Red;
                    _downColor = !_downColor;
                    break;
                case ConsoleColor.Red:
                    _output.ShowCurrentColor(ConsoleColor.Yellow);
                    _output.ShowCurrentColor(_color);
                    _color = ConsoleColor.Green;
                    break;

            }
        }
    }
    class TrafficLightTrum : ITrafficLight
    {
        protected readonly IOutputTrum _output;
        public TrafficLightTrum(IOutputTrum output)
        {
            _output = output;
            QuestionMessage();
        }

        private void QuestionMessage()
        {
            string _message;
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
            _output.ShowMessage(_message);
        }

        public void SwitchState()
        {
            _output.OutputClear();
            if (!ObrabotkaInfo()) { _output.ShowMessage(FinishMessage(-1)); }
            else
            {
                _output.ShowMessage(FinishMessage(Convert.ToInt32(Settings.stroka)));
            }
            QuestionMessage();
        }
        private string FinishMessage(int number)
        {
            switch (number)
            {
                case 0:
                    return "OFF";
                case 1:
                    return "|O|O|O|\r\n  |O|";                    
                case 2:
                    return "| |O| |\r\n  |O|";
                case 3:
                    return "|O| | |\r\n  |O|";
                case 4:
                    return "| | |O|\r\n  |O|";
                case 5:
                    return "|O|O| |\r\n  |O|";
                case 6:
                    return "| |O|O|\r\n  |O|";
                case 7:
                    return "|O| |O|\r\n  |O|";
                case 8:
                    return "|O|O|O|\r\n  | |";
                default:
                    return "Ввели недопустимую комманду!";
            }
        }

        private bool ObrabotkaInfo()
        {
            int _number;
            try
            {
                _number = Convert.ToInt32(Settings.stroka);
                return true;
            }
            catch(Exception ex)
            {
                return false;
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
    class ConsoleInputTrum : IInput
    {
        public bool NeedToExit()
        {
            string _stroka = "";
            _stroka = Console.ReadLine();
            if (_stroka == "q") return true;
            else
            {
                Settings.stroka = _stroka;
                return false;
            }
        }
    }
    class ConsoleOutputTrum : IOutputTrum
    {
        public void ShowMessage(string stroka)
        {
            Console.WriteLine(stroka);
        }

        public void OutputClear()
        {
            Console.Clear();
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
 