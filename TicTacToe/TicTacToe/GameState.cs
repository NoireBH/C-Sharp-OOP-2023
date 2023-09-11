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
        }

        public PlayerValues[,] Board { get; private set; }

        public void GameStart()
        {
            for (int r = 1; r <= rowsAndCols; r++)
            {
                for (int c = 0; c < rowsAndCols; c++)
                {
                    Board[r, c] = PlayerValues.None;
                }
            }
        }
    }
}
