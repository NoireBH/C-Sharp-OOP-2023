using Snake_Game;

internal class snakeGame
{
    private static void Main(string[] args)
    {

        Snake snake = new Snake(1,1);
        while (true) 
        {
            snake.Move();
        }
        
    }
}