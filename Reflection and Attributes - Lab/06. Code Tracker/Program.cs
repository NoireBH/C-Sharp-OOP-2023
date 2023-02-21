using System;

namespace AuthorProblem
{
    [Author("Elmir")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Elmir")]
        public static void Method()
        {

        }
    }
}
