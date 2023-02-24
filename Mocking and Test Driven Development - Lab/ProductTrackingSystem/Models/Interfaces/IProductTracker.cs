using ProductTrackingSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTrackingSystem.Interfaces
{
    public interface IProductTracker
    {   

        void Add(Product product);
        void Contains(Product product);
        int Count();
        Product Find(int index);
        Product FindByLabel(string label);
        List<Product> FindAllPricesInRange(decimal startingPrice, decimal MaxPrice);
        List<Product> FindAllByPrice(decimal price);
        Product FindMostExpensiveProduct();
        List<Product> FindAllByQuantity(int quantity);
        List<Product> GetEnumerator();

        IReadOnlyList<Product> Products { get; }
    }
}
