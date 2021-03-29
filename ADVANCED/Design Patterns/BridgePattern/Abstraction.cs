using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class Abstraction
    {
        protected Implementor implementor;
        // Property
        public Implementor Implementor
        {
            set { implementor = value; }
        }
        public virtual void Operation()
        {
            implementor.Operation();
        }
    }
}
