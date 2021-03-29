using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public interface ITechnologyFactory
    {
        public ISmartPhone CreatePhone(string name, int price);
        public ITablet CreateTablet(string name, int price);
    }
}
