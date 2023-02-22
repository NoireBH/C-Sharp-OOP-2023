namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database defaultDatabase;

        [SetUp]
        public void SetUp()
        {
            defaultDatabase = new Database();
            defaultDatabase.Add(new Person(5, "Gosho"));
            defaultDatabase.Add(new Person(10, "Snake"));
        }

        [Test]
        public void ConstructorShouldInitializeDataWithCorrectCount()
        {
            Person[] people = new Person[5];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i,((char)('a' + i)).ToString());
            }
            Database database = new Database(people);
            int expectedCount = people.Length;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void ConstructorShouldThrowAnExceptionWhenCountIsAbove16()
        {
            
            Assert.Throws<ArgumentException>(() =>
            {
                Person[] people = new Person[17];

                for (int i = 0; i < people.Length; i++)
                {
                    people[i] = new Person(i, ((char)('a' + i)).ToString());
                }
                Database database = new Database(people);

            });
        }

        [Test]
        public void AddIncreasesTheCount()
        {
            defaultDatabase.Add(new Person(7, "Petar"));
            Assert.AreEqual(3, defaultDatabase.Count);
        }

        [Test]
        public void AddShouldAddThePerson()
        {
            var expectedPerson = defaultDatabase.FindByUsername("Gosho");
            string expectedName = expectedPerson.UserName;
            Assert.AreEqual(expectedName, expectedPerson.UserName);
        }


        [Test]
        public void AddThrowsAnExceptionWhenUserWithSameUsernameIsAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.Add(new Person(6, "Gosho"));
            });
        }

        [Test]
        public void AddThrowsAnExceptionWhenUserWithSameIDIsAdded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.Add(new Person(5, "Petar"));
            });
        }

        [Test]
        public void AddCannotExceedMaximumArrayCount()
        {   
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() =>
            {
                Person[] people = new Person[17];

                for (int i = 0; i < people.Length; i++)
                {
                    people[i] = new Person(i, ((char)('a' + i)).ToString());
                    database.Add(people[i]);
                }
                

            });
        }

        [Test]
        public void RemoveDecreasesTheCount()
        {
            defaultDatabase.Remove();
            Assert.AreEqual(1, defaultDatabase.Count);
        }

        [Test]
        public void RemoveRemovesTheLastPerson()
        {
            defaultDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.FindByUsername("Snake");
            });
        }

        [Test]
        public void RemoveThrowsExceptionWhenDatabaseIsEmpty()
        {
            defaultDatabase.Remove();
            defaultDatabase.Remove();
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.Remove();
            });
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfTheUserIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.FindByUsername("MonkaS");
            });
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfTheUserNameIsNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                defaultDatabase.FindByUsername("");
            });
        }

        [Test]
        public void FindByUsernameReturnsTheCorrectPerson()
        {
            var personToFind = defaultDatabase.FindByUsername("Snake");
            Assert.AreEqual(personToFind.UserName, "Snake");
        }

        [Test]
        public void FindByIdThrowsExceptionIfTheUserIsNotFound()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultDatabase.FindById(69);
            });
        }

        [Test]
        public void FindByIDThrowsExceptionIfTheUserIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                defaultDatabase.FindById(-420);
            });
        }

        [Test]
        public void FindByIdReturnsTheCorrectPerson()
        {
            var personToFind = defaultDatabase.FindById(5);
            Assert.AreEqual(personToFind.Id, 5);
        }

       
       
    }
}