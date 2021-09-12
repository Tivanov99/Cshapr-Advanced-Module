using System;
using System.Collections.Generic;
using System.Text;

namespace BST_Printer
{
    public class Binary_Search_Tree<T> where T : IComparable
    {
        private List<Node<T>> elements;
        public Binary_Search_Tree()
        {
            this.elements = new List<Node<T>>();
        }

        public Binary_Search_Tree(Node<T> root)
            : this()
        {
            this.Root = root;
            this.elements.Add(root);
        }

        public Node<T> Root { get; private set; }

        public void AddElement(T node)
        {
            Node<T> newNode = new Node<T>(node);
            if (this.Root == null)
            {
                this.Root = newNode;
                this.elements.Add(newNode);
                return;
            }
            InsertNoAde(newNode);
        }

        private void InsertNoAde(Node<T> node)
        {
            Node<T> currentNode = this.Root;
            while (true)
            {
                if (currentNode.Value.CompareTo(node.Value) > 1 && currentNode.LeftChild == null)
                {
                    currentNode.LeftChild = node;
                    this.elements.Add(node);
                    return;
                }
                else if (currentNode.Value.CompareTo(node.Value) > 1)
                {
                    currentNode = currentNode.LeftChild;
                    continue;
                }

                if (currentNode.Value.CompareTo(node.Value) < 0 && currentNode.RightChild == null)
                {
                    currentNode.RightChild = node;
                    this.elements.Add(node);
                    return;
                }
                else if (currentNode.Value.CompareTo(node.Value) < 0)
                {
                    currentNode = currentNode.RightChild;
                    continue;
                }
            }
        }
        public Node<T> SearchNode(T value)
        {
            Node<T> current = this.Root;
            while (current != null)
            {
                if (current.Value.CompareTo(value) == 0)
                {
                    return current;
                }
                if (current.Value.CompareTo(value) > 0)
                {
                    current = current.LeftChild;
                    continue;
                }
                if (current.Value.CompareTo(value) < 0)
                {
                    current = current.RightChild;
                }
            }
            return null;
        }
        public Node<T> Printer(Node<T> node, List<T> nodes)
        {
            if (node.RightChild == null && node.LeftChild == null)
            {
                return node;
            }
            Node<T> Current = Printer(node.RightChild, nodes);
            nodes.Add(Current.Value);
            return node;
            //Current = Printer(node.LeftChild, nodes, startNode);
            //nodes.Add(Current.Value);
        }
        public List<T> DFS(Node<T> root, List<T> values)
        {
            values.Add(root.Value);
            foreach (Node<T> child in root.Childs)
            {
                DFS(child, values);
            }
            return values;
        }
    }
}
