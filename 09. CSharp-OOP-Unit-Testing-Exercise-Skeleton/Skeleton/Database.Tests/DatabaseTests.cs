namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {   
        private Database defaultDatabase;

        [SetUp]
        public void SetUp()
        {
            defaultDatabase = new Database();
        }

        [Test]
        [TestCase(new int[] {})]
        [TestCase(new int[] {1,2,3})]
        [TestCase(new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16})]
        public void ConstructorShouldInitializeDataWithCorrectCount(int[] data)
        {
            Database database = new Database(data);
            int expectedCount = data.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,17 })]
        public void ConstructorShouldThrowAnExceptionWhenCountIsAbove16(int[] data)
        {
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                Database database = new Database(data);
                
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void ConstructorShouldAddElementsIntoData(int[] data)
        {
            Database db = new Database(data);
            int[] expectedData = data;
            int[] actualData = db.Fetch();
            CollectionAssert.AreEqual(expectedData, actualData);
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CountShouldReturnCorrectCount(int[] data)
        {
            Database db = new Database(data);
            int expected = data.Length;
            int actual = db.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AddingElementsShouldIncreaseCount()
        {
            for (int i = 1; i <= 3; i++)
            {
                defaultDatabase.Add(i);
            }

            Assert.AreEqual(3, defaultDatabase.Count);
        }

        [Test]
        public void AddingMoreThan16ElementsShouldThrowAnException()
        {
            for (int i = 1; i <= 16; i++)
            {
                defaultDatabase.Add(i);
            }

            
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.Add(1);
            });
        }

        [Test]
        public void RemovingAnElementShouldDecreaseCount()
        {
            for (int i = 1; i <= 3; i++)
            {
                defaultDatabase.Add(i);
            }

            defaultDatabase.Remove();
            defaultDatabase.Remove();

            Assert.AreEqual(1, defaultDatabase.Count);
        }

        [Test]
        public void TryingToRemoveAnElementFromAnEmptyDatabaseShouldThrowAnException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.Remove();
            });
            
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void FetchShouldReturnTheElementsInTheArray(int[] data)
        {
            Database database = new Database(data);
            int[] expectedArray = data;
            int[] actualArray = database.Fetch();
            CollectionAssert.AreEqual(expectedArray, actualArray);
        }


    }
}
