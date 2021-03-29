using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Iphone
{
    public class IphonePhone : ISmartPhone
    {
        public IphonePhone(string model, int price)
        {
            Model = model;
            Price = price;
        }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
