namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;
        private Tree<int> root;
        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (string item in input)
            {
                string[] currPair = item.Split(' ');
                int firstKey = int.Parse(currPair[0]);
                int SecondKey = int.Parse(currPair[1]);

                AddEdge(firstKey, SecondKey);
            }
            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }
            return this.nodesBykeys.Values.FirstOrDefault(x => x.Key == key);
        }

        public void AddEdge(int parent, int child)
        {
            Tree<int> Parent = CreateNodeByKey(parent);
            Tree<int> Child = CreateNodeByKey(child);

            if(Parent.Parent==null)
            {
                this.root = Parent;
            }

            Parent.AddChild(Child);
            Child.AddParent(Parent);
        }

        private Tree<int> GetRoot()
        {
            return this.root;
        }
    }
}
