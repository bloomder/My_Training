namespace LightSignal1
{
    class Svetofor
    {
        public PropertyLightSignal Property_light_signal { get { return property_light_signal; } }
        PropertyLightSignal property_light_signal;
        
        public Svetofor(int count_mass_colors)
        {
            property_light_signal = new PropertyLightSignal();            
        }
        private Svetofor(){}
        public virtual bool ChangeLightColor(int number_color)
        {
            if (number_color >= 0 && number_color < 4) 
            {
                if ((number_color == 0) || (property_light_signal.Numb_color == 0)) 
                {
                    property_light_signal.Numb_color = number_color;
                    return true;
                }
                else
                {
                    if ((number_color + 1 == property_light_signal.Numb_color) || (number_color - 1 == property_light_signal.Numb_color))
                    {
                        property_light_signal.Numb_color = number_color;
                        return true;
                    }
                    else return false;
                }
            }
            else return false;
        }
        public string StateLightColor()
        {
            return (property_light_signal.Numb_color != 0)?(string)($"Светофор горит {property_light_signal.Mass_colors[property_light_signal.Numb_color, 1].ToLower()} цветом."):(string)("Светофор выключен.");
        }
    }
}
