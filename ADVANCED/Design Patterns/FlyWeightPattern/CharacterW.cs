using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class CharacterW : Character
    {
        public CharacterW()
        {
            this.symbol = 'W';
            this.type = "Warrior";
            this.role = "Mele Dps";
            this.pointSize = 20;
        }
        public override void Display(int pointSize)
        {
            Console.WriteLine($"{this.type} with {this.pointSize}");
        }

    }
}
