using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;
using INStock.Models;
using System.Linq;

namespace ProductStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private INStock.Models.ProductStock defaultProductStock;
        private INStock.Models.Product defaultProduct;
        private INStock.Models.Product defaultProduct2;
        private INStock.Models.Product defaultProduct3;

        [SetUp]
        public void SetUp()
        {
            defaultProductStock = new INStock.Models.ProductStock();
            defaultProduct = new INStock.Models.Product("Pill", 5, 10);
            defaultProduct2 = new INStock.Models.Product("Water", 3, 8);
            defaultProduct3 = new INStock.Models.Product("Milk", 3, 8);
            defaultProductStock.Add(defaultProduct);
            defaultProductStock.Add(defaultProduct2);
            defaultProductStock.Add(defaultProduct3);
        }

        [Test]
        public void CountShouldReturnCorrectCountOfProducts()
        {
            Assert.AreEqual(1, defaultProductStock.Count);
        }

        [Test]
        public void AddShouldIncreaseTheCount()
        {
            defaultProductStock.Add(new INStock.Models.Product("Bread", 2, 3));
            Assert.AreEqual(2, defaultProductStock.Count);
        }

        [Test]
        public void AddThrowsExceptionIfProductWithSameLabelIsAdded()
        {
            var invalidProduct = new INStock.Models.Product("Pill", 9, 11);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defaultProductStock.Add(invalidProduct);
            });
        }

        [Test] 
        public void ContainsReturnsTrueIfProductIsInStock()
        {
            var productToReturn = defaultProductStock.First(p => p.Label == "Pill");
            Assert.IsTrue(defaultProductStock.Contains(productToReturn));
        }

        [Test]
        public void ContainsReturnsFalseIfProductIsNotInStock()
        {
            var productToReturn = defaultProductStock.FirstOrDefault(p => p.Label == "Bill");
            Assert.IsFalse(defaultProductStock.Contains(productToReturn));
        }

        [Test]
        public void FindReturnsCorrectly()
        {
            var expected = defaultProductStock.Find(1);
            Assert.AreSame(expected, defaultProductStock[1]);
        }

        [Test]
        public void FindThowsExceptionIfIndexIsOutOfRange()
        {
            Assert.Throws<IndexOutOfRangeException>(() => defaultProductStock.Find(2));
        }

        [Test]
        public void FindAllByPriceReturnsAListCorrectly()
        {   
            var testProductStock = new INStock.Models.ProductStock();
            var testProduct1 = new INStock.Models.Product("Pill", 5, 10);
           var testProduct2 = new INStock.Models.Product("Bread", 7, 10);
           var testProduct3 = new INStock.Models.Product("Milk", 3, 8);
           var testProduct4 = new INStock.Models.Product("Water", 3, 8);
            testProductStock.Add(testProduct1);
            testProductStock.Add(testProduct2);
            testProductStock.Add(testProduct3);
            testProductStock.Add(testProduct4);
            var expected = testProductStock.FindAllByPrice(3).ToList();
            var actual = defaultProductStock.FindAllByPrice(3).ToList();
            Assert.AreEqual(expected[1].Price, actual[0].Price);

        }

        [Test]
        public void FindAllByQuantityReturnsAListCorrectly()
        {
            var testProductStock = new INStock.Models.ProductStock();
            var testProduct1 = new INStock.Models.Product("Pill", 5, 10);
            var testProduct2 = new INStock.Models.Product("Bread", 7, 10);
            var testProduct3 = new INStock.Models.Product("Milk", 3, 8);
            var testProduct4 = new INStock.Models.Product("Water", 3, 8);
            testProductStock.Add(testProduct1);
            testProductStock.Add(testProduct2);
            testProductStock.Add(testProduct3);
            testProductStock.Add(testProduct4);
            var expected = testProductStock.FindAllByQuantity(8).ToList();
            var actual = defaultProductStock.FindAllByQuantity(8).ToList();
            Assert.AreEqual(expected[1].Quantity, actual[0].Quantity);

        }

        [Test]
        public void FindAllPriceInRangeReturnsAListCorrectly()
        {
            var testProductStock = new INStock.Models.ProductStock();
            var testProduct1 = new INStock.Models.Product("Pill", 5, 10);
            var testProduct2 = new INStock.Models.Product("Bread", 7, 10);
            var testProduct3 = new INStock.Models.Product("Milk", 3, 8);
            var testProduct4 = new INStock.Models.Product("Water", 3, 8);
            testProductStock.Add(testProduct1);
            testProductStock.Add(testProduct2);
            testProductStock.Add(testProduct3);
            testProductStock.Add(testProduct4);
            var expected = testProductStock.FindAllInPriceRange(4,7).ToList();
            var actual = defaultProductStock.FindAllInPriceRange(4,7).ToList();
            bool isTrue = false;
            if (expected.All(p => p.Price >= 4 && p.Price <= 7) && actual.All(p => p.Price >= 4 && p.Price <= 7))
            {
                isTrue = true;
            }

            Assert.IsTrue(isTrue);

        }
    }
}
