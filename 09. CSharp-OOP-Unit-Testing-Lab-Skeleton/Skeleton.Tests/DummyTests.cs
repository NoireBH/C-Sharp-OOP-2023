using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private int health;
        private int exp;
        [SetUp]
        public void SetUp()
        {
            health = 1;
            exp = 2;
            dummy = new Dummy(health,exp);
            deadDummy = new Dummy(-10,exp);
        }

        [Test]
        public void DummyShouldLoseHealtIfAttacked()
        {
            dummy.TakeAttack(1);
            Assert.AreEqual(0, dummy.Health);
        }

        [Test]
        public void DummyThrowsExceptionIfAttackedWhenDead()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                deadDummy.TakeAttack(1);
            }));
        }

        [Test]
        public void DummyGivesExpWhenDead()
        {
           int givenExp = deadDummy.GiveExperience();
            Assert.AreEqual(exp, givenExp);
        }

        [Test]
        public void DummyShouldNotGiveExpWhenAlive()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                dummy.GiveExperience();
            }));
        }
    }
}