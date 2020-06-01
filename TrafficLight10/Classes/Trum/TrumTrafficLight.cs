using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLight10.Interfaces;

namespace TrafficLight10.Classes.Trum
{
    class TrumTrafficLight : ITrafficLight
    {
        private readonly IInput _input;
        public TrumTrafficLight(IInput input)
        {
            _input = input;
        }
        public void SwitchState()
        {
            throw new NotImplementedException();
        }
    }
}
