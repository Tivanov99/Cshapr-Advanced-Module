using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    public interface IAbstractBinaryTree<T>
    {
        T Value { get; }
        IAbstractBinaryTree<T> LeftChild { get; }
        IAbstractBinaryTree<T> RightChild { get; }
        void AsIndentedPreOrder(IAbstractBinaryTree<T> parent,int indent);
        List<IAbstractBinaryTree<T>> PreOrder(IAbstractBinaryTree<T> parent);
        List<IAbstractBinaryTree<T>> InOrder(IAbstractBinaryTree<T> parent);
        List<IAbstractBinaryTree<T>> PostOrder(IAbstractBinaryTree<T> parent);
        void ForEachInOrder(Action<T> action);
    }
}
