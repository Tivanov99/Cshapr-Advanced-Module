using System;
using System.Collections.Generic;
using System.Text;

namespace BST_Printer
{
    public class Node<T> where T : IComparable
    {
        public Node(T value, Node<T> leftChild = null, Node<T> rightChild = null)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
            this.Childs = new List<Node<T>>();
            AddLeftChild();
            AddRightChild();
        }

        public T Value { get; private set; }
        public Node<T> LeftChild { get; set; }
        public Node<T> RightChild { get; set; }

        public List<Node<T>> Childs { get; set; }

        private void AddLeftChild()
        {
            if (this.LeftChild != null)
            {
                Childs.Add(LeftChild);
            }
        }
        private void AddRightChild()
        {
            if (this.RightChild != null)
            {
                Childs.Add(this.RightChild);
            }
        }
    }
}
