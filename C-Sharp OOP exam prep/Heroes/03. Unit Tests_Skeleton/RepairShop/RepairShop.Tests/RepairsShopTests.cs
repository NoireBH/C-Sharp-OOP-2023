using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    [TestFixture]
    public class Tests
    {

        public class RepairsShopTests
        {
            private Car car;
            private Car car2;
            private Garage garage;

            [SetUp]
            public void SetUp()
            {
                car = new Car("Porsche", 1);
                car2 = new Car("BMW", 2);
                garage = new Garage("Garage", 3);
                garage.AddCar(car);
                garage.AddCar(car2);

            }

            [Test]
            public void ConstructorShouldWorkProperly()
            {
                Garage garage = new Garage("NewGarage", 2);
                var expectedName = "NewGarage";
                var expectedMechanics = 2;
                var expectedCarCount = 2;
                Car car = new Car("1", 1);
                Car car2 = new Car("2", 1);
                garage.AddCar(car);
                garage.AddCar(car2);

                Assert.AreEqual(expectedName, garage.Name);
                Assert.AreEqual(expectedMechanics, garage.MechanicsAvailable);
                Assert.AreEqual(expectedCarCount, garage.CarsInGarage);
            }

            [Test]
            public void NameThrowsExceptionIfNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage("", 2);
                });
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 2);
                });
            }

            [Test]
            public void MechanicAvalableThrowsExceptionIfValueIsLessOrEqualToZero()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("A", 0);
                });
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("B", -1);
                });
            }

            [Test]
            public void CarsInGarageReturnsCountOfCars()
            {
                var expected = 2;
                var actual = garage.CarsInGarage;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void AddCarWorksProperly()
            {
                garage.AddCar(new Car("F", 2));
                var expected = 3;
                var actual = garage.CarsInGarage;
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void AddCarThrowsExceptionIfCarCountEqualsMechanicsAvalable()
            {
                garage.AddCar(new Car("F", 2));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.AddCar(new Car("X", 1));
                });
            }

            [Test]
            public void FixCarSetsTheNumberOfIssuesToZero()
            {
                garage.FixCar("BMW");
                var expected = 0;
                var actual = garage.FixCar("BMW").NumberOfIssues;
                var isFixedExpected = true;
                var isFixedActual = garage.FixCar("BMW").IsFixed;

                Assert.AreEqual(expected, actual);
                Assert.AreEqual(isFixedExpected, isFixedActual);
            }

            [Test]
            public void FixCarThrowsExceptionIfCarDoesNotExist()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.FixCar("Ferrari");
                });
            }

            [Test]
            public void RemoveFixedCarsWorksProperly()
            {
                garage.FixCar("Porsche");
                garage.FixCar("BMW");
                var expected = 2;
                var actual = garage.RemoveFixedCar();
                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void RemoveFixedCarsThrowsExceptionIfListIsEmpty()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    garage.RemoveFixedCar();
                });
            }

            [Test]
            public void ReportReportsInfoAboutCars()
            {   
                
                string expectedreport = $"There are 2 which are not fixed: Porsche, BMW.";
                string actualReport = garage.Report();

                Assert.AreEqual(expectedreport, actualReport);
            }
        }
    }
}