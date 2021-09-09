using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BinarySearchTree
{
    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {

        public BinarySearchTree()
        {

        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            Node<T> current = this.Root;
            while (current != null)
            {
                if (element.CompareTo(current.Value) < 0)
                {
                    current = current.LeftChild;
                }
                else if (element.CompareTo(current.Value) > 0)
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element, null, null);
            }
            else if (this.LeftChild == null && this.Value.CompareTo(element)>0)
            {
                this.Root.LeftChild = new Node<T>(element, null, null);
                this.LeftChild = new Node<T>(element,null,null);
            }
            else if (this.RightChild == null && this.Value.CompareTo(element) < 0)
            {
                this.Root.RightChild = new Node<T>(element, null, null);
                this.RightChild = new Node<T>(element, null, null);
            }
            else
            {
                bool Exist = this.Contains(element);
                if (!Exist)
                {
                    Node<T> current = this.Root;
                    while (true)
                    {
                        if (current.Value.CompareTo(element) < 0)
                        {
                            if (current.RightChild == null)
                            {
                                current.RightChild = new Node<T>(element, null, null);
                                return;
                            }
                            current = current.RightChild;
                        }
                        else if (current.Value.CompareTo(element) > 0)
                        {
                            if (current.LeftChild == null)
                            {
                                current.LeftChild = new Node<T>(element, null, null);
                                return;
                            }
                            current = current.LeftChild;
                        }
                    }
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if (this.Root == null)
            {
                return null;
            }
            else if (this.LeftChild == null && this.RightChild == null)
            {
                return null;
            }
            else
            {
                Node<T> current = this.Root;
                while (current != null)
                {
                    if (current.Value.CompareTo(element) < 0)
                    {
                        current = current.RightChild;
                    }
                    else if (current.Value.CompareTo(element) > 0)
                    {
                        current = current.LeftChild;
                    }
                    else
                    {
                        return new BinarySearchTree<T>(new Node<T>(current.Value, current.LeftChild, current.RightChild));
                    }
                }
            }
            return null;

        }
    }
}
