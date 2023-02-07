using System;

namespace _02._Navy_Battle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] battlefield = new char[n, n];

            int submarineRow = 0;
            int submarineCol = 0;

            int submarineHp = 3;
            int battleCruisers = 3;

            for (int row = 0; row < n; row++)
            {
                string rowInfo = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    battlefield[row, col] = rowInfo[col];

                    if (battlefield[row, col] == 'S')
                    {   
                        submarineRow = row;
                        submarineCol = col;
                        battlefield[row, col] = '-';
                    }
                }
            }

            while (battleCruisers > 0 && submarineHp > 0)
            {
                string direction = Console.ReadLine().ToLower();

                if (direction == "up")
                {
                    submarineRow--;
                }

                else if (direction == "down")
                {
                    submarineRow++;
                }

                else if (direction == "left")
                {
                    submarineCol--;
                }

                else if (direction == "right")
                {
                    submarineCol++;
                }

                if (battlefield[submarineRow, submarineCol] == 'C')
                {
                    battlefield[submarineRow, submarineCol] = '-';
                    battleCruisers--;
                }

                else if (battlefield[submarineRow, submarineCol] == '*')
                {
                    battlefield[submarineRow, submarineCol] = '-';
                    submarineHp--;
                }
            }

            battlefield[submarineRow, submarineCol] = 'S';

            if (battleCruisers == 0)
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
            }

            else if (submarineHp == 0)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared!" +
                    $" Last known coordinates [{submarineRow}, {submarineCol}]!");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(battlefield[row,col]);
                }

                Console.WriteLine();
            }


        }
    }
}
