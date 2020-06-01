using TrafficLight10.Classes;
using TrafficLight10.Interfaces;

namespace TrafficLight10
{
    class Program
    {
        static void Main(string[] args)
        {
            IApp _app = new App(new TrafficLightV1(new ConsoleOutput()), new ConsoleInput());
            _app.Run();
        }
    }
}
