using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight5
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    enum Ecolor
    {
        Red, Yellow, Green
    }
    interface ITrafficLight
    {
        void SwitchState();
        Ecolor GetCurrentColor();
    }
    interface IInput
    {
        bool NeedToWxit();
    }
    interface IOutput
    {
        void ShowCurrentLight(Ecolor color);
    }
    class App
    {

    }
}
