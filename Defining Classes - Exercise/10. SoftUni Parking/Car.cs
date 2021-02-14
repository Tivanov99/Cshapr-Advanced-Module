using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsepower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsepower;
            RegistrationNumber = registrationNumber;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            return $"Make :{Make}\nModel: {Model}\nHorsePower: {HorsePower}\nRegistrationNumber: {RegistrationNumber}";
        }
    }
}
