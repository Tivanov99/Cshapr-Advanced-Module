using System;
using System.Collections.Generic;
namespace Tree
{
    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> _childrens;
        public Tree(T value)
        {
            this.Key = value;
            this.Parent = null;
            _childrens = new List<Tree<T>>();
        }
        public Tree(T value, Tree<T> child)
            : this(value)
        {
            child.Parent = this;
            this._childrens.Add(child);
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; set; }

        public IReadOnlyCollection<Tree<T>> Children => this._childrens;

        public void AddChild(Tree<T> child)
        {
            this._childrens.Add(child);
            child.Parent = this;
        }

        public void AddParent(Tree<T> parent)
        {
            if (parent != null)
            {
                this.Parent = parent;
            }
        }

        public string GetAsString()
        {
            throw new NotImplementedException();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLeafKeys()
        {
            throw new NotImplementedException();
        }

        public List<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        public List<T> GetMiddleKeys()
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
        public Tree<T> FindNodeBFS(T key)
        {
            if (this.Key.Equals(key))
            {
                return this;
            }
            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {


                foreach (Tree<T> child in queue.Peek().Children)
                {
                    if (child.Key.Equals(key))
                    {
                        return child;
                    }
                    queue.Enqueue(child);
                }
                queue.Dequeue();
            }
            return null;
        }
    }
}


  
        
