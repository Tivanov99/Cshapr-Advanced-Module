using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior1;
        private string name = "trix";
        private int dmg = 20;
        private int hp = 40;
        private Warrior warrior2;
        private string name2 = "rali";
        private int dmg2 = 10;
        private int hp2 = 40;


        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior1 = new Warrior(this.name, this.dmg, this.hp);
            this.warrior2 = new Warrior(this.name2, this.dmg2, this.hp2);

        }

        [Test]
        public void Arena_ShouldStartWithZeroCount()
        {
            int exprectedCount = 0;
            Assert.AreEqual(exprectedCount, this.arena.Count);
        }
        [Test]
        public void Arena_ShouldThrowException_WhenTryToEnrollAlreadyExistringWarrior()
        {
            arena.Enroll(warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior1));
        }
        [Test]
        public void Arena_ShouldAddWarrior_WhenHeIsValid()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, arena.Count);
        }
        [Test]
        public void Arena_ShouldThrowException_WhenPassedInvaliDataForAttacker()
        {
            arena.Enroll(this.warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Fight("", this.name));
        }
        [Test]
        public void Arena_ShouldThrowException_WhenPassedInvaliDataForDeffender()
        {
            arena.Enroll(this.warrior1);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(this.name, ""));
        }
        [Test]
        public void Attacker_ShouldAttackDeffender_WhenDataForBothIsValid()
        {
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            int expectedResult = warrior2.HP - warrior1.Damage;
            arena.Fight(name, name2);
            Assert.AreEqual(expectedResult, warrior2.HP);
        }
    }
}
