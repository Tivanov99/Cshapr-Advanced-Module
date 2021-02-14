using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, string power, string dispacement, string effinciency)
        {
            Model = model;
            Power = power;
            Displacement = dispacement;
            Effinciency = effinciency;
        }
        public string Model { get; set; }
        public string Power { get; set; }
        public string Displacement { get; set; }
        public string Effinciency { get; set; }

    }
}
