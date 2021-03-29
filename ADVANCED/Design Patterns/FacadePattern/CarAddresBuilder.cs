using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarAddresBuilder : CarBuilderFacade
    {
        public CarAddresBuilder(Car car)
        {
            Car = car;
        }

        public CarAddresBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddresBuilder AtAddres(string addres)
        {
            Car.Adress = addres;
            return this;
        }
    }
}
