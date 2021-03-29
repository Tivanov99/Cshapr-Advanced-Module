using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class Tests
    {
        private ITransaction transaction;
        private IChainblock Chainblock;
        private int ID = 11;
        private string From = "From";
        private TransactionStatus status = TransactionStatus.Successfull;
        private string To = "to";
        private double Amount = 100;
        [SetUp]
        public void SetUp()
        {
            this.transaction = new Transaction(11, TransactionStatus.Successfull, "from", "to", 100);
            this.Chainblock = new Chainblock();
        }
        [Test]
        public void AddTransaction_Should_Throws_WhenTransactionAlreadyExist()
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => Chainblock.Add(transaction));
        }
        [Test]
        public void Transaction_ShouldBeAdded_WhenHiIsValidAndNotExist()
        {
            this.Chainblock.Add(transaction);
            bool result = this.Chainblock.Contains(transaction);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void CountOfTransactions_ShouldIncrease_When_AddNewValidTransactiom()
        {
            this.Chainblock.Add(transaction);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.Chainblock.Count);
        }
        [Test]
        public void CountOfTransactions_ShouldDecrease_WhenRemoveAnyTransaction()
        {
            this.Chainblock.Add(transaction);
            this.Chainblock.Add(new Transaction(12, TransactionStatus.Aborted, "from", "g", 26));
            this.Chainblock.RemoveTransactionById(this.ID);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.Chainblock.Count);
        }
        [Test]
        public void TransactionStatus_ShouldBeChanged_WhenPassedIDIsValid()
        {
            this.Chainblock.Add(transaction);
            ITransaction expected = new Transaction(this.ID, TransactionStatus.Aborted, this.From, this.To, this.Amount);
            this.Chainblock.ChangeTransactionStatus(this.ID, TransactionStatus.Aborted);
            ITransaction actual = this.Chainblock.GetById(this.ID);
            Assert.That(expected.Id, Is.EqualTo(actual.Id));
            Assert.That(expected.Status, Is.EqualTo(actual.Status));
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(8)]
        public void ChangeTransactionStatus_ShouldThrowException_WhenPassedIDIsInvalid(int id)
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => this.Chainblock.ChangeTransactionStatus(id, TransactionStatus.Unauthorized));
        }
        [Test]
        public void ChangeTransactionStatus_ShouldThrowExceptionWhenTheStatusISTheSameWithNewPassedStatus()
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => Chainblock.ChangeTransactionStatus(this.ID, this.status));
        }
        [Test]
        public void ChangeTransactionStatus_ShouldThrowExceptionWhenCountIsEqualToZero()
        {
            Assert.Throws<InvalidOperationException>(() => Chainblock.ChangeTransactionStatus(this.ID, this.status));
        }
        [Test]
        public void Contais_ShouldReturnFalse_WhenPassedTransactionNotExist()
        {
            bool expectedResult = false;
            bool ActualResult = this.Chainblock.Contains(transaction);
            Assert.AreEqual(expectedResult, ActualResult);
        }
        [Test]
        public void Contais_ShouldReturnTrue_WhenPassedTransactionExist()
        {
            bool expectedResult = true;
            this.Chainblock.Add(transaction);
            bool ActualResult = this.Chainblock.Contains(transaction);
            Assert.AreEqual(expectedResult, ActualResult);
        }
        [Test]
        public void Contais_ShouldReturnFalse_WhenPassedIDNotExist()
        {
            bool expectedResult = false;
            bool ActualResult = this.Chainblock.Contains(this.ID);
            Assert.AreEqual(expectedResult, ActualResult);
        }
        [Test]
        public void Contais_ShouldReturnTrue_WhenPassedIDExist()
        {
            bool expectedResult = true;
            this.Chainblock.Add(transaction);
            bool ActualResult = this.Chainblock.Contains(this.ID);
            Assert.AreEqual(expectedResult, ActualResult);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void RemoveTransacitonById_ShouldThrowException_WhenIdIsInvalid(int id)
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => this.Chainblock.RemoveTransactionById(id));
        }
        [Test]
        public void RemoveTransacitonById_ShouldRemoveCorrectly_WhenIdIsValid()
        {
            this.Chainblock.Add(transaction);
            this.Chainblock.Add(new Transaction(this.ID + 1, this.status, this.From, this.To, this.Amount));
            this.Chainblock.RemoveTransactionById(this.ID);
            bool expected = false;
            bool actual = Chainblock.Contains(this.ID);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RemoveTransacitonById_ShouldThrowException_WhenIDNotExist()
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.RemoveTransactionById(this.ID + 1));
        }
        [Test]
        public void RemoveTransacitonById_ShouldThrowException_WhenCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.RemoveTransactionById(this.ID));
        }
        [Test]
        public void GetByIdMethood_ShouldThrowException_WhenCountIsEqualToZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetById(this.ID));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void GetByIdMethood_ShouldThrowException_WhenIdIsInvalid(int id)
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetById(id));
        }
        [Test]
        public void GetByIdMethood_ShouldRetunCorrectlyTransaction_WhenIdIsExist()
        {
            this.Chainblock.Add(transaction);
            ITransaction actual = this.Chainblock.GetById(this.ID);
            Assert.AreEqual(transaction, actual);
        }
        [Test]
        public void GetByIdMethood_ShouldThrowException_WhenIdIsNotExist()
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetById(this.ID + 1));
        }
        [Test]
        public void GetByTransactionStatus_ShouldThrowException_WhenNoExistTransactionsWithThisStatus()
        {
            List<ITransaction> actual = this.Chainblock.GetByTransactionStatus(status).ToList();
            List<ITransaction> expected = new List<ITransaction>();
            Assert.That(expected, Is.EquivalentTo(actual));
        }
        [Test]
        public void GetByTransactionStatus_ShouldReturnCorrectly_WhenStatusIsValid()
        {
            this.Chainblock.Add(transaction);
            this.Chainblock.Add(new Transaction(this.ID + 1, TransactionStatus.Failed, this.From, this.To, this.Amount));
            List<ITransaction> actual = this.Chainblock.GetByTransactionStatus(status).ToList();
            List<ITransaction> Expected = new List<ITransaction>() { transaction };
            Assert.That(Expected, Is.EquivalentTo(actual));
        }
        //HERE
        [Test]
        [TestCase(-1, 10)]
        [TestCase(0, 10)]
        [TestCase(11, 10)]
        [TestCase(10, -1)]
        [TestCase(10, 0)]
        public void GetAllInAmountRange_ShouldThrowException_WhenPassedInvalidData(double lo, double hi)
        {
            this.Chainblock.Add(transaction);
            Assert.Throws<ArgumentException>(() => this.Chainblock.GetAllInAmountRange(lo, hi));
        }
        [Test]
        [TestCase(10, 11)]
        public void GetAllInAmountRange_ShouldThrowException_WhenCountISEqualToZero(double lo, double hi)
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetAllInAmountRange(lo, hi));
        }

        [Test]
        [TestCase(100, 101)]
        public void GetAllInAmountRange_ShouldReturnCorrectlyTransactions(double lo, double hi)
        {
            //CHEK HERE
            this.Chainblock.Add(transaction);
            ITransaction Second = new Transaction(this.ID + 1, this.status, this.From, this.To, this.Amount + 1);
            this.Chainblock.Add(new Transaction(this.ID + 3, TransactionStatus.Failed, this.From, this.To, this.Amount - 50));
            this.Chainblock.Add(Second);
            List<ITransaction> expected = new List<ITransaction>() { transaction, Second };
            List<ITransaction> actual = new List<ITransaction>(this.Chainblock.GetAllInAmountRange(lo, hi));
            Assert.That(expected, Is.EquivalentTo(actual));
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldThrowException_WhenCountIsZero()
        {
            Assert.Throws<InvalidOperationException>(() => this.Chainblock.GetAllOrderedByAmountDescendingThenById());
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ShouldReturnCorrectly()
        {
            this.Chainblock.Add(transaction);
            ITransaction Second = new Transaction(this.ID + 1, this.status, this.From, this.To, this.Amount + 1);
            this.Chainblock.Add(Second);
            List<ITransaction> expected = new List<ITransaction>();
            //continue
        }
    }
}
