using System;
using System.Collections.Generic;

namespace GenericTree.Tree
{
    public class Tree<T> where T : IComparable
    {
        private Node<T> _root;

        #region Add

        public void Add(T data)
        {
            if (_root == null)
            {
                InitializeRoot(data);
                return;
            }
            Add(_root, data);
        }

        private void Add(Node<T> node, T data)
        {
            if (node.Data.CompareTo(data) >= 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T> { Data = data };
                    return;
                }
                Add(node.Left, data);
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T> { Data = data };
                    return;
                }
                Add(node.Right, data);
            }
        }

        private void InitializeRoot(T data)
        {
            _root = new Node<T>();
            _root.Data = data;
        }

        #endregion

        #region TraverseInorder

        public void TraverseInorder()
        {
            TraverseInorder(_root);
        }

        private void TraverseInorder(Node<T> node)
        {
            if (node == null) return;

            TraverseInorder(node.Left);
            Console.WriteLine(node.Data.ToString());
            TraverseInorder(node.Right);
        }

        private Stack<Node<T>> _stack;
        private Node<T> _currentNode;
        public void TraverseInorderUsingStack()
        {
            _stack = new Stack<Node<T>>();
            _currentNode = _root;
            TraverseInorderUsingStack(_currentNode);
        }

        private void TraverseInorderUsingStack(Node<T> node)
        {
            var current = node;
            var done = false;
            while (!done)
            {
                if (current != null)
                {
                    _stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (_stack.Count > 0)
                    {
                        current = _stack.Pop();
                        Console.WriteLine(current.Data);
                        current = current.Right;
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
        }

        #endregion

        #region TraversePreOrder

        public void TraversePreOrder()
        {
            TraversePreOrder(_root);
        }

        private void TraversePreOrder(Node<T> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Data.ToString());
            TraversePreOrder(node.Left);
            TraversePreOrder(node.Right);
        }

        #endregion

        #region TraverseLevelOrder

        private Queue<Node<T>> queue = new Queue<Node<T>>();
        public void TraverseLevelOrder()
        {
            var currentNode = _root;
            queue.Enqueue(currentNode);
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                Console.WriteLine(currentNode.Data);
            }
        }

        #endregion

        #region Find

        public T Find(T data)
        {
            var foundNode = Find(_root, data);
            if (foundNode == null) return default(T);
            return foundNode.Data;
        }

        private Node<T> Find(Node<T> node, T data)
        {
            if (node == null) return default(Node<T>);

            if (node.Data.Equals(data)) return node;

            if (node.Data.CompareTo(data) >= 0) return Find(node.Left, data);

            return Find(node.Right, data);
        }

        #endregion

        #region FindSuccesor

        public T FindSuccesor(T data)
        {
            var foundNodeWithData = Find(_root, data);
            if (foundNodeWithData.Right != null)
            {
                var succesorNode = Minimum(foundNodeWithData);
                return succesorNode.Data;
            }
            var successor = default(Node<T>);
            var ancestor = _root;
            while (ancestor != foundNodeWithData)
            {
                if (foundNodeWithData.Data.CompareTo(ancestor.Data) <= 0)
                {
                    successor = ancestor;
                    ancestor = ancestor.Left;
                }
                else
                {
                    ancestor = ancestor.Right;
                }
            }
            return successor != null ? successor.Data : default(T);

        }

        #endregion

        #region Minimum

        public T Minimum()
        {
            var nodeWithMinimunData = Minimum(_root);
            if (nodeWithMinimunData == null) return default(T);
            return nodeWithMinimunData.Data;
        }

        private Node<T> Minimum(Node<T> node)
        {
            if (node.Left == null) return node;

            var tempNode = node.Left;
            while (tempNode.Left != null) tempNode = tempNode.Left;
            return tempNode;
        }

        #endregion

        #region Maximum

        public T Maximum()
        {
            var currentNode = _root;
            while (currentNode.Right != null) currentNode = currentNode.Right;
            return currentNode.Data;
        }

        private Node<T> Maximum(Node<T> node)
        {
            if (node == null) return node;
            return Maximum(node.Right);
        }

        #endregion

        #region HeightOfTree

        private int _height = 0;
        public int HeightOfTree()
        {
            _height = 0;
            return HeightOfTree(_root);
        }

        private int HeightOfTree(Node<T> node)
        {
            if (node == null) return 0;

            var heightOfLeftTree = HeightOfTree(node.Left);
            var heightOfRighTree = HeightOfTree(node.Right);
            return Math.Max(heightOfLeftTree, heightOfRighTree) + 1;
        }


        #endregion

        #region DeleteNode

        public void Delete(T item)
        {
            var nodeToBeDeleted = Find(_root, item);
            var ancestor = FindAncestor(nodeToBeDeleted);
            if (DeleteLeafNode(nodeToBeDeleted, ancestor)) return;
            if (DeleteNodeWithOneChildren(nodeToBeDeleted, ancestor)) return;
            DeleteNodeWithTwoChildren(nodeToBeDeleted, ancestor);
        }

        private bool DeleteLeafNode(Node<T> nodeToBeDeleted, Node<T> ancestor)
        {
            if (nodeToBeDeleted.Left == null && nodeToBeDeleted.Right == null)
            {
                if (ancestor.Left == nodeToBeDeleted)
                {
                    ancestor.Left = null;
                    return true;
                }
                if (ancestor.Right == nodeToBeDeleted)
                {
                    ancestor.Right = null;
                    return true;
                }
            }
            return false;
        }

        private bool DeleteNodeWithOneChildren(Node<T> nodeToBeDeleted, Node<T> ancestor)
        {
            if (HasOnlyOneChild(nodeToBeDeleted))
            {
                var childNode = nodeToBeDeleted.Left != null ? nodeToBeDeleted.Left : nodeToBeDeleted.Right;
                if (ancestor.Left == nodeToBeDeleted)
                {
                    ancestor.Left = childNode;
                    return true;
                }
                if (ancestor.Right == nodeToBeDeleted)
                {
                    ancestor.Right = childNode;
                    return true;
                }
            }
            return false;
        }

        private bool HasOnlyOneChild(Node<T> node)
        {
            return ((node.Right == null || node.Left == null)
                && (node.Left != null || node.Right == null));
        }

        private void DeleteNodeWithTwoChildren(Node<T> nodeToBeDeleted, Node<T> ancestor)
        {
            if (HasTwoChildren(nodeToBeDeleted))
            {
                var nodeWithMinValue = Minimum(nodeToBeDeleted.Right);
                RemoveNodeFromAncestor(nodeWithMinValue);
                nodeWithMinValue.Left = nodeToBeDeleted.Left;
                nodeWithMinValue.Right = nodeToBeDeleted.Right;
                if (ancestor.Left == nodeToBeDeleted) ancestor.Left = nodeWithMinValue;
                if (ancestor.Right == nodeToBeDeleted) ancestor.Right = nodeWithMinValue;
            }
        }

        private bool HasTwoChildren(Node<T> node)
        {
            return (node.Left != null && node.Right != null);
        }

        private Node<T> FindAncestor(Node<T> node)
        {
            var current = _root;
            var done = false;
            while (!done)
            {
                if (current.Data.CompareTo(node.Data) > 0) current = current.Left;
                else current = current.Right;

                if (current == null || (current.Left == node || current.Right == node)) done = true;
            }
            return current;
        }

        private void RemoveNodeFromAncestor(Node<T> node)
        {
            var ancestor = FindAncestor(node);
            if (ancestor.Left == node)
            {
                ancestor.Left = null;
                return;
            }
            ancestor.Right = null;
        }

        #endregion

        #region LowestCommonAncestor

        public T LowestAncestor(T item1)
        {
            var current = _root;
            var parent = _root;
            var minAncestor = _root.Data;
            while (current.Data.CompareTo(item1) != 0)
            {
                parent = current;
                if (minAncestor.CompareTo(parent.Data) >= 0) minAncestor = parent.Data;
                if (current.Data.CompareTo(item1) >= 0) current = current.Left;
                else if (current.Data.CompareTo(item1) <= 0) current = current.Right;
            }
            return minAncestor;
        }

        #endregion
    }
}
