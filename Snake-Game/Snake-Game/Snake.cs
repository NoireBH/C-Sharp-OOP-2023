using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game
{    
    public class Snake
    {
        public Snake(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }
        public int Column { get; }

        public void Move() 
        {
           var direction = Console.ReadKey();
            Console.WriteLine();

            if (direction.KeyChar.ToString().ToUpper() == "W")
            {
                Console.WriteLine("Up");
            }

            else if (direction.KeyChar.ToString().ToUpper() == "S")
            {
                Console.WriteLine("Down");
            }

            else if (direction.KeyChar.ToString().ToUpper() == "A")
            {
                Console.WriteLine("Left");
            }

            else if (direction.KeyChar.ToString().ToUpper() == "D")
            {
                Console.WriteLine("Right");
            }
        }
    }
}
