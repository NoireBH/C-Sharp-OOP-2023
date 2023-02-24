using ProductTrackingSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTrackingSystem.Models
{   
    public class ProductTracker : IProductTracker
    {   
        private List<Product> products;

        public IReadOnlyList<Product> Products { get; private set; }

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Contains(Product product)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Product Find(int index)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAllByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindAllPricesInRange(decimal startingPrice, decimal MaxPrice)
        {
            throw new NotImplementedException();
        }

        public Product FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public Product FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
