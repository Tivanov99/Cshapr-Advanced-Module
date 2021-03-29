using System;
using System.Collections.Generic;
using System.Text;

namespace Facade
{
    public class CarBuilderEngine : CarBuilderFacade
    {
        public CarBuilderEngine(Car car)
        {
            Car = car;
        }
        public CarBuilderEngine SetCubics(double cubics)
        {
            Car.Engine.Cubics = cubics;
            return this;
        }
        public CarBuilderEngine SetHp(int hp)
        {
            Car.Engine.Hp = hp;
            return this;
        }
        public CarBuilderEngine SetFuel(string fuel)
        {
            Car.Engine.TypeOfFuel = fuel;
            return this;
        }
    }
}
