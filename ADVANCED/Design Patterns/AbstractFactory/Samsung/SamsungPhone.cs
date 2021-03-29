using AbstractFactory.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Samsung
{
    public class SamsungPhone : ISmartPhone
    {
        public SamsungPhone(string model, int price)
        {
            Model = model;
            Price = price;
        }
        public string Model { get ; set ; }
        public int Price { get ; set ; }
    }
}
