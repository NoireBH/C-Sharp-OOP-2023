using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Climb_The_Peaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var conqueredPeaks = new Queue<string>();

            var foodSupplies = new Stack<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());
            var stamina = new Queue<int>(Console.ReadLine()
                .Split(", ").Select(int.Parse).ToArray());

            var peaks = new Dictionary<string, int>()
            {
                { "Vihren", 80},
                { "Kutelo", 90},
                { "Banski Suhodol", 100},
                { "Polezhan", 60},
                { "Kamenitza", 70}
            };

            var peakNames = new Queue<string>();
            foreach (var peak in peaks)
            {
                peakNames.Enqueue(peak.Key);
            }

            int currentDay = 0;

            while (currentDay <= 7 && stamina.Count > 0 && peakNames.Count > 0)
            {
                int currentResourceSum = foodSupplies.Pop() + stamina.Dequeue();
                int currentPeakValue = peaks[peakNames.Peek()];

                if (currentResourceSum >= currentPeakValue)
                {
                    conqueredPeaks.Enqueue(peakNames.Dequeue());                 
                }

                currentDay++;
            }

            if (peakNames.Count == 0)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week" +
                    " -> @FIVEinAWEEK");
               
            }

            else if(peakNames.Count > 0 || currentDay == 7)
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time" +
                    " -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(String.Join(Environment.NewLine, conqueredPeaks));
            }

        }
    }
}
