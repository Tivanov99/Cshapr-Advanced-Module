using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public abstract class Character
    {
        protected char symbol;
        protected string type;
        protected string role;
        protected int pointSize;

        public abstract void Display(int pointSize);
    }
}
