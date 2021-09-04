namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private Tree<T> root;
        public Tree(T key, params Tree<T>[] children)
        {
            this._children = new List<Tree<T>>();
            Parent = null;
            Key = key;
            foreach (Tree<T> child in children)
            {
                this._children.Add(child);
            }
            this.root = this;
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
            this.root = parent;
        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();
            int space = 0;
            sb.AppendLine(this.Key.ToString());
            this.TreeAsStingDFS(sb, this, space);
            return sb.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys()
        {
            List<T> list = new List<T>();
            BFSFindLeaf(list);
            list.OrderBy(x => x);
            return list;
        }
        
        public List<T> GetMiddleKeys()
        {
            List<T> list = new List<T>();
            BFSFindMiddle(list);
            return list;
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

        private void TreeAsStingDFS(StringBuilder sb, Tree<T> tree, int space)
        {
            if (space > 0)
            {
                sb.AppendLine(GenerateSpace(space) + tree.Key.ToString());
            }

            foreach (var child in tree._children)
            {
                TreeAsStingDFS(sb, child, space += 2);
                space -= 2;
            }
        }
        private string GenerateSpace(int count)
        {
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                result += " ";
            }
            return result;
        }
        private void BFSFindLeaf(List<T> list)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Tree<T> SubTree = queue.Dequeue();
                foreach (Tree<T> child in SubTree._children)
                {
                    if (child._children.Count == 0)
                    {
                        list.Add(child.Key);
                    }
                    queue.Enqueue(child);
                }
            }
        }
        private void BFSFindMiddle(List<T> list)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                Tree<T> SubTree = queue.Dequeue();
                foreach (Tree<T> child in SubTree._children)
                {
                     if (child.Parent != null && child._children.Count > 0)
                    {
                        list.Add(child.Key);
                    }

                    queue.Enqueue(child);
                }
            }
        }
    }
}
