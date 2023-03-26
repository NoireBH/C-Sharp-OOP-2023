namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook defaultTextBook;
        private UniversityLibrary defaultLibrary;

        [SetUp]
        public void Setup()
        {
            defaultTextBook = new TextBook("Berserk", "Miura", "History");
            defaultLibrary = new UniversityLibrary();

        }

        [Test]
        public void Test1()
        {

            Assert.That(defaultTextBook.Title, Is.EqualTo("Berserk"));
            Assert.That(defaultTextBook.Author, Is.EqualTo("Miura"));
            Assert.That(defaultTextBook.Category, Is.EqualTo("History"));
        }

        [Test]
        public void Test2()
        {
            StringBuilder sb = new StringBuilder();
            var actual = defaultLibrary.AddTextBookToLibrary(defaultTextBook);

            sb.AppendLine($"Book: Berserk - 1");
            sb.AppendLine($"Category: History");
            sb.AppendLine($"Author: Miura");

            var expected = sb.ToString().TrimEnd();

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void Test3()
        {
            defaultLibrary.AddTextBookToLibrary(defaultTextBook);
            Assert.AreEqual(1, defaultTextBook.InventoryNumber);
        }

        [Test]
        public void Test4()
        {
            defaultLibrary.AddTextBookToLibrary(defaultTextBook);
            TextBook textbook = new TextBook("Tokyo Ghoul", "Sui Ishida", "Tragedy");
            defaultLibrary.AddTextBookToLibrary(textbook);
            Assert.AreEqual(2, defaultLibrary.Catalogue.Count);
        }

        [Test]
        public void Test5()
        {
            defaultLibrary.AddTextBookToLibrary(defaultTextBook);
          var actual =  defaultLibrary.LoanTextBook(1, "Gosho");
            var expected = "Berserk loaned to Gosho.";
            Assert.AreEqual("Gosho", defaultTextBook.Holder);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Test6()
        {
            defaultLibrary.AddTextBookToLibrary(defaultTextBook);
            defaultLibrary.LoanTextBook(1, "Gosho");           
            Assert.AreEqual("Gosho still hasn't returned Berserk!", defaultLibrary.LoanTextBook(1, "Gosho"));
        }

        [Test]
        public void Test7()
        {
            defaultLibrary.AddTextBookToLibrary(defaultTextBook);
            TextBook textbook = new TextBook("Tokyo Ghoul", "Sui Ishida", "Tragedy");
            defaultLibrary.AddTextBookToLibrary(textbook);
            defaultLibrary.LoanTextBook(1, "Gosho");
            defaultLibrary.ReturnTextBook(1);
            Assert.AreEqual(string.Empty, defaultTextBook.Holder);
            Assert.AreEqual("Tokyo Ghoul is returned to the library.", defaultLibrary.ReturnTextBook(2));
        }
    }
}