using LightSignal2.Colors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LightSignal2
{
    class TrafficControl : ITrafficControl
    {
        EColors eColors;
        bool SwitchDown =true;
        public TrafficControl(EColors eColors)
        {
            this.eColors = eColors;
        }

        public void SwitchLight()
        {
            switch (eColors)
            {
                case EColors.Red:
                    eColors = EColors.Yellow;
                    break;
                case EColors.Yellow:
                    eColors = SwitchDown == true ? EColors.Red : EColors.Green;
                    SwitchDown = SwitchDown == true ? false : true;
                    break;
                case EColors.Green:
                    eColors = EColors.Yellow;
                    break;
            }
        }

        public string StateColor()
        {
            return (string)($"Светофор горит: {eColors.ToString()}");
        }
    }
}
