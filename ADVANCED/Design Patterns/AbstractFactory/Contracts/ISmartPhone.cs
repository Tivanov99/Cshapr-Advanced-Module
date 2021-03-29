using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Contracts
{
    public interface ISmartPhone
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
