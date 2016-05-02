using System;

namespace GenericTree.Tree
{
    public class AVLTree<T> where T : IComparable
    {
        private Node<T> _root;
        public void Add(T data)
        {
            if (_root == null)
            {
                InitializeRoot(data);
                return;
            }
            Add(_root, data);
            if (IsBalancedTree(this)) return;
            PerformRotation();
        }

        private void Add(Node<T> node, T data)
        {
            if (node.Data.CompareTo(data) >= 0)
            {
                if (node.Left == null)
                {
                    InitializeNodeWithData(node.Left, data);
                    return;
                }
                Add(node.Left, data);
            }
            if (node.Right == null)
            {
                InitializeNodeWithData(node.Right, data);
                return;
            }
            Add(node.Right, data);
        }

        private void InitializeRoot(T data)
        {
            _root = new Node<T>
            {
                Data = data,
            };
        }

        private void InitializeNodeWithData(Node<T> node, T data)
        {
            node = new Node<T> { Data = data };
        }
    }
}
