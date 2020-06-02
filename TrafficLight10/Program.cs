using TrafficLight10.Classes;
using TrafficLight10.Classes.Trum;
using TrafficLight10.Interfaces;

namespace TrafficLight10
{
    class Program
    {
        static void Main(string[] args)
        {
            //IApp _app = new App(new TrafficLightV1(new ConsoleOutput()), new ConsoleInput());
            IApp _app = new App(new TrumTrafficLight(new TrumConsoleOutput(), new TrumTextClass()), new TrumConsoleInput());
            _app.Run();
        }
    }
}
