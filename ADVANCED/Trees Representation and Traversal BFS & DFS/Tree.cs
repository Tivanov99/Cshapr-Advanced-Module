namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private bool RootIsDeleted = false;
        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            List<T> values = new List<T>();
            if (!this.RootIsDeleted)
            {
                Queue<Tree<T>> queue = new Queue<Tree<T>>();

                queue.Enqueue(this);

                while (queue.Count > 0)
                {
                    Tree<T> current = queue.Dequeue();
                    values.Add(current.Value);
                    foreach (Tree<T> child in current.Children)
                    {
                        queue.Enqueue(child);
                    }
                }

            }
            return values;
        }

        public ICollection<T> OrderDfs()
        {
            List<T> values = new List<T>();
            if (!this.RootIsDeleted)
            {
                Dfs(this, values);
            }
            return values;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            if (!this.RootIsDeleted)
            {
                Tree<T> result = FindNode(parentKey);
                if (result == null)
                {
                    throw new ArgumentNullException();
                }
                result._children.Add(child);
            }
        }


        public void RemoveNode(T nodeKey)
        {
            if (!this.RootIsDeleted)
            {
                Tree<T> searchedNode = FindNode(nodeKey);

                if (searchedNode == null)
                {
                    throw new ArgumentNullException();
                }

                foreach (Tree<T> child in searchedNode.Children)
                {
                    child.Parent = null;
                }

                searchedNode._children.Clear();

                Tree<T> parent = searchedNode.Parent;

                if (parent == null)
                {
                    this.RootIsDeleted = true;
                }
                else
                {
                    parent._children.Remove(searchedNode);
                }
                searchedNode.Value = default(T);
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            Tree<T> firstNode = this.FindNode(firstKey);
            Tree<T> secondNode = this.FindNode(secondKey);

            if (firstNode.Equals(this))
            {
                this.Value = secondNode.Value;
                this._children.Clear();
                foreach (Tree<T> child in secondNode._children)
                {
                    this._children.Add(child);
                }
                return;
            }
            if (secondNode.Equals(this))
            {
                this.Value = firstNode.Value;
                this._children.Clear();
                foreach (Tree<T> child in firstNode._children)
                {
                    this._children.Add(child);
                }
                return;
            }
            Tree<T> FirstParent = firstNode.Parent;
            Tree<T> SecondParent = secondNode.Parent;

            int firstIndex = FirstParent._children.IndexOf(firstNode);
            int secondIndex = SecondParent._children.IndexOf(secondNode);

            FirstParent._children[firstIndex] = secondNode;
            SecondParent._children[secondIndex] = firstNode;
        }
        private void Dfs(Tree<T> parent, List<T> values)
        {
            foreach (Tree<T> child in parent.Children)
            {
                Dfs(child, values);
            }

            values.Add(parent.Value);
        }
        private Tree<T> FindNode(T Key)
        {
            if (this.Value.Equals(Key))
            {
                return this;
            }
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                Tree<T> current = queue.Dequeue();
                foreach (Tree<T> child in current.Children)
                {
                    if (child.Value.Equals(Key))
                    {
                        return child;
                    }
                    queue.Enqueue(child);
                }
            }
            return null;
        }
    }
}
