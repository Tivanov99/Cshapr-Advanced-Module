using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value, IAbstractBinaryTree<T> leftChild = null, IAbstractBinaryTree<T> rightChild = null)
        {
            this.Value = value;
            this.RightChild = rightChild;
            this.LeftChild = leftChild;
        }
        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public void AsIndentedPreOrder(IAbstractBinaryTree<T> parent, int indent)
        {
            Console.Write($"{new String(' ', indent += 2) + parent.Value}\n\r");
            if (parent.LeftChild != null)
            {
                AsIndentedPreOrder(parent.LeftChild, indent);
            }
            if (parent.RightChild != null)
            {
                AsIndentedPreOrder(parent.RightChild, indent);
            }
        }

        public void ForEachInOrder(Action<T> action)
        {
            throw new NotImplementedException();
        }

        public List<IAbstractBinaryTree<T>> InOrder(IAbstractBinaryTree<T> parent)
        {
            List<IAbstractBinaryTree<T>> trres = new List<IAbstractBinaryTree<T>>();
            if (parent.LeftChild != null)
            {
                InOrder(parent.LeftChild);
            }
            Console.WriteLine(parent.Value);
            if (parent.RightChild != null)
            {
                InOrder(parent.RightChild);
            }
            return trres;
        }

        public List<IAbstractBinaryTree<T>> PostOrder(IAbstractBinaryTree<T> parent)
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();
            if (parent.LeftChild != null)
            {
                PostOrder(parent.LeftChild);
            }
            if (parent.RightChild != null)
            {
                PostOrder(parent.RightChild);
            }
            Console.WriteLine(parent.Value);
            return trees;
        }

        public List<IAbstractBinaryTree<T>> PreOrder(IAbstractBinaryTree<T> parent)
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();
            Console.WriteLine(parent.Value);

            if (parent.LeftChild != null)
            {
                PreOrder(parent.LeftChild);
            }
            if (parent.RightChild != null)
            {
                PreOrder(parent.RightChild);
            }
            return trees;
        }
    }
}
