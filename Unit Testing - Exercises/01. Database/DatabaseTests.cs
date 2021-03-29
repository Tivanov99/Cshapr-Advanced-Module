using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void DataBase_ShouldStartWithZeroCount_When_WeDidntGiveAnyElements()
        {
            database = new Database();
            int exprectedCount = 0;
            Assert.That(exprectedCount, Is.EqualTo(database.Count));
        }
        [Test]
        public void CountOfDataBase_ShouldIncreare_WhenAddElement()
        {
            database = new Database(1, 2);
            int expectedCount = 2;
            Assert.That(expectedCount, Is.EqualTo(database.Count));
        }
        [Test]
        public void DataBase_SouldCollect16Elements()
        {
            int[] input = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            database = new Database(input);
            int expectedCount = 16;
            Assert.That(expectedCount, Is.EqualTo(database.Count));
        }
        [Test]
        public void DataBase_Should_ThrowsExeption_WhenTryToAddMoreThan16Elements()
        {
            int[] input = new int[17] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,17 };
            Assert.Throws<InvalidOperationException>(() => database = new Database(input));
        }
        [Test]
        public void DataBase_ShouldThrowsExeption_WhenTryToRemoveElementAndHeIsEmpty()
        {
            database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void CountOfDataBase_ShouldDecreaseWhenRemoveItem()
        {
            database = new Database(1, 2, 3);
            int exprectedCount = 2;
            database.Remove();
            Assert.AreEqual(exprectedCount, database.Count);
        }
        [Test]
        public void RemoveMethoodFromDataBase_ShouldRemoveCorrectlyItem()
        {
            database = new Database(1, 2, 3);
            database.Remove();
            int[] coppy = database.Fetch();
            int[] exprectedElements = new int[2] { 1, 2 };
            Assert.AreEqual(exprectedElements, coppy);
        }
    }
}