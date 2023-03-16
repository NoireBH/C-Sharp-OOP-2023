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
              Tree<T> deepestNode = null;
            int deepestLevel = 0;

            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();
                var currentDepth = GetCurrentDepth(currentNode);
                if (currentNode._children.Count == 0 && currentDepth > deepestLevel)
                {
                    deepestLevel = currentDepth;
                    deepestNode = currentNode;
                }

                foreach (var child in currentNode._children)
                {
                    nodes.Enqueue(child);
                }
            }

            return deepestNode;
        }

        private int GetCurrentDepth(Tree<T> currentNode)
        {
            int depth = 0;
            var current = currentNode;

            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
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
            var deepestNode = GetDeepestLeftomostNode();
            var longestPath = new List<T>();

            while (deepestNode.Parent != null)
            {
                longestPath.Add(deepestNode.Key);
                deepestNode = deepestNode.Parent;
            }

            longestPath.Add(deepestNode.Key);

            longestPath.Reverse();
            return longestPath;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var leafNodes = GetLeafNodes();
            var pathsWithSum = new List<List<T>>();

            foreach (var leaf in leafNodes)
            {
                var node = leaf;
                int currentSum = 0;
                var currentPath = new List<T>();

                while (node != null)
                {
                    currentPath.Add(node.Key);
                    currentSum += Convert.ToInt32(node.Key);
                    node = node.Parent;
                }

                if (currentSum == sum)
                {
                    currentPath.Reverse();
                    pathsWithSum.Add(currentPath);
                }
            }

            return pathsWithSum;
        }

        private List<Tree<T>> GetLeafNodes()
        {
            var leafs = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();
            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (currentNode._children.Count == 0)
                {
                    leafs.Add(currentNode);
                }

                foreach (var child in currentNode._children)
                {
                    nodes.Enqueue(child);
                }
            }


            return leafs;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }
    }
}
