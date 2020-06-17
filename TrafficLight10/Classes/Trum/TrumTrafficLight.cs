using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;
using TrafficLight10.Interfaces.ITrum;

namespace TrafficLight10.Classes.Trum
{
    class TrumTrafficLight : ITrafficLight
    {
        private readonly ITrumOutput _trumOutput;
        private readonly ITextOutput _textOutput;
        public TrumTrafficLight(ITrumOutput trumOutput, ITextOutput textOutput)
        {
            _trumOutput = trumOutput;
            _textOutput = textOutput;
            _trumOutput.ShowInfo(_textOutput.GetFirstText());
        }
        private void ProcessingInfo()
        {
            
            try
            {
                 _trumOutput.ShowInfo(_textOutput.GetInfoText(Convert.ToInt32(Settings.Settings.stroka)));
            }
            catch(Exception ex)
            {
                _trumOutput.ShowInfo(_textOutput.GetInfoText(-1));
            }
            

        }
        public void SwitchState()
        {
            _trumOutput.ClearInfo();
            ProcessingInfo();
            _trumOutput.ShowInfo(_textOutput.GetFirstText());
        }
    }
}
