using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{   
    public class GameState
    {
        private static int rowsAndCols = 3;

        public GameState()
        {
            Board =  new PlayerValues[rowsAndCols, rowsAndCols];
            GameStart();
        }

        public PlayerValues[,] Board { get; private set; }

        public void GameStart()
        {
            for (int r = 0; r < rowsAndCols; r++)
            {
                for (int c = 0; c < rowsAndCols; c++)
                {
                    Board[r, c] = PlayerValues.None;
                }
            }
        }

        public  void PrintBoard()
        {
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Console.Write(Board[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
