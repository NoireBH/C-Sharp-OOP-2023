using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartPhone;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            smartPhone = new Smartphone("Samsung", 3000);
            shop = new Shop(3);
            shop.Add(smartPhone);
        }

        [Test]
        public void SmartPhoneConstructorShouldWorkCorrectly()
        {
            Smartphone smartPhone = new Smartphone("Redmi", 4000);
            Assert.AreEqual("Redmi", smartPhone.ModelName);
            Assert.AreEqual(4000, smartPhone.MaximumBatteryCharge);
        }

        [Test]
        public void ShopConstructorShouldWorkCorrectly()
        {
            Shop shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);
        }

        [Test]
        public void CapacityThrowsExceptionIfValueIsLessThanZero()
        {

            Assert.Throws<ArgumentException>((() =>
            {
                Shop shop = new Shop(-1);
            }));
        }

        [Test]
        public void CountReturnsThePhoneCount()
        {
            Smartphone smartPhone2 = new Smartphone("Nokia", 1000);
            shop.Add(smartPhone2);
            var expected = 2;
            var actual = shop.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddThrowsExceptionIfModelAlreadyExists()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.Add(new Smartphone("Samsung", 3000));
            }));
        }

        [Test]
        public void AddThrowsExceptionIfCapacityEqualsTheCount()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.Add(new Smartphone("Galaxy", 3000));
                shop.Add(new Smartphone("VodaPhone", 3000));
                shop.Add(new Smartphone("IPhone", 3000));
            }));
        }

        [Test]
        public void AddIncreasesTheCount()
        {
            shop.Add(new Smartphone("Galaxy", 3000));
            shop.Add(new Smartphone("VodaPhone", 3000));

            var expected = 3;
            var actual = shop.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveThrowsExceptionIfPhoneDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.Remove("BrickPhone");
            }));
        }

        [Test]
        public void RemoveDecreasesTheCount()
        {
            shop.Remove("Samsung");
            var expected = 0;
            var actual = shop.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveRemovesPhoneFromShop()
        {
            shop.Remove("Samsung");

            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.Remove("Samsung");
            }));
        }

        [Test]
        public void TestPhoneThrowsExceptionIfModelDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.TestPhone("BrickPhone",10);
            }));
        }

        [Test]
        public void TestPhoneThrowsExceptionIfCurrentBatteryIsLessThanBatteryUsage()
        {
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.TestPhone("Samsung", 3001);
            }));
        }

        [Test]
        public void TestPhoneDecreasesCurrentBatteryCharge()
        {
            shop.TestPhone("Samsung", 100);
            var expected = 2900;
            var actual = smartPhone.CurrentBateryCharge;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChargePhoneThrowsExceptionWhenModelDoesNotExist()
        {           
            Assert.Throws<InvalidOperationException>((() =>
            {
                shop.ChargePhone("BrickPhone");
            }));
        }

        [Test]
        public void ChargePhoneShouldChargeTheBatteryToMax()
        {
            shop.TestPhone(smartPhone.ModelName, 500);
            var expected = 3000;

            shop.ChargePhone(smartPhone.ModelName);
            var actual = smartPhone.CurrentBateryCharge;

            Assert.AreEqual(expected, actual);
        }
    }
}