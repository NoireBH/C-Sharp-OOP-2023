using System;
using System.Linq;

namespace _02.BlindMan_sBuff
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            int playerRow = 0;
            int playerCol = 0;
            int movesMade = 0;
            int touchedOpponents = 0;

            int[] rowsAndCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] playground = new string[rows, cols];
            bool foundPlayer = false;
            for (int row = 0; row < playground.GetLength(0); row++)
            {
                string[] rowInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < playground.GetLength(1); col++)
                {
                    playground[row, col] = rowInput[col];

                    if (!foundPlayer)
                    {
                        if (playground[row, col] == "B")
                        {
                            playerRow = row;
                            playerCol = col;
                            foundPlayer = true;
                            playground[row, col] = "-";
                        }
                    }

                }
            }

            string direction;
            while ((direction = Console.ReadLine()) != "Finish" && touchedOpponents != 3)
            {
                if (direction == "up")
                {
                    if (IsInside(playerRow - 1, playerCol, playground))
                    {
                        playerRow--;
                        if (playground[playerRow, playerCol] == "P")
                        {
                            playground[playerRow, playerCol] = "-";
                            movesMade++;
                            touchedOpponents++;

                        }

                        else if (playground[playerRow, playerCol] == "-")
                        {
                            movesMade++;
                        }

                        else if(playground[playerRow, playerCol] == "O")
                        {
                            playerRow++;
                            continue;
                        }

                    }
                }

                else if (direction == "down")
                {
                    if (IsInside(playerRow + 1, playerCol, playground))
                    {
                        playerRow++;
                        if (playground[playerRow, playerCol] == "P")
                        {
                            playground[playerRow, playerCol] = "-";
                            movesMade++;
                            touchedOpponents++;

                        }

                        else if (playground[playerRow, playerCol] == "-")
                        {
                            movesMade++;
                        }

                        else if (playground[playerRow, playerCol] == "O")
                        {
                            playerRow--;
                            continue;
                        }
                    }
                }

                else if (direction == "left")
                {
                    if (IsInside(playerRow, playerCol - 1, playground))
                    {
                        playerCol--;
                        if (playground[playerRow, playerCol] == "P")
                        {
                            playground[playerRow, playerCol] = "-";
                            movesMade++;
                            touchedOpponents++;

                        }

                        else if (playground[playerRow, playerCol] == "-")
                        {
                            movesMade++;
                        }

                        else if (playground[playerRow, playerCol] == "O")
                        {
                            playerCol++;
                            continue;
                        }

                    }
                }

                else if (direction == "right")
                {
                    if (IsInside(playerRow, playerCol + 1, playground))
                    {
                        playerCol++;
                        if (playground[playerRow, playerCol] == "P")
                        {
                            playground[playerRow, playerCol] = "-";
                            movesMade++;
                            touchedOpponents++;

                        }

                        else if (playground[playerRow, playerCol] == "-")
                        {
                            movesMade++;
                        }

                        else if (playground[playerRow, playerCol] == "O")
                        {
                            playerCol--;
                            continue;
                        }
                    }
                }
            }

            Console.WriteLine("Game over!");
            Console.Write($"Touched opponents: {touchedOpponents} Moves made: {movesMade}");

        }

        private static bool IsInside(int row, int col, string[,] playground)
     => row >= 0 && row < playground.GetLength(0) && col >= 0 && col < playground.GetLength(1);
    }
}


