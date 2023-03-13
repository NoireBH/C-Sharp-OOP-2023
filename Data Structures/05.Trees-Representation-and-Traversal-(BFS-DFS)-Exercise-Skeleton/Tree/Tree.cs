namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children = new List<Tree<T>>();

            foreach (var child in _children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            _children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
           return GetAsString(0).Trim();
            
        }

        private string GetAsString(int spaces)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(new string(' ', spaces) + this.Key);

            foreach (var child in this._children)
            {
                result.Append(child.GetAsString(spaces + 2));
            }

            return result.ToString();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys()
        {
            var leafs = new List<T>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (currentNode._children.Count == 0)
                {
                    leafs.Add(currentNode.Key);
                }

                foreach (var child in currentNode._children)
                {
                    nodes.Enqueue(child);
                }
            }
           

            return leafs = leafs.OrderBy(leaf => leaf).ToList();
        }

        public List<T> GetMiddleKeys()
        {
            var middleNodes = new List<T>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (currentNode._children.Count > 0 && currentNode.Parent != null)
                {
                    middleNodes.Add(currentNode.Key);
                }

                foreach (var child in currentNode._children)
                {
                    nodes.Enqueue(child);
                }
            }


            return middleNodes = middleNodes.OrderBy(leaf => leaf).ToList();
        }

        public List<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
