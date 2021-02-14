using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car(string model, string make, int year, double fuelquantity, double fuelconsuption, Engine engine, Tire[] tires)
        {
            Model = model;
            Make = make;
            Year = year;
            FuelQuantity = fuelquantity;
            FuelConsuption = fuelconsuption;
            Engine = engine;
            Tires = tires;
        }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsuption { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }

        public double PressureSum(Tire[] tires)
        {
            double totalSUm = 0;
            foreach (Tire item in tires)
            {
                totalSUm += item.Pressure;
            }
            return totalSUm;
        }
        public void Drive()
        {
            double currfuel = FuelQuantity;
            double litters = 20 * FuelConsuption/100;
            if (currfuel - litters > 0)
            {
                currfuel -=litters;
                FuelQuantity = currfuel;
            }
        }
    }
}
