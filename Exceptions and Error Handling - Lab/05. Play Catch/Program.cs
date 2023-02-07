using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split()
                .Select(int.Parse).ToList();

            int exceptionCount = 0;

            while (exceptionCount != 3)
            {
                string[] cmdInfo = Console.ReadLine().Split();

               try
                {
                    string command = cmdInfo[0];
                    int index = int.Parse(cmdInfo[1]);

                    if (command == "Replace")
                    {
                        ValidateIndexes(index, index, numbers);

                        int element = int.Parse(cmdInfo[2]);
                        numbers[index] = element;
                    }

                    else if (command == "Print")
                    {
                        int endIndex = int.Parse(cmdInfo[2]);
                        int[] tempArray = new int[endIndex];

                        ValidateIndexes(index, endIndex, numbers);
                        int tempIndex = 0;
                        for (int i = index; i <= endIndex; i++)
                        {
                            tempArray[tempIndex] = numbers[i];
                            tempIndex++;
                        }

                        Console.WriteLine(String.Join(", ", tempArray));
                    }

                    else if (command == "Show")
                    {
                        ValidateIndexes(index, index, numbers);
                        Console.WriteLine(numbers[index]);
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                    exceptionCount++;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionCount++;
                }              
            }

            Console.WriteLine(String.Join(", ", numbers));
        }

        public static bool ValidateIndexes(int index1, int index2, List<int> numbers)
        {
            if (index1 < 0 || index2 >= numbers.Count)
            {
                throw new IndexOutOfRangeException("The index does not exist!");
            }       

            return false;
            
        }
    }
}
