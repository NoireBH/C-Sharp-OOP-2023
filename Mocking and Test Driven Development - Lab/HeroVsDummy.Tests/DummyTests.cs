using HeroVsDummy.Contracts;
using HeroVsDummy.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroVsDummy.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            dummy = new Dummy(100,30);
        }

        [Test]

        public void ConstructorShouldInitializeProperly()
        {
            Dummy testDummy = new Dummy(70,20);
            Assert.AreEqual(70, testDummy.HP);
            Assert.AreEqual(20, testDummy.Armour);
        }

        [Test]
        public void PropertiesShouldBeInitialized()
        {
            Assert.AreEqual(100, dummy.HP);
            Assert.AreEqual(30, dummy.Armour);
        }

        [Test]
        [TestCase(40)]
        [TestCase(50)]
        [TestCase(99)]
        public void TakeDamageShouldReduceHPIfDamageIsMoreThanZero(int damage)
        {
            int expected = dummy.HP - (damage - dummy.Armour / 2);

            dummy.TakeDamage(damage);
            
            int actual = dummy.HP;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(-10)]
        [TestCase(1)]
        [TestCase(10)]
        public void TakeDamageShouldNotReduceHPIfDamageIsZeroOrLess(int damage)
        {
            int expected = dummy.HP;

            dummy.TakeDamage(damage);

            int actual = dummy.HP;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(115)]
        [TestCase(500)]
        [TestCase(1000)]
        public void TakeDamageShouldStopTheProgramIfDummyHpIsZeroOrBelow(int damage)
        {
            int expected = 0;

            dummy.TakeDamage(damage);

            int actual = dummy.HP;
            Assert.AreEqual(expected, actual);
        }
    }
}

