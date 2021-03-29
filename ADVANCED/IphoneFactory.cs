using AbstractFactory.Contracts;
using AbstractFactory.Iphone;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public class IphoneFactory : ITechnologyFactory
    {
        public ISmartPhone CreatePhone(string name, int price)
        {
            return new IphonePhone(name, price);
        }

        public ITablet CreateTablet(string name, int price)
        {
            return new IphoneTablet(name, price);
        }
    }
}
