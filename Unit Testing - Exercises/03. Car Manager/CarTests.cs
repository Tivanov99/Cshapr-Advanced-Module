using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        private string make = "make";
        private string model = "model";
        private double fuelconsuption = 10;
        private double fuelcapacity = 100;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarMake_ShouldThrowsExeptionWhenPassedInvalidData(string make)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(make, "model", 1, 1));
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarModel_ShouldThrowsExeptionWhenPassedInvalidData(string model)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", model, 1, 1));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarFuelConsuption_ShouldThrowsExeptionWhenPassedInvalidData(double fuelconsuption)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", fuelconsuption, 1));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarFuelCapacity_ShouldThrowsExeptionWhenPassedInvalidData(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("make", "model", 1, fuelCapacity));
        }


        [Test]
        public void Ctor_ShouldSelectCorrectlyData()
        {
            car = new Car("make", "model", fuelconsuption, fuelcapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelconsuption, car.FuelConsumption);
            Assert.AreEqual(fuelcapacity, car.FuelCapacity);
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelShouldThrowExeption_WhenPassedInvalidValue(double refuelValue)
        {
            car = new Car(make, model, fuelconsuption, fuelcapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(refuelValue));
        }
        [Test]
        [TestCase(50)]
        public void RefuelShouldIncreaseFuelAmountWithGivenValue_WhenPassedValidData(double refuelValue)
        {
            car = new Car(make, model, fuelconsuption, fuelcapacity);
            car.Refuel(refuelValue);
            Assert.AreEqual(refuelValue, car.FuelAmount);
        }
        [Test]
        [TestCase(110)]
        public void FuelAmount_NotShouldBeBiggestThanFuelCapacity(double refuelValue)
        {
            car = new Car(make, model, fuelconsuption, fuelcapacity);
            car.Refuel(refuelValue);
            Assert.AreEqual(this.fuelcapacity, car.FuelAmount);
        }
        [Test]
        public void Car_ShouldThrowExeptionWhenTheyDontHaveEnoughFuelAmount()
        {
            car = new Car(make, model, fuelconsuption, fuelcapacity);
            double distance = 110;
            car.Refuel(10);
            Assert.Throws<InvalidOperationException>(()=> car.Drive(distance));
        }
        [Test]
        public void Car_ShouldDriveGivenDistance_WhenSheHaveEnoughFuel()
        {
            car = new Car(make, model, fuelconsuption, fuelcapacity);
            double distance = 90;
            car.Refuel(10);
            car.Drive(90);
            double expectedLeftFuelAmount = 1;
            Assert.AreEqual(expectedLeftFuelAmount, car.FuelAmount);
        }
    }
}