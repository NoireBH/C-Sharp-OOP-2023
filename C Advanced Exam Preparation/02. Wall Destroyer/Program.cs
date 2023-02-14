using System;

namespace _02._Wall_Destroyer
{
    public class Program
    {
       private static int destroyerRow = 0;
      private static  int destroyerCol = 0;
        private static char[,] wall;
        private static int holeCount = 1;
        private static int rodCount = 0;
        private static bool isDead = false;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
             wall = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    wall[row, col] = rowInfo[col];

                    if (wall[row, col] == 'V')
                    {
                        destroyerRow = row;
                        destroyerCol = col;
                        wall[row, col] = '*';
                    }
                }
            }

            string direction;
            while ((direction = Console.ReadLine()) != "End")
            {
                if (direction == "up")
                {
                    Move(-1, 0);
                }

                else if (direction == "down")
                {
                    Move(1, 0);
                }

                else if (direction == "left")
                {
                    Move(0, -1);
                }

                else if (direction == "right")
                {
                    Move(0, 1);
                }

                if (isDead)
                {
                    break;
                }
            }
            if (!isDead)
            {
                Console.WriteLine($"Vanko managed to make {holeCount} hole(s)" +
                $" and he hit only {rodCount} rod(s).");
                PrintMatrix();
            }
            
        }

        private static void Move(int row, int col)
        {
            if (IsInside(destroyerRow + row, destroyerCol + col))
            {
                if (wall[destroyerRow + row,destroyerCol + col] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    rodCount++;
                }

                else if (wall[destroyerRow + row, destroyerCol + col] == '-')
                {
                    wall[destroyerRow + row, destroyerCol + col] = '*';
                    destroyerRow += row;
                    destroyerCol += col;
                    holeCount++;
                }

                else if (wall[destroyerRow + row, destroyerCol + col] == 'C')
                {
                    wall[destroyerRow + row, destroyerCol + col] = 'E';
                    holeCount++;
                    isDead = true;
                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                    PrintMatrix();
                }

                else if (wall[destroyerRow + row, destroyerCol + col] == '*')
                {                       
                    Console.WriteLine($"The wall is already destroyed at position" +
                        $" [{destroyerRow + row}, {destroyerCol + col}]!");

                    destroyerRow += row;
                    destroyerCol += col;
                }
            }

            
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(0);
        }

        private static void PrintMatrix()
        {
            if (!isDead)
            {
                wall[destroyerRow, destroyerCol] = 'V';
            }

            for (int r = 0; r < wall.GetLength(0); r++)
            {
                for (int c = 0; c < wall.GetLength(0); c++)
                {
                    Console.Write(wall[r,c]);
                }

                Console.WriteLine();
            }
        }
    }
}
