using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightSignal
{
    class SignalLigth
    {
        public string color;
        public virtual void ChangeColor(int i) // Я могу ошибиться, но виртуал нужен для 
        {// переопределния, у дорожного 4 значения, у пешего 3
            switch(i)
            {
                case 0:
                    {
                        color = null;
                        break;
                    }
                case 1:
                    {
                        color = "Green";
                        break;
                    }
                case 2:
                    {
                        color = "Yellow";
                        break;
                    }
                case 3:
                    {
                        color = "Red";
                        break;
                    }
            }
        }
    }
}
