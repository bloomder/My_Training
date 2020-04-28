namespace LightSignal1
{
    class PropertyLightSignal
    {
        public int Numb_color { get; set; }
        int numb_color;
        public string[,] Mass_colors { get { return mass_colors; } }
        string[,] mass_colors;
        public PropertyLightSignal()
        {
            numb_color = 0;
            AddMassColors(mass_colors);
        }
        protected virtual void AddMassColors(string[,] mass_colors_met)
        {
            mass_colors_met = new string[4, 2];
            mass_colors_met[0, 0] = null;
            mass_colors_met[0, 1] = null;

            mass_colors_met[1, 0] = "Зелёный";
            mass_colors_met[1, 1] = "Зелёным";

            mass_colors_met[2, 0] = "Жёлтый";
            mass_colors_met[2, 1] = "Жёлтым";

            mass_colors_met[3, 0] = "Красный";
            mass_colors_met[3, 1] = "Красным";
            mass_colors = mass_colors_met;
        }
    }
}
