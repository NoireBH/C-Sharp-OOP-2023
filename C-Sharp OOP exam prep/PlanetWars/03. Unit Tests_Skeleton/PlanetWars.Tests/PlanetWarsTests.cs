using NUnit.Framework;
using System;
using System.Linq;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]


        public class PlanetWarsTests
        {
            private Planet planet;
            private Weapon weapon;

            [SetUp]
            public void SetUp()
            {
                planet = new Planet("Venus", 1000);
                weapon = new Weapon("Excalibur", 2, 10);
                planet.AddWeapon(weapon);
            }

            [Test]
            public void WeaponConstructorWorksProperly()
            {
                Weapon weapon = new Weapon("Excalibur", 2, 50);
                var expName = "Excalibur";
                var expPrice = 2;
                var expDestLevel = 50;

                Assert.AreEqual(expName, weapon.Name);
                Assert.AreEqual(expPrice, weapon.Price);
                Assert.AreEqual(expDestLevel, weapon.DestructionLevel);
            }

            [Test]
            public void PriceThrowsExceptionIfValueIsNegative()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("Excalibur", -1, 50);
                });
            }

            [Test]
            public void IncreaseDestructionLevelWorksProperly()
            {
                Weapon weapon = new Weapon("Excalibur", 2, 50);
                var expDestLevel = 53;
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                weapon.IncreaseDestructionLevel();
                Assert.AreEqual(expDestLevel, weapon.DestructionLevel);
            }

            [Test]
            public void IsNuclearIsTrueIfDestructionLevelIsTenOrMore()
            {
                Weapon weapon = new Weapon("Excalibur", 2, 10);
                Weapon weapon2 = new Weapon("Rho Aias", 2, 9);
                Assert.IsTrue(weapon.IsNuclear);
                Assert.False(weapon2.IsNuclear);
            }

            [Test]
            public void PlanetConstructorWorksProperly()
            {
                Planet planet = new Planet("Venus", 1000);
                var expName = "Venus";
                var expBudget = 1000;
                var expWeaponCount = 0;

                Assert.AreEqual(expName, planet.Name);
                Assert.AreEqual(expBudget, planet.Budget);
                Assert.AreEqual(expWeaponCount, planet.Weapons.Count);
            }

            [Test]
            public void NameThowsExceptionIfNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", 1000);
                });
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 1000);
                });
            }

            [Test]
            public void BudgetThowsExceptionIfLessThanZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", -1);
                });

            }

            [Test]
            public void AddWEaponWorksCorrectly()
            {
                Weapon weapon = new Weapon("Ak-47", 2900, 100);
                Weapon weapon2 = new Weapon("MK", 3100, 90);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                var expected = 3;
                var actual = planet.Weapons.Count;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void AddWEaponThrowsExceptionIfWeaponIsAlreadyAdded()
            {
                Weapon weapon = new Weapon("Ak-47", 2900, 100);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.AddWeapon(weapon);
                });
                
            }

            [Test]
            public void MilitaryPowerRatioShouldBeCorrect()
            {
                Weapon weapon = new Weapon("Ak-47", 2900, 100);
                Weapon weapon2 = new Weapon("MK", 3100, 90);
                planet.AddWeapon(weapon);
                planet.AddWeapon(weapon2);
                var expected = 200;
                var actual = planet.MilitaryPowerRatio;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void ProfitIncreasesTheBudget()
            {
                Planet planet = new Planet("Venus", 1000);
                planet.Profit(100);
                var expected = 1100;
                var actual = planet.Budget;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void SpendFundsDecreasesTheBudget()
            {
                planet.SpendFunds(100);
                var expected = 900;
                var actual = planet.Budget;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void SpendFundsThrowsExceptionIfAmountIsMoreThanBudget()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.SpendFunds(1100);
                });
            }

            [Test]
            public void RemoveWeaponWorksCorrectly()
            {
                planet.RemoveWeapon("Excalibur");
                Assert.AreEqual(0, planet.Weapons.Count);

            }

            [Test]
            public void UpgradeWeaponWorksCorrectly()
            {
                planet.UpgradeWeapon("Excalibur");
                var expected = 11;
                var actual = planet.Weapons.FirstOrDefault(w => w.Name == "Excalibur").DestructionLevel;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void IncreaseDestructionLevelThrowsExceptionIfWeaponNameDoesNotExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.UpgradeWeapon("Enuma Eish");
                });
                
            }

            [Test]
            public void DestructOpponentShouldWorkCorrectly()
            {
                Planet planet2 = new Planet("Orion", 100);
                planet2.AddWeapon(new Weapon("Rule Breaker", 50, 5));
                
                var expected = $"{planet2.Name} is destructed!";
                var actual = planet.DestructOpponent(planet2);
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void DestructOpponentThrowsExceptionIfMilitaryPowerIsLessThanOpponent()
            {
                Planet planet2 = new Planet("Orion", 100);
                planet2.AddWeapon(new Weapon("Rule Breaker", 50, 1000));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    planet.DestructOpponent(planet2);
                });

                
                
            }
        }
    }
}
