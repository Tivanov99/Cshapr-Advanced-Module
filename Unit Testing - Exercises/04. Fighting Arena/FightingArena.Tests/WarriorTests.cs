using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior1;
        private string name1 = "trix";
        private int dmg1 = 20;
        private int hp1 = 50;
        private Warrior warrior2;
        private string name2 = "mrix";
        private int dmg2 = 15;
        private int hp2 = 60;

        [Test]
        public void Ctor_ShouldCorrectlySetValues()
        {
            warrior1 = new Warrior(name2, dmg2, hp2);
            Assert.AreEqual(this.name2, warrior1.Name);
            Assert.AreEqual(this.dmg2, this.warrior1.Damage);
            Assert.AreEqual(this.hp2, this.warrior1.HP);
        }
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WarriorShould_ThrowException_WhenPassedInvalidDataForName(string name)
        {
            Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(name, this.dmg2, this.hp2));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorShould_ThrowException_WhenPassedInvalidDataForDamage(int damage)
        {
            Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(this.name2, damage, this.hp2));
        }
        [Test]
        [TestCase(-1)]
        public void WarriorShould_ThrowException_WhenPassedInvalidDataForHealth(int health)
        {
            Assert.Throws<ArgumentException>(() => warrior1 = new Warrior(this.name2, this.dmg2, health));
        }
        [Test]
        [TestCase(29)]
        [TestCase(30)]
        public void Warrior_ShouldThrowException_WhenAttackAndHisHealthISLessOrEqualTo30(int health)
        {
            warrior1 = new Warrior(this.name1, this.dmg1, health);
            warrior2 = new Warrior(this.name2, this.dmg2, this.hp2);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
        [Test]
        [TestCase(29)]
        [TestCase(30)]
        public void Warrior_ShouldThrowException_WhenEnemyHealthISLessOrEqualTo30(int health)
        {
            warrior1 = new Warrior(this.name1, this.dmg1, this.hp1);
            warrior2 = new Warrior(this.name2, this.dmg2, health);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
        [Test]
        [TestCase(51)]
        public void Warrior_ShouldThrowException_WhenAttackAndHisHealthISLessThanAttackedWarriorDMG(int damage)
        {
            warrior1 = new Warrior(this.name1, this.dmg1, this.hp1);
            warrior2 = new Warrior(this.name2, damage, this.hp2);
            Assert.Throws<InvalidOperationException>(() => warrior1.Attack(warrior2));
        }
        [Test]
        public void Attacker_ShouldDecreaseHisHealthWithDamageOfEnemy()
        {
            warrior1 = new Warrior(this.name1, this.dmg1, this.hp1);
            warrior2 = new Warrior(this.name2, this.dmg2, this.hp2);
            int ExpectedHpOfAttacker = warrior1.HP - warrior2.Damage;
            warrior1.Attack(warrior2);
            Assert.AreEqual(ExpectedHpOfAttacker, warrior1.HP);
        }
        [Test]
        public void AttackedWarriorHealth_ShouldSetToZero_WhenAttackerDamageValueIsBiggest()
        {
            int Damage = dmg1 + 41;
            warrior1 = new Warrior(this.name1, Damage, this.hp1);
            warrior2 = new Warrior(this.name2, this.dmg2, this.hp2);
            warrior1.Attack(warrior2);
            int ExpectedHpOfAttackedWarr = 0;
            Assert.AreEqual(ExpectedHpOfAttackedWarr, warrior2.HP);
        }
        [Test]
        public void AttackedWarrior_ShouldDecreaseHisHealthWithDamageOfAttacker()
        {
            warrior1 = new Warrior(this.name1, this.dmg1, this.hp1);
            warrior2 = new Warrior(this.name2, this.dmg2, this.hp2);
            int ExpectedHpOfAttackedWarr =  warrior2.HP-warrior1.Damage;
            warrior1.Attack(warrior2);
            Assert.AreEqual(ExpectedHpOfAttackedWarr, warrior2.HP);
        }
    }
}