using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] rowInfo = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = rowInfo[col];                    
                }
            }

            int blackTrufflesCount = 0;
            int summerTrufflesCount = 0;
            int whiteTrifflesCount = 0;
            int boarEatenTriffles = 0;

            string input;
            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] cmd = input.Split();
                string command = cmd[0];
                int row = int.Parse(cmd[1]);
                int col = int.Parse(cmd[2]);

                if (command == "Collect")
                {
                    
                    FindTruffles(territory, ref blackTrufflesCount, ref summerTrufflesCount, ref whiteTrifflesCount, row, col);

                }

                else if (command.StartsWith("Wild"))
                {
                    string direction = cmd[3];

                    if (direction == "up")
                    {
                        while (row >= 0 && row < territory.GetLength(0) && col >= 0 && col < territory.GetLength(0))
                        {
                            boarEatenTriffles = BearCheckTerritory(territory, boarEatenTriffles, row, col);
                            row -= 2;
                        }
                    }

                    else if (direction == "down")
                    {

                        while (row >= 0 && row < territory.GetLength(0) && col >= 0 && col < territory.GetLength(0))
                        {
                            boarEatenTriffles = BearCheckTerritory(territory, boarEatenTriffles, row, col);
                            row += 2;
                        }

                    }

                    else if (direction == "left")
                    {
                        while (row >= 0 && row < territory.GetLength(0) && col >= 0 && col < territory.GetLength(0))
                        {
                            boarEatenTriffles = BearCheckTerritory(territory, boarEatenTriffles, row, col);
                            col -= 2;
                        }
                    }

                    else if (direction == "right")
                    {
                        while (row >= 0 && row < territory.GetLength(0) && col >= 0 && col < territory.GetLength(0))
                        {
                            boarEatenTriffles = BearCheckTerritory(territory, boarEatenTriffles, row, col);
                            col += 2;
                        }
                    }

                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTrufflesCount} black, " +
                $"{summerTrufflesCount} summer, and {whiteTrifflesCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarEatenTriffles} truffles.");

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(territory[r, c] + " ");
                }

                Console.WriteLine();
            }

        }

        private static int BearCheckTerritory(char[,] territory, int boarEatenTriffles, int row, int col)
        {
            if (territory[row, col] == 'B' || territory[row, col] == 'S' || territory[row, col] == 'W')
            {
                territory[row, col] = '-';
                boarEatenTriffles++;
            }

            return boarEatenTriffles;
        }

        private static void FindTruffles(char[,] territory, ref int blackTrufflesCount, ref int summerTrufflesCount, ref int whiteTrifflesCount, int row, int col)
        {
            if (territory[row, col] == 'B')
            {
                territory[row, col] = '-';
                blackTrufflesCount++;
            }

            else if (territory[row, col] == 'S')
            {
                territory[row, col] = '-';
                summerTrufflesCount++;
            }

            else if (territory[row, col] == 'W')
            {
                territory[row, col] = '-';
                whiteTrifflesCount++;
            }
        }

    }
}
