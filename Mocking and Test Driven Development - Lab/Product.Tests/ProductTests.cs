using INStock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using INStock.Models;



namespace Product.Tests
{
    [TestFixture]
    public class ProductTests
    {
        private INStock.Models.Product defaultProduct;

        [SetUp]
        public void SetUp()
        {
            defaultProduct = new INStock.Models.Product("Pill",5,10);
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            var product = new INStock.Models.Product("Bread",2,1);
            Assert.AreEqual("Bread", product.Label);
            Assert.AreEqual(2, product.Price);
            Assert.AreEqual(1, product.Quantity);
        }

        [Test]
        public void PropertiesShouldBeCorrect()
        {
            Assert.AreEqual("Pill", defaultProduct.Label);
            Assert.AreEqual(5, defaultProduct.Price);
            Assert.AreEqual(10, defaultProduct.Quantity);
        }
        
    }
}
