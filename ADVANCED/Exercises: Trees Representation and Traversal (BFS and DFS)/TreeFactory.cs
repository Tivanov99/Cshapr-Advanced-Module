using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree
{
    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;
        Tree<int> Root;
        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (string item in input)
            {
                string[] Pair = item.Split(" ");
                int ParentValue = int.Parse(Pair[0]);
                int childValue = int.Parse(Pair[1]);
                AddEdge(ParentValue, childValue);
            }
            return GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesBykeys.ContainsKey(key))
            {
                nodesBykeys.Add(key, new Tree<int>(key));
            }
            return this.nodesBykeys.Values.FirstOrDefault(x => x.Key == key);
        }

        public void AddEdge(int parent, int child)
        {
            Tree<int> Parent = CreateNodeByKey(parent);
            Tree<int> Child = CreateNodeByKey(child);
            if (Parent.Parent == null)
            {
                this.Root = Parent;
            }

            Parent.AddChild(Child);
            Child.AddParent(Parent);
        }

        private Tree<int> GetRoot()
        {
            return this.Root;
        }
    }
}


        
  