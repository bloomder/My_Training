using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight11.Interfaces;

namespace TrafficLight11.Classes
{
    class TrafficLight : ITrafficLight
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        public TrafficLight(IInput input, IOutput output)
        {
            _input = input;
            _output = output;
            if (_output != null) _output.ShowResult();
            if (_input != null) _input.ShowFistInfo();            
        }
        public TrafficLight(IInput input) : this(input, null) { }
        public TrafficLight(IOutput output) : this(null, output) { }
        public void SwitchState()
        {
            throw new NotImplementedException();
        }
    }
}
