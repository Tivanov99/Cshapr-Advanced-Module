using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countEngines = int.Parse(Console.ReadLine());
            List<Engine> Engines = new List<Engine>();
            for (int i = 0; i < countEngines; i++)
            {
                string[] input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    Engines.Add(new Engine(input[0], input[1], input[2], input[3]));
                }
                else
                {
                    if (input.Length == 3)
                    {
                        bool isDigit = false;
                        int count = 0;
                        foreach (var item in input)
                        {
                            if (count == 2)
                            {

                                if (int.TryParse(item, out int Number))
                                {
                                    Engines.Add(new Engine(input[0], input[1], input[2], "n/a"));
                                    isDigit = true;
                                    break;
                                }
                            }
                            count++;
                        }
                        if (!isDigit)
                        {
                            Engines.Add(new Engine(input[0], input[1], "n/a", input[2]));
                        }
                    }
                    else
                    {
                        Engines.Add(new Engine(input[0], input[1], "n/a", "n/a"));
                    }
                }
            }
            int CountOfCars = int.Parse(Console.ReadLine());
            List<Car> Cars = new List<Car>();
            for (int i = 0; i < CountOfCars; i++)
            {
                int count = 0;
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 4)
                {
                    Cars.Add(new Car(input[0], EgineFinder(Engines, input[1]), input[2], input[3]));
                }
                else if (input.Length == 2)
                {
                    Cars.Add(new Car(input[0], EgineFinder(Engines, input[1]), "n/a", "n/a"));
                }
                else
                {
                    bool isDigit = false;
                    if (input.Length == 3)
                    {
                        foreach (var item in input)
                        {
                            if (count == 2)
                            {
                                if (double.TryParse(item, out double num))
                                {
                                    Cars.Add(new Car(input[0], EgineFinder(Engines, input[1]), input[2], "n/a"));
                                    isDigit = true;
                                    break;
                                }
                            }
                            count++;
                        }
                        if (!isDigit)
                        {
                            Cars.Add(new Car(input[0], EgineFinder(Engines, input[1]), "n/a", input[2]));
                        }
                    }
                }
            }
            foreach (Car item in Cars)
            {
                Console.WriteLine($"{item.Model}:");
                Console.WriteLine($"      {item.Engine.Model}:");
                Console.WriteLine($"    Power: {item.Engine.Power}");
                Console.WriteLine($"    Displacement: {item.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {item.Engine.Effinciency}");
                Console.WriteLine($"  Weight: {item.Weight}");
                Console.WriteLine($"  Color: {item.Color}");
            }
        }
        static Engine EgineFinder(List<Engine> engines, string currmodel)
        {
            foreach (Engine item in engines)
            {
                if (item.Model == currmodel)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
