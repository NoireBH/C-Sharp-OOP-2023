namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {   
        private Warrior warrior;
        private Warrior opponent;
        private Warrior weakWarrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Noire", 500, 666);
            opponent = new Warrior("Neptune", 500, 444);
            weakWarrior = new Warrior("Plutia", 10, 10);
        }
        [Test]
        public void WarriorConstructorShouldInitializeCorrectly()
        {
            string expectedName = "Illidan";
            int damage = 100;
            int hp = 100;
            Warrior warrior = new Warrior(expectedName, damage, hp);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void WarriorNameShouldThrowExceptionIfItIsNullEmptyOrWhitespace(string name)
        {
            Assert.Throws<ArgumentException>(() => 
            {
                Warrior warrior = new Warrior(name, 100, 100);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorDamageThrowsExceptionIfZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("DaVinki", damage, 100);
            });
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        public void WarriorHpThrowsExceptionIfNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("DaVinki", 100, hp);
            });
        }

        [Test]
        public void WarriorCannotAttackIfHpIsBelow30()
        {
            Assert.Throws<InvalidOperationException>(() => 
            {
                weakWarrior.Attack(warrior);
            });
            
        }

        [Test]
        public void WarriorCannotAttackWarriorsWhoseHpAreBelow30()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                warrior.Attack(weakWarrior);
            });
        }

        [Test]
        public void WarriorCannotAttackStrongerWarriors()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                opponent.Attack(warrior);
            });
        }

        [Test]
        public void AttackShouldDecreaseBothWarriorAndOpponentHp()
        {
            int expectedHp = warrior.HP - opponent.Damage;
            int expectedOpponentHp = 0;

            warrior.Attack(opponent);
            Assert.IsTrue(warrior.HP == expectedHp && opponent.HP == expectedOpponentHp);
        }
    }
}