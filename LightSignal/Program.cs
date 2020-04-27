using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LightSignal
{
    class Program
    {
        static void Main(string[] args)
        {
            SignalLigth sl = new SignalLigth();
            bool a = true;
            int ch = 0;
            string str="";
            while(a)
            {
                Console.Clear();
                str = "";
                if (sl.color!=null)
                {
                    Console.WriteLine("Светофор светиться: " + sl.color.ToString());
                }
                Console.WriteLine("Выберите значение, чтобы указать цвет светофора:");
                Console.WriteLine("1. Green\r\n2. Yellow\r\n3. Red");
                try
                {
                    str += Console.ReadKey().KeyChar;
                    ch = Convert.ToInt32(str);
                }
                catch(Exception ex)
                {
                    if(str=="q")
                    {
                        a = false;
                    }
                    else
                    {
                        Console.WriteLine("Ввели не допустимое значение!");
                        Thread.Sleep(1000);
                    }
                }
                sl.ChangeColor(ch);
            }
        }
    }
}
