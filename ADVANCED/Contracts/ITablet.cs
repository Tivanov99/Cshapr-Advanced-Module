using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory.Contracts
{
    public interface ITablet
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
