using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class CharacterP : Character
    {
        public CharacterP()
        {
            this.symbol = 'P';
            this.type = "Paladin";
            this.role = "Dps/Healer";
            this.pointSize = 19;
        }
        public override void Display(int pointSize)
        {
            Console.WriteLine($"{this.type} with {this.pointSize}");

        }
    }
}
