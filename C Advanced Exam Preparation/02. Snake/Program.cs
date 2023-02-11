using System;

namespace _02._Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] territory = new char[n, n];

            int snakeRow = 0;
            int snakeCol = 0;
            int foodQuantity = 0;

            for (int row = 0; row < n; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    territory[row, col] = rowInfo[col];

                    if (territory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                        territory[row, col] = '.';
                    }
                }
            }

            bool gameOver = false;

            while (foodQuantity < 10)
            {
                string direction = Console.ReadLine();
              
                    if (direction == "up")
                    {
                        snakeRow--;
                    }

                    else if (direction == "down")
                    {
                        snakeRow++;
                    }

                    else if (direction == "left")
                    {
                        snakeCol--;
                    }

                    else if (direction == "right")
                    {
                        snakeCol++;
                    }

                    if (snakeRow < 0 || snakeRow >= n || snakeCol < 0 || snakeCol >= n)
                    {
                        gameOver = true;
                        break;
                    }

                    if (territory[snakeRow, snakeCol] == 'B')
                    {
                        territory[snakeRow, snakeCol] = '.';

                        bool tunnelPassed = false;

                        for (int r = 0; r < n; r++)
                        {
                            for (int c = 0; c < n; c++)
                            {
                                if (territory[r, c] == 'B')
                                {
                                    territory[r, c] = '.';
                                    snakeRow = r;
                                    snakeCol = c;
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

                    else if (territory[snakeRow, snakeCol] == '*')
                    {
                        territory[snakeRow, snakeCol] = '.';
                        foodQuantity++;
                    }

                else
                {
                    territory[snakeRow, snakeCol] = '.';
                }
                
            }

            if (gameOver)
            {
                Console.WriteLine("Game over!");                
            }

            if (foodQuantity >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
                territory[snakeRow, snakeCol] = 'S';
            }

            Console.WriteLine($"Food eaten: {foodQuantity}");

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < n; c++)
                {
                    Console.Write(territory[r,c]);
                }

                Console.WriteLine();
            }

            
        }
    }
}
