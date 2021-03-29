using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Iphone
{
    public class IphoneTablet : ITablet
    {
        public IphoneTablet(string model, int price)
        {
            Model = model;
            Price = price;
        }
        public string Model { get ; set ; }
        public int Price { get ; set ; }
    }
}
