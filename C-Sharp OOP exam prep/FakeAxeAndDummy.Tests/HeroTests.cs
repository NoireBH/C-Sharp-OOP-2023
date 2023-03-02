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
        Mock<IHero> fakeHero = new Mock<IHero>();
        Mock<Itarget> fakeTarget = new Mock<Itarget>();
        Mock<IWeapon> fakeAxe = new Mock<IWeapon>();

        [Test]
        public void HeroGainsXPWhenTargetHpIsZeroOrLower()
        {
            fakeAxe.Setup(a => a.Damage).Returns(30);

            fakeTarget.Setup(t => t.Hp).Returns(20);
            fakeTarget.Setup(t => t.takeDamage(It.IsAny<int>()));
            fakeTarget.Setup(t => t.XpDrop).Returns(50);
            fakeHero.Setup(h => h.SwingAxe(fakeTarget.Object));
            fakeHero.Object.SwingAxe(fakeTarget.Object);
            Hero hero = new Hero(fakeAxe.Object);
            hero.SwingAxe(fakeTarget.Object);

            Assert.IsTrue(fakeHero.Object.Xp == 50);
        }
    }
}
