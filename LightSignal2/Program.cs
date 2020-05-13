using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSignal2
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficControl trafficControl = new TrafficControl(Colors.EColors.Yellow);
            
            bool flagWhile = true;
            char charKey;
            while(flagWhile)
            {
                Console.WriteLine(trafficControl.StateColor());
                charKey = Console.ReadKey().KeyChar;
                if (charKey == 'q') flagWhile = false;
                trafficControl.SwitchLight();
            }
        }
    }
}
