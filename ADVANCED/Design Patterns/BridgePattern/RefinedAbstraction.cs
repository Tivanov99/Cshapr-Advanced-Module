using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }
}
