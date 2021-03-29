using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ITechnologyFactory technologyFactory = new IphoneFactory();
            technologyFactory.CreatePhone("iphone 12", 300);
            technologyFactory.CreateTablet("airPro13", 12);
        }
    }
}
