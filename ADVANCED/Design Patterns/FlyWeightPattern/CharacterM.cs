using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class CharacterM : Character
    {
        public CharacterM()
        {
            this.symbol = 'M';
            this.role = "Range DPS";
            this.type = "Mage";
            this.pointSize = 18;
        }
        public override void Display(int pointSize)
        {
            Console.WriteLine($"{this.type} with {this.pointSize}");
        }
    }
}
