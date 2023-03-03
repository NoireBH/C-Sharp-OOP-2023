using FakeAxeAndDummy.Models;
using FakeAxeAndDummy.Models.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeAxeAndDummy.Tests
{
    [TestFixture]
    public class HeroTests
    {
        Mock<Itarget> fakeTarget = new Mock<Itarget>();
        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();

        [Test]
        public void HeroGainsXPWhenTargetHpIsZeroOrLower()
        {

            fakeTarget.Setup(t => t.isDead()).Returns(true);
            fakeTarget.Setup(t => t.GiveXP()).Returns(50);
            Hero hero = new Hero(fakeAxe.Object);
            hero.SwingAxe(fakeTarget.Object);

            Assert.AreEqual(50, hero.Xp);
        }
    }
}
