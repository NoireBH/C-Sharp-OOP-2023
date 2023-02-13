using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public IReadOnlyCollection<Shoe> Shoes => shoes;
        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Count >= StorageCapacity)
            {
                return $"No more space in the storage room.";
            }

            shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int shoesRemoved = 0;
            List<Shoe> shoesToRemove = new List<Shoe>();
            
            foreach (var shoe in Shoes)
            {
                if (shoe.Material == material)
                {   
                    shoesToRemove.Add(shoe);
                    shoesRemoved++;
                }
            }

            foreach (var shoe in shoesToRemove)
            {
                for (int i = 0; i < shoes.Count; i++)
                {
                    if (shoe == shoes[i])
                    {
                        shoes.Remove(shoe);
                    }
                }
            }

            return shoesRemoved;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> neededShoes = new List<Shoe>();

            foreach (var shoe in Shoes)
            {
                if (shoe.Type.ToLower() == type.ToLower())
                {
                    neededShoes.Add(shoe);
                }
            }

            return neededShoes;
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.First(Shoes => Shoes.Size == size);
        }

        public string StockList(double size,string type)
        {
            List<Shoe> stockList = Shoes.Where(s => s.Size == size && s.Type == type).ToList();

            StringBuilder sb = new StringBuilder();

            if (stockList.Count == 0)
            {
                sb.AppendLine("No matches found!");
            }

            else
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe in stockList)
                {
                    sb.AppendLine(shoe.ToString());
                }
            }

            return sb.ToString().TrimEnd();

           
        }
    }
}
