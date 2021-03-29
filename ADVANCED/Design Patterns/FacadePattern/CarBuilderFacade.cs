﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarBuilderFacade
    {
        protected Car Car { get; set; }
        public CarBuilderFacade()
        {
            Car = new Car();
        }
        public Car Build() => Car;

        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarBuilderEngine BuildEngine => new CarBuilderEngine(Car);
        public CarAddresBuilder Built => new CarAddresBuilder(Car);
    }
}
