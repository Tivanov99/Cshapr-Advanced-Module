using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        int Capacity;
        List<Car> Collection;
        public Parking(int capacity)
        {
            Capacity = capacity;
            Collection = new List<Car>();
            Count = 0;
        }
        public int Count { get; set; }
        public string AddCar(Car car)
        {
            if (Collection.Count >= Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                foreach (Car item in Collection)
                {
                    if (item.RegistrationNumber == car.RegistrationNumber)
                    {
                        return "Car with that registration number, already exists!";
                    }
                }
            }
            Count++;
            Collection.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {
            List<Car> cars = new List<Car>(Collection);
            foreach (Car item in Collection)
            {
                if (item.RegistrationNumber == registrationNumber)
                {
                    Count--;
                    cars.Remove(item);
                    Collection = cars;
                    return $"Successfully removed {registrationNumber}";
                }
            }
            return "Car with that registration number, doesn't exist!";
        }
        public Car GetCar(string registationNumber)
        {
            foreach (Car item in Collection)
            {
                if (item.RegistrationNumber == registationNumber)
                {
                    return item;
                }
            }
            return null;
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            List<Car> cars = new List<Car>(Collection);
            int index = 0;
            foreach (Car item in Collection)
            {
                if (RegistrationNumbers.Contains(item.RegistrationNumber))
                {
                    cars.RemoveAt(index);
                    index--;
                    Count--;
                }
                index++;
            }
            Collection = cars;
        }
    }
}
