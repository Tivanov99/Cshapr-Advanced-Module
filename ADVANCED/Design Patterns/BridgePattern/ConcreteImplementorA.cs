﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    public class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }
}
