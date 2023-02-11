using System;
using System.Linq;

namespace _02._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());
            string[,] track = new string[rowsAndCols, rowsAndCols];
            string racingNumber = Console.ReadLine();

            int kilometersPassed = 0;
            int RaceCarRow = 0;
            int RaceCarCol = 0;

            bool finishedRace = false;

            for (int row = 0; row < track.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < track.GetLength(1); col++)
                {
                    

                    track[row, col] = rowInput[col];
                }
            }
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string direction = input.ToLower();
                
                if (direction == "up")
                {
                    RaceCarRow--;
                }

                else if (direction == "down")
                {
                    RaceCarRow++;
                }

                else if (direction == "left")
                {
                    RaceCarCol--;
                }

                else if (direction == "right")
                {
                    RaceCarCol++;
                }

                if (track[RaceCarRow,RaceCarCol] == "T")
                {
                    kilometersPassed += 30;
                    track[RaceCarRow, RaceCarCol] = ".";
                    bool tunnelPassed = false;

                    for (int r = 0; r < rowsAndCols; r++)
                    {
                        for (int c = 0; c < rowsAndCols; c++)
                        {
                            if (track[r,c] == "T")
                            {
                                track[r, c] = ".";
                                RaceCarRow = r;
                                RaceCarCol = c;
                                tunnelPassed = true;
                                break;
                            }
                        }

                        if (tunnelPassed)
                        {
                            break;
                        }
                    }
                }

                else if (track[RaceCarRow, RaceCarCol] == "F")
                {
                    kilometersPassed += 10;
                    track[RaceCarRow, RaceCarCol] = ".";                    
                    finishedRace = true;
                    break;
                }

                else
                {
                    kilometersPassed += 10;
                }
            }

            track[RaceCarRow, RaceCarCol] = "C";

            if (!finishedRace)
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            else
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }

            Console.WriteLine($"Distance covered {kilometersPassed} km.");

            for (int row = 0; row < rowsAndCols; row++)
            {
                for (int col = 0; col < rowsAndCols; col++)
                {
                    Console.Write(track[row,col]);
                }

                Console.WriteLine();
            }
        }
    }
}
