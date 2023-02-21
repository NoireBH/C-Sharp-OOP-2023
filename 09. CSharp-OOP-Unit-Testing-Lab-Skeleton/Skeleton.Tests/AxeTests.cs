using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;
        private int attackPoints;
        private int durabilityPoints;

        [SetUp]
        public void SetUp()
        {
            attackPoints = 10;
            durabilityPoints = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(1, 1);
        }

        [Test]
        public void Test1AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);
            Assert.AreEqual(9, axe.DurabilityPoints, "Axe durability doesn't change after attack.");
        }
        [Test]
        public void Test2AttackingWithABrokenWeaponThrowsException()
        {
            axe = new Axe(10, 0);
            Assert.Throws<InvalidOperationException>((() =>
            {                
                axe.Attack(dummy);
            }));

        }

        
    }
}