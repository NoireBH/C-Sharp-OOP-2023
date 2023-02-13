using System;

namespace _02._Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] field = new char[n, n];

            int moleRow = 0;
            int moleCol = 0;

            int points = 0;

            for (int row = 0; row < n; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    field[row, col] = rowInfo[col];

                    if (field[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                        field[row, col] = '-';
                    }
                }
            }
            while (points < 25)
            {
                string direction = Console.ReadLine();

                if (direction == "End")
                {

                    break;
                }

                if (direction == "up")
                {
                    if (IsOutside(moleRow - 1, moleCol, n))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    moleRow--;
                }

                else if (direction == "down")
                {
                    if (IsOutside(moleRow + 1, moleCol, n))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    moleRow++;
                }

                else if (direction == "left")
                {
                    if (IsOutside(moleRow, moleCol - 1, n))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    moleCol--;
                }

                else if (direction == "right")
                {
                    if (IsOutside(moleRow, moleCol + 1, n))
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                        continue;
                    }

                    moleCol++;
                }

                

                if (field[moleRow, moleCol] == 'S')
                {
                    field[moleRow, moleCol] = '-';

                    bool tunnelPassed = false;

                    for (int r = 0; r < n; r++)
                    {
                        for (int c = 0; c < n; c++)
                        {
                            if (field[r, c] == 'S')
                            {
                                field[r, c] = '-';
                                moleRow = r;
                                moleCol = c;
                                tunnelPassed = true;
                                break;
                            }
                        }

                        if (tunnelPassed)
                        {
                            points -= 3;
                            break;
                        }

                    }
                }



                else if (char.IsDigit(field[moleRow, moleCol]))
                {                    
                    points += int.Parse(field[moleRow, moleCol].ToString());
                    field[moleRow, moleCol] = '-';
                }               
            }

            field[moleRow, moleCol] = 'M';

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }

            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(field[r, c]);
                }

                Console.WriteLine();
            }


        }
        public static bool IsOutside(int moleRow, int moleCol, int n)
                  => moleRow < 0 || moleRow >= n || moleCol < 0 || moleCol >= n;
    }
}
