using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase database;
        private Person person1;
        private Person person2;
        private Person[] persons;

        [SetUp]
        public void Setup()
        {
            person1 = new Person(26, "trix");
            person2 = new Person(21, "rali");
            persons = new Person[16];
            for (int i = 0; i < 16; i++)
            {
                persons[i] = new Person(i, $"{i}");
            }
        }

        [Test]
        public void DataBaseShouldThrowsExeption_WhenTryToPassRangeMoreThan16Persons()
        {
            Person[] persons = new Person[17];
            Assert.Throws<ArgumentException>(() => database = new ExtendedDatabase(persons));
        }
        [Test]
        public void DataBaseShouldIncreaseCountCorrectly_WhenPassValidRange()
        {

            database = new ExtendedDatabase(person1, person2);
            int expectedCountOfPerson = 2;
            Assert.AreEqual(expectedCountOfPerson, database.Count);
        }
        [Test]
        public void DataBase_ShouldThrowExeption_WhenCountIs16AndTryToAddMorePersons()
        {
            database = new ExtendedDatabase(persons);
            Assert.Throws<InvalidOperationException>(() => database.Add(person1));
        }
        [Test]
        public void DataBase_ShouldThrowExeption_WhenAlreadyContainsPersonName()
        {
            persons[1] = new Person(1, "0");
            Assert.Throws<InvalidOperationException>(() => database = new ExtendedDatabase(persons));
        }
        [Test]
        public void DataBase_ShouldThrowExeption_WhenAlreadyContainsPersonID()
        {
            persons[1] = new Person(0, "1");
            Assert.Throws<InvalidOperationException>(() => database = new ExtendedDatabase(persons));
        }
        [Test]
        public void DataBaseShouldIncreaseCountWhenAddValidPersons()
        {
            database = new ExtendedDatabase(person1);
            database.Add(person2);
            int ExpectedCount = 2;
            Assert.AreEqual(ExpectedCount, database.Count);
        }
        [Test]
        public void DataBase_ShouldThrowExeption_WhenCountIsEqualToZeroAndTryToRemove()
        {
            database = new ExtendedDatabase();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void DataBase_ShouldDecreaseCount_WhenRemovePerson()
        {
            database = new ExtendedDatabase(person1,person2);
            database.Remove();
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Should_ThrowExceptionWhenPassInvalidUserNameToMethoodFindByUserName(string name)
        {
            database = new ExtendedDatabase();
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));
        }
        [Test]
        public void Should_ThrowExceptionWhenPassUserNameWhitchIsNotContainedToMethoodFindByUserName()
        {
            database = new ExtendedDatabase(person1);
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(person2.UserName));
        }
        [Test]
        public void Should_ReturnPersonWithGivenUserName_WhenIsValid()
        {
            database = new ExtendedDatabase(person1, person2);
            Person ExpectedPerson = database.FindByUsername(person2.UserName);
            Assert.AreEqual(person2, ExpectedPerson);
        }
        [Test]
        public void Should_ThrowExeption_WhenTryToFindUserWhichIDIsNegative()
        {
            database = new ExtendedDatabase(person1);
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }
        [Test]
        public void Should_ThrowExeption_WhenTryToFindUserWhichInvalidId()
        {
            database = new ExtendedDatabase(person1);
            Assert.Throws<InvalidOperationException>(() => database.FindById(2));
        }
        [Test]
        public void Should_ReturnPersonWithGivenID_WhenIsValid()
        {
            database = new ExtendedDatabase(person1, person2);
            Person ExpectedPerson = database.FindById(person2.Id);
            Assert.AreEqual(person2, ExpectedPerson);
        }
    }
}