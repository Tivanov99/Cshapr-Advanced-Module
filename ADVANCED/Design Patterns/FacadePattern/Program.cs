using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                .WithColor("Blue")
                .WithType("330Xi")
                .WithNumberOfDoors(5)
            .Built
            .InCity("Burgas")
            .AtAddres("vuzdazhdane")
            .BuildEngine.SetCubics(3000)
            .SetHp(231)
            .SetFuel("BENz")
            .Build();

            Console.WriteLine(car);

        }
    }
}
