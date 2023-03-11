namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var nodeAndParent = line.Split().Select(int.Parse).ToList();

                if (!nodesBykeys.ContainsKey(nodeAndParent[0]))
                {
                    var node = CreateNodeByKey(nodeAndParent[0]);
                    nodesBykeys[nodeAndParent[0]] = node;
                }

                if (!nodesBykeys.ContainsKey(nodeAndParent[1]))
                {
                    var node = CreateNodeByKey(nodeAndParent[1]);
                    nodesBykeys[nodeAndParent[1]] = node;
                }

                AddEdge(nodeAndParent[0], nodeAndParent[1]);
            }

            return null;
        }

        public Tree<int> CreateNodeByKey(int key)
        {
          return new Tree<int>(key);
        }

        public void AddEdge(int parent, int child)
        {
            nodesBykeys[parent].AddChild(nodesBykeys[child]);
            nodesBykeys[child].AddParent(nodesBykeys[parent]);
        }

        private Tree<int> GetRoot()
        {
            throw new NotImplementedException();
        }
    }
}
