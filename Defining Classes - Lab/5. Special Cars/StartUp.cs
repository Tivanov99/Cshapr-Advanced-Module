using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Tire[]> tires = new List<Tire[]>();
            while (input != "No more tires")
            {
                string[] action = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Tire[] CurrColleciton = new Tire[]
                {
                     new Tire(int.Parse(action[0]),double.Parse(action[1])),
                     new Tire(int.Parse(action[2]),double.Parse(action[3])),
                     new Tire(int.Parse(action[4]),double.Parse(action[5])),
                     new Tire(int.Parse(action[6]),double.Parse(action[7])),
                };
                tires.Add(CurrColleciton);
                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            List<Engine> engines = new List<Engine>();
            while (input != "Engines done")
            {
                string[] action = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                engines.Add(new Engine(int.Parse(action[0]), double.Parse(action[1])));
                input = Console.ReadLine();
            }
            List<Car> Cars = new List<Car>();
            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] action = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int EngineIndex = int.Parse(action[5]);
                int TiresIndex = int.Parse(action[6]);
                Cars.Add(new Car(action[0], action[1], int.Parse(action[2]), double.Parse(action[3]), double.Parse(action[4]),
                    engines[EngineIndex], tires[TiresIndex]));
                input = Console.ReadLine();
            }
            foreach (Car item in Cars)
            {
                double totalSumofPressure = item.PressureSum(item.Tires);
                if (item.Year >= 2017 && item.Engine.HorsePower > 330 && totalSumofPressure >= 9 && totalSumofPressure <= 10)
                {
                    item.Drive();
                    Console.WriteLine($"Make: {item.Model}\nModel: {item.Make}\nYear: {item.Year}\nHorsePowers: {item.Engine.HorsePower}\nFuelQuantity: {item.FuelQuantity}");
                }
            }
        }
    }
}
