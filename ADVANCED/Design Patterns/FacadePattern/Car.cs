using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class Car
    {
        public Engine Engine { get; set; }

        public string Type { get; set; }

        public string Color { get; set; }

        public int NumberOfDoors { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public override string ToString()
        {
            return $"CarType:{Type}, Color: {Color}, Number Of Doors: {NumberOfDoors}, Manufactured in: {City}, at adress: {Adress}";
        }
    }
}
