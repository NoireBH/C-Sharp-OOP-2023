using System;
using System.Linq;

namespace Array.diff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SpinWords("Spin this Sentence")); 
        }

        public static string SpinWords(string sentence)
        {
            string[] words = sentence.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length >= 5)
                {
                    string reversed = new string(words[i].Reverse().ToArray());
                    words[i] = reversed;

                }
            }

            return string.Join(" ", words);
        }
    }


}
