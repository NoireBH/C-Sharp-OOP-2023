using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        [SetUp]
        public void Setup()
        {
            factory =  new Factory("DishFactory", 2);
        }

        [Test]
        public void ConstructorWorksProperly()
        {
            Factory factory = new Factory("RobotFactory", 2);
            Assert.AreEqual("RobotFactory", factory.Name);
            Assert.AreEqual(2, factory.Capacity);
            Assert.IsNotNull(factory.Robots);
            Assert.IsNotNull(factory.Supplements);
        }

        [Test]
        public void ListOfRobotsAndSupplementsIsInitialized()
        {
            Factory factory = new Factory("RobotFactory", 2);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
        }

        [Test]
        public void ProduceRobotsReturnsCorrectly()
        {
            Robot robot = new Robot("A", 2, 300);
            var expected = $"Produced --> {robot}";
            Assert.AreEqual(expected, factory.ProduceRobot("A", 2, 300));
        }

        [Test]
        public void ProduceRobotReturnsCorrectlyWhenUnableToProduceMoreRobots()
        {
            var expected = $"The factory is unable to produce more robots for this production day!";
            factory.ProduceRobot("A", 2, 300);
            factory.ProduceRobot("B", 2, 350);
            Assert.AreEqual(expected, factory.ProduceRobot("C", 2, 350));
        }

        [Test]
        public void ProduceSupplementWorksCorrectly()
        {
            var expected = $"Supplement: A IS: 300";
            Assert.AreEqual(expected, factory.ProduceSupplement("A", 300));
            Assert.AreEqual(1, factory.Supplements.Count);

        }

        [Test]
        public void UpgradeRobotRetutnsFalseBecauseRobotContainsSupplement()
        {
            Robot robot = new Robot("A", 2, 300);
            Supplement supplement = new Supplement("B", 300);
            robot.Supplements.Add(supplement);
            Factory factory = new Factory("X", 3);
            factory.ProduceRobot("A", 2, 300);
            
            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UpgradeRobotReturnsFalseBecauseItDoesNotHaveTheSameInterfaceStandard()
        {
            Robot robot = new Robot("A", 2, 180);
            Supplement supplement = new Supplement("B", 300);
            Supplement supplement2 = new Supplement("C", 250);
            robot.Supplements.Add(supplement2);
            Factory factory = new Factory("X", 3);
            factory.ProduceRobot("A", 2, 300);

            Assert.IsFalse(factory.UpgradeRobot(robot, supplement));
        }

        [Test]
        public void UpgradeRobotReturnsTrue()
        {
            Robot robot = new Robot("A", 2, 300);
            Supplement supplement = new Supplement("B", 300);
            Supplement supplement2 = new Supplement("B", 300);
            robot.Supplements.Add(supplement2);
            Factory factory = new Factory("X", 3);
            factory.ProduceRobot("A", 2, 300);

            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
            Assert.IsTrue(robot.Supplements.Contains(supplement));
            Assert.AreEqual(2, robot.Supplements.Count);
        }

        [Test]
        public void SellRobotWorksCorrectly()
        {
            Robot robot = new Robot("A", 1, 300);
            Robot robot2 = new Robot("A", 2, 300);
            Robot robot3 = new Robot("A", 3, 300);
            Factory factory = new Factory("X", 5);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Assert.AreEqual(robot3, factory.SellRobot(5));
        }

        [Test]
        public void SellRobotReturnsNull()
        {
            Robot robot = new Robot("A", 2, 300);
            Robot robot2 = new Robot("A", 3, 300);
            Robot robot3 = new Robot("A", 4, 300);
            Factory factory = new Factory("X", 5);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Assert.AreEqual(null, factory.SellRobot(1));
        }
    }
}