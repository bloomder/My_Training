using System;

namespace LightSignal1
{
    class Program
    {
        static bool flag_while = true;
        static Svetofor svetofor;
        static string stroka = "";
        static bool flag_error = false;
        static void Main(string[] args)
        {
            svetofor = new Svetofor(4); 
            while(flag_while)
            {
                Console.Clear();
                if (flag_error) Console.WriteLine("Допущена ошибка! Повторите действие.");
                Console.WriteLine(svetofor.StateLightColor());
                Console.Write("Выберите действие:");
                stroka = "";
                for (int i = 0; i < svetofor.Property_light_signal.Mass_colors.Length/2; i++)
                {
                    if (i == 0) stroka += "\r\n1. Выключить светофор.";
                    else
                    {
                        stroka += $"\r\n{(i+1).ToString()}. Зажечь {svetofor.Property_light_signal.Mass_colors[i, 0].ToLower()} цвет на светофоре.";
                    }
                }
                stroka += "\r\nq. Выйти из программы.";
                Console.WriteLine(stroka); stroka = "";
                try
                {
                    stroka += Console.ReadKey().KeyChar;
                    if (stroka == "q") { flag_while = false; stroka = ""; }
                    else
                    {
                        if (svetofor.ChangeLightColor((Convert.ToInt32(stroka) - 1))) { flag_error = false; }
                        else flag_error = true;
                        stroka = "";
                    }
                }
                catch(Exception ex)
                {
                    stroka = ""; flag_error = true;
                }
            }
        }
    }
}
