using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;
using INStock.Models;

namespace ProductStock.Tests
{
    [TestFixture]
    public class ProductStockTests
    {
        private INStock.Models.ProductStock defaultProductStock;
        private INStock.Models.Product defaultProduct;

        [SetUp]
        public void SetUp()
        {
            defaultProductStock = new INStock.Models.ProductStock();
            defaultProduct = new INStock.Models.Product("Pill", 5, 10);
            defaultProductStock.Add(defaultProduct);
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
    }
}
