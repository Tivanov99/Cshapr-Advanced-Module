using AbstractFactory.Contracts;
using AbstractFactory.Samsung;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class SamsungFactory : ITechnologyFactory
    {
        public ISmartPhone CreatePhone(string name, int price)
        {
            return new SamsungPhone(name, price);
        }

        public ITablet CreateTablet(string name, int price)
        {
            return new SamsungTablet(name, price);
        }
    }
}
