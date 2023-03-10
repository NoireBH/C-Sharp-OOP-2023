namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>
                (1, new Tree<int>(2, new Tree<int>(3), new Tree<int>(4))
                , new Tree<int>(5), new Tree<int>(6));
            tree.OrderBfs();
            tree.OrderDfs();
            tree.AddChild(3, new Tree<int>(11));
            tree.AddChild(3, new Tree<int>(12));
            tree.AddChild(11, new Tree<int>(13));
            tree.RemoveNode(2);
        }
    }
}
