using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;
using TrafficLight10.Interfaces.ITrum;

namespace TrafficLight10.Classes.Trum
{
    class TrumConsoleOutput : ITrumOutput
    {
        private readonly ITextOutput _textOutput;
        public TrumConsoleOutput()
        {

        }
        public TrumConsoleOutput(ITextOutput textOutput)
        {
            _textOutput = textOutput;
        }
        public void ClearInfo()
        {
            Console.Clear();
        }

        public void ShowInfo(string text)
        {
            Console.WriteLine(text);
        }
    }
}
