namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Value { get; set; }
        public Tree<T> Parent { get; set; }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = FindNodeWithBfs(parentKey, child);
            CheckIfNodeIsEmpty(searchedNode);
            searchedNode._children.Add(child);

        }



        public IEnumerable<T> OrderBfs()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);

                foreach (var child in subtree._children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result = new List<T>();
            this.Dfs(this, result);

            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = FindNodeToRemoveWithBfs(nodeKey);
            CheckIfNodeIsEmpty(searchedNode);

            foreach (var child in searchedNode._children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            var searchedParent = searchedNode.Parent;

            if (searchedParent != null)
            {
                searchedParent._children.Remove(searchedNode);
            }

            else
            {
                throw new ArgumentException("Root was removed!");
            }

            searchedNode.Value = default;

        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindNodeWithBfs(firstKey);
            var secondNode = FindNodeWithBfs(secondKey);
            CheckIfNodeIsEmpty(firstNode);
            CheckIfNodeIsEmpty(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            // If one of the nodes is the root node
            if (firstParent == null)
            {
                Value = secondNode.Value;

                // replace the old children with the new ones
                _children.Clear();
                foreach (var child in secondNode._children)
                {
                    _children.Add(child);
                }
            }
            else if (secondParent == null)
            {
                Value = firstNode.Value; 
                _children.Clear();

                foreach (var child in firstNode._children)
                {
                    _children.Add(child);
                }
            }

            else
            {
                firstNode.Parent = secondParent;
                secondNode.Parent = firstParent;

                int indexOfFirst = firstParent._children.IndexOf(firstNode);
                int indexOfSecond = secondParent._children.IndexOf(secondNode);

                firstParent._children[indexOfFirst] = secondNode;
                secondParent._children[indexOfSecond] = firstNode;
            }
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree._children)
            {
                Dfs(child, result);
            }

            result.Add(tree.Value);
        }
        private Tree<T> FindNodeWithBfs(T parentkey, Tree<T> _child)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.Value.Equals(parentkey))
                {
                    return subtree;
                }

                foreach (var child in subtree._children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;

        }

        private Tree<T> FindNodeToRemoveWithBfs(T nodeKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(nodeKey))
                {
                    return subtree;
                }

                foreach (var child in subtree._children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void CheckIfNodeIsEmpty(Tree<T> searchedNode)
        {
            if (searchedNode == null)
            {
                throw new ArgumentNullException();
            }
        }

        private Tree<T> FindNodeWithBfs(T parentkey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.Value.Equals(parentkey))
                {
                    return subtree;
                }

                foreach (var child in subtree._children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;

        }
    }
}
