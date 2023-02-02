using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection removeCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string[] items = Console.ReadLine().Split();
            int operationsNumber = int.Parse(Console.ReadLine());

            foreach (var item in items)
            {
                Console.Write(addCollection.Add(item) + " ");               
            }

            Console.WriteLine();

            foreach (var item in items)
            {
                Console.Write(removeCollection.Add(item) + " ");         
            }

            Console.WriteLine();

            foreach (var item in items)
            {
                Console.Write(myList.Add(item) + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < operationsNumber; i++)
            {
                Console.Write(removeCollection.Remove() + " ");               
            }

            Console.WriteLine();

            for (int i = 0; i < operationsNumber; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
            
        }
    }
}
