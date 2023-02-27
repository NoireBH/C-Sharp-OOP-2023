using INStock.Contracts;
using MoreLinq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> products;
        public ProductStock()
        {
            products = new List<IProduct>();
        }

        public IProduct this[int index] { get => products[index]; set => products[index] = value; }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (!products.Any(p => p.Label == product.Label))
            {
                products.Add(product);
            }

            else
            {
                throw new InvalidOperationException("A product with the same label is already added!");
            }
        }

        public bool Contains(IProduct product)
        {
            if (products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (index >=0 && index < products.Count)
            {
                return products[index];
            }

            else
            {
                throw new IndexOutOfRangeException("Product with that index doesn't exist!");
            }

            
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            IEnumerable<IProduct> productsWithValidPrice = products.Where(p => p.Price == price);
            return productsWithValidPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            IEnumerable<IProduct> productsWithValidQuantity = products.Where(p => p.Quantity == quantity);
            return productsWithValidQuantity;
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi)
        {
            IEnumerable<IProduct> productsWithValidPrice = products.Where(p => p.Price >= lo && p.Price <= hi);
            return productsWithValidPrice;
        }

        public IProduct FindByLabel(string label)
        {
            IProduct productWithSameLabel = products.FirstOrDefault(p => p.Label == label);

            if (productWithSameLabel == default)
            {
                throw new InvalidOperationException("No products with that label exist!");
            }

            return productWithSameLabel;
        }

        public IProduct FindMostExpensiveProduct()
        {
            decimal highestPrice = 0;
            IProduct mostExpensiveProduct = default;

            foreach (var product in products)
            {
                if (product.Price > highestPrice)
                {
                    highestPrice = product.Price;
                    mostExpensiveProduct = product;
                }
            }

            return mostExpensiveProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public bool Remove(IProduct product)
        {
            if (products.Contains(product))
            {
                products.Remove(product);
                return true;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        
    }
}
