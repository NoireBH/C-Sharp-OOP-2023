namespace INStock
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var defaultProductStock = new INStock.Models.ProductStock();
            var defaultProduct = new INStock.Models.Product("Pill", 3, 10);
            var defaultProduct2 = new INStock.Models.Product("Water", 3, 8);
            var defaultProduct3 = new INStock.Models.Product("Milk", 3, 8);
            defaultProductStock.Add(defaultProduct);
            defaultProductStock.Add(defaultProduct2);
            defaultProductStock.Add(defaultProduct3);
            var products = defaultProductStock.FindAllByPrice(3);
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }
        }
    }
}
