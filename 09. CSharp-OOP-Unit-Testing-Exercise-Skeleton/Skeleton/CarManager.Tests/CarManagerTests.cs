namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new Car("Toyota", "Corolla", 5, 100);
        }

        [Test]
        public void ConstructorShouldMakeACarWithNoStartingFuelAmount()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void ConstructorMakeIsInitializedCorrectly()
        {
            string make = "Toyota";
            Assert.AreEqual(make, car.Make);
        }

        [Test]
        public void ConstructormodelIsInitializedCorrectly()
        {
            string model = "Corolla";
            Assert.AreEqual(model, car.Model);
        }

        [Test]
        public void ConstructorFuelConsumptionIsInitializedCorrectly()
        {
            double fuelConsumption = 5;
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void ConstructorFuelCapacityIsInitializedCorrectly()
        {
            double fuelCapacity = 100;
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void MakeThrowsExceptionIfEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("", "Corolla", 5, 100);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(null, "Corolla", 5, 100);
            });

        }

        [Test]
        public void ModelThrowsExceptionIfEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "", 5, 100);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", null, 5, 100);
            });
        }

        [Test]
        public void FuelConsumptionThrowsExceptionIf_0_OrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Corolla", 0, 100);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Corolla", -5, 100);
            });
        }

        [Test]
        public void FuelCapacityThrowsExceptionIf_0_OrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Corolla", 5, 0);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Toyota", "Corolla", 5, -5);
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(20)]
        [TestCase(100)]
        public void RefuelBelowCapacityShouldIncreaseFuelAmount(double fuelAmount)
        {
            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [Test]
        public void RefuelShouldNotAddFuelIfFuelCapacityIsReached()
        {
            car.Refuel(100);
            car.Refuel(20);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void RefuelShouldThrowExceptionIfFuelAmountIsZeroOrNegative(double fuelAmount)
        {

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuelAmount);
            });
        }

        [Test]
        [TestCase(300)]
        [TestCase(500)]
        public void DriveShouldThrowExceptionIfFuelNeededIsMoreThanTheFuelAmount(double distance)
        {
            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            });
        }

        [Test]
        [TestCase(100)]
        [TestCase(500)]
        [TestCase(800)]
        public void DriveShouldDecreaseFuelAmount(double distance)
        {
            car.Refuel(distance);           
            double fuelNeeded = distance / 100 * car.FuelConsumption;
            double expectedFuelAmount = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, car.FuelAmount);
        }
    }
}