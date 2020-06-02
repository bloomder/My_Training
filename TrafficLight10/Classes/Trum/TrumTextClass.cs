using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes.Trum
{
    class TrumTextClass : ITextOutput
    {
        public string GetInfoText(int number)
        {
            string _text = "";
            switch (number)
            {
                case 0:
                    _text = "OFF";
                    break;
                case 1:
                    _text = "|O|O|O|\r\n  |O|";
                    break;
                case 2:
                    _text = "| |O| |\r\n  |O|";
                    break;
                case 3:
                    _text = "|O| | |\r\n  |O|";
                    break;
                case 4:
                    _text = "| | |O|\r\n  |O|";
                    break;
                case 5:
                    _text = "|O|O| |\r\n  |O|";
                    break;
                case 6:
                    _text = "| |O|O|\r\n  |O|";
                    break;
                case 7:
                    _text = "|O| |O|\r\n  |O|";
                    break;
                case 8:
                    _text = "|O|O|O|\r\n  | |";
                    break;
                default:
                    _text = "Ввели недопустимую комманду!";
                    break;
            }
            return _text;
        }
        public string GetFirstText()
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
    }
}
