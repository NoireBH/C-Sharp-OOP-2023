internal class Program
{
    private static bool gameOver = false;
    private static void Main(string[] args)
    {
        string[,] gameBoard = new string[3, 3];

        string playerOneValue = "[X]";
        string playerTwoValue = "[O]";
        string currentValue = string.Empty;

        int playerOnePoints = 0;
        int playerTwoPoints = 0;

        bool playerOneTurn = true;

        while (!gameOver)
        {
            StartingScreenText();
            FillStartingBoard(gameBoard);

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("You didn't provide a number, please try again:");
            }

            Console.Clear();

            if (choice == 1)
            {
                Console.WriteLine("Mode is still a WIP please choose another mode!");
                Thread.Sleep(2000);
                Console.Clear();
                continue;
            }

            else if (choice == 2)
            {
                while (!gameOver)
                {
                    PlayerTurn(gameBoard, playerOneValue, playerTwoValue, ref playerOneTurn, currentValue);
                }
                

            }

            else if (choice == 3) 
            {
                Console.WriteLine("Thanks for playing this basic TicTacToe game :)");
                Console.WriteLine("See you!");
                Console.WriteLine("Press any key to exit.");
                Environment.Exit(0);
            }

            else
            {
                InvalidModePrint();
            }
        }
    }

    private static void PlayerTurn(string[,] gameBoard, string playerOneValue, string playerTwoValue, ref bool playerOneTurn, string currentValue)
    {
        

        if (playerOneTurn)
        {
            playerOneTurn = TurnLogic(gameBoard, playerOneValue, playerTwoValue, playerOneTurn, currentValue);

        }

        else
        {
            playerOneTurn = TurnLogic(gameBoard, playerOneValue, playerTwoValue, playerOneTurn, currentValue);

        }
    }

    private static bool TurnLogic(string[,] gameBoard, string playerOneValue, string playerTwoValue, bool playerOneTurn, string currentValue)
    {
        Console.Clear();
        if (playerOneTurn)
        {
            Console.WriteLine($"Please choose a row and column to place an {playerOneValue}");
        }

        else
        {
            Console.WriteLine($"Please choose a row and column to place an {playerTwoValue}");
        }
        
        PrintBoard(gameBoard);
        int row, col;

        WaitForKeyPress();
        GetRowAndCol(out row, out col, gameBoard);

        if (playerOneTurn)
        {
            PutValueOnBoard(gameBoard, row, col, playerOneValue, ref playerOneTurn);
        }

        else
        {
            PutValueOnBoard(gameBoard, row, col, playerTwoValue, ref playerOneTurn);
        }

        CheckIfPlayerWins(gameBoard,row,col, currentValue);
        PrintBoard(gameBoard);
        return playerOneTurn;
    }

    private static void GetRowAndCol(out int row, out int col, string[,] gameBoard)
    {
        PrintBoard(gameBoard);

        int[] rowAndCol = Console.ReadLine()
                       .Split(",")
                       .Select(int.Parse)
                       .ToArray();

        row = rowAndCol[0] - 1;
        col = rowAndCol[1] - 1;

        Console.Clear();
    }

    private static void InvalidModePrint()
    {
        Console.WriteLine("Invalid mode...");
        Console.WriteLine("Returning to main menu.");
        Thread.Sleep(2000);
        Console.Clear();
    }

    private static void StartingScreenText()
    {
        Console.WriteLine("Choose a mode:");
        Console.WriteLine("1 - VS AI");
        Console.WriteLine("2 - VS another player");
        Console.WriteLine("3 - Exit game");
    }

    private static void PrintBoard(string[,] gameBoard)
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                Console.Write(gameBoard[i, j]);
            }
            Console.WriteLine();
        }       
    }

    private static void WaitForKeyPress()
    {
        while (true)
        {
            Console.WriteLine("Press 'Space' or 'Enter' to Continue");
            var keyPress = Console.ReadKey();

            if (keyPress.Key == ConsoleKey.Enter || keyPress.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                return;
            }

            Console.WriteLine();
        }
    }

        private static void FillStartingBoard(string[,] gameBoard)
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                gameBoard[i, j] = "[ ]";
            }
            Console.WriteLine();
        }
    }

    private static void PutValueOnBoard(string[,] gameBoard, int row, int col ,string value, ref bool playerOneTurn)
    {
        if (IsOutOfBounds(gameBoard,row,col))
        {
            Console.WriteLine("Value is out of bounds of the gameboard!");
            Console.WriteLine("Please try again.");
            Thread.Sleep(1000);
            PutValueOnBoard(gameBoard, row, col, value, ref playerOneTurn);
        }

        else if (gameBoard[row,col] != "[ ]")
        {
            Console.WriteLine("There is already a value there!");
            Console.WriteLine("Please try again.");
            Thread.Sleep(1000);
        }
        else
        {
            gameBoard[row, col] = value;
            playerOneTurn = !playerOneTurn;
        }
        
    }

    private static bool IsOutOfBounds(string[,] gameBoard,int row, int col)
    {
        if (row >= gameBoard.GetLength(0) || col >= gameBoard.GetLength(0))
        {
            return true;
        }

        return false;
    }

    private static void CheckIfPlayerWins(string[,] gameBoard,int r, int c, string value)
    {
        if (gameBoard[r,c] == value && gameBoard[r,c + 1] == value && gameBoard[r,c + 2] == value)
        {
            gameOver = true;
        }

        else if (gameBoard[r, c] == value && gameBoard[r + 1, c] == value && gameBoard[r + 2, c] == value)
        {
            gameOver = true;
        }

        else if (gameBoard[r, c] == value && gameBoard[r + 1, c + 1] == value && gameBoard[r + 2, c + 2] == value)
        {
            gameOver = true;
        }
    }

}