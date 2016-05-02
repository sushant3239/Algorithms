using System;

namespace TreeDataStructure
{
    public class Tree<T> where T : IComparable
    {
        private TreeNode<int> _rootNode;

        public TreeNode<int> RootNode { get { return _rootNode; } }

        public void Add(int item)
        {
            if (_rootNode == null)
            {
                InitializeRoot(item);
                return;
            }
            AddToTree(item, _rootNode);
        }

        private void AddToTree(int item, TreeNode<int> parentNode)
        {
            if (item < parentNode.Item)
            {
                if (parentNode.LeftNode == null)
                {
                    parentNode.LeftNode = new TreeNode<int> { Item = item };
                    return;
                }
                AddToTree(item, parentNode.LeftNode);
            }
            else
            {
                if (parentNode.RightNode == null)
                {
                    parentNode.RightNode = new TreeNode<int> { Item = item };
                    return;
                }
                AddToTree(item, parentNode.RightNode);
            }

        }

        private void InitializeRoot(int item)
        {
            _rootNode = new TreeNode<int> { Item = item };
        }

        private bool IsRootFull()
        {
            return (_rootNode.LeftNode != null && _rootNode.RightNode != null);
        }

        public int Find(int item)
        {
            return Find(item, _rootNode);
        }

        private int Find(int item, TreeNode<int> node)
        {
            if (item == node.Item) return item;
            if (item < node.Item) return Find(item, node.LeftNode);
            return Find(item, node.RightNode);
        }

        public void PrintInorder()
        {
            PrintInOrder(_rootNode);
        }

        private void PrintInOrder(TreeNode<int> node)
        {
            if (node == null) return;
            PrintInOrder(node.LeftNode);
            Console.WriteLine("\n" + node.Item);
            PrintInOrder(node.RightNode);
        }

        public void PrintPreOrder()
        {
            PrintPreOrder(_rootNode);
        }

        private void PrintPreOrder(TreeNode<int> node)
        {
            if (node == null) return;
            Console.WriteLine(node.Item);
            PrintPreOrder(node.LeftNode);
            PrintPreOrder(node.RightNode);
        }
    }
}
