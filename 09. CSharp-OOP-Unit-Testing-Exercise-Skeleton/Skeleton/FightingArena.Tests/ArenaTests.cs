namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior opponent;
        private Warrior weakWarrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new Warrior("Noire", 500, 666);
            opponent = new Warrior("Neptune", 500, 420);
            weakWarrior = new Warrior("Plutia", 10, 10);
            arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(opponent);
            arena.Enroll(weakWarrior);
        }

        [Test]
        public void ConstructorMakesAnArenaWithWarriors()
        {
            List<Warrior> warriorList = new List<Warrior>();
            Arena arena = new Arena();
            arena.Enroll(warrior);
            arena.Enroll(opponent);
            arena.Enroll(weakWarrior);
            warriorList.Add(warrior);
            warriorList.Add(opponent);
            warriorList.Add(weakWarrior);
            CollectionAssert.AreEqual(warriorList, arena.Warriors);
        }

        [Test]
        public void WarriorCountShouldIncreaseWithAddedWarrior()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("Smorc", 10, 10));
            arena.Enroll(new Warrior("Raiden", 60, 100));
            Assert.AreEqual(2, arena.Warriors.Count);
        }

        [Test]
        public void WarriorPropertyReturnsCorrectly()
        {
            List<Warrior> warriorList = new List<Warrior>();
            warriorList.Add(warrior);
            warriorList.Add(opponent);
            warriorList.Add(weakWarrior);
            CollectionAssert.AreEqual(warriorList, arena.Warriors);
        }

        [Test]
        public void ArenaShouldThrowExceptionIfWarriorAddedAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(new Warrior("Neptune", 420, 60));
            });
        }

        [Test]
        public void WarriorCannotAttackNonExistingOpponent()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Neptune", "Blanc");
            });
        }

        [Test]
        public void WarriorAttackingThrowsExceptionIfDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight("Blanc", "Neptune");
            });
        }

        [Test]
        public void FightShouldDecreaseHpOfWarriors()
        {

            int expectedHpFirst = warrior.HP - opponent.Damage;
            int expectedHpSecond = 0;

            arena.Fight(warrior.Name, opponent.Name);
            Assert.IsTrue(warrior.HP == expectedHpFirst && opponent.HP == expectedHpSecond);
        }
    }
}