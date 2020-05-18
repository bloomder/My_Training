using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        interface IApp
        {
            void Run();
        }
        interface IAnimal
        {
            void Say();
        }
        interface IInput
        {
            bool NeedToExit();
        }
        interface IOutput
        {
            void ShowInformation();
        }
        class ConsoleInput : IInput
        {
            public bool NeedToExit()
            {
                return Console.ReadLine() == "q";
            }
        }

        class Animal : IAnimal
        {
            public virtual void Say()
            {
                throw new NotImplementedException();
            }
        }

        class App : IApp
        {
            private readonly IInput _input;
            public void Run()
            {
                while(true)
                {
                    if()
                }
            }
        }
    }
}
