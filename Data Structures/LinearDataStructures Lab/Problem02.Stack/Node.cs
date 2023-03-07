namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T value)
        {
            Element = value;
        }
        public T Element { get; set; }
        public Node<T> Next { get; set; }
    }
}