using System;
using System.Collections;

namespace TreeDataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree = new Tree<int>();
            tree.Add(77);
            tree.Add(3);
            tree.Add(2);
            tree.Add(4);
            tree.Add(69);
            tree.Add(7);
            tree.Add(1);
            tree.Add(11);
            tree.Add(6);
            tree.Add(8);
            tree.Add(12);
            tree.Add(234);
            tree.Add(34);
            tree.Add(112);
            tree.Add(22);
            tree.Add(1232);
            tree.Add(76);
            tree.Add(65);
            tree.Add(21);
            tree.Add(9);
            tree.Add(153);
            //tree.Find(112);
            //tree.PrintInorder();
            //tree.PrintPreOrder();
            LevelOrderTraversal(tree.RootNode);
            Console.Read();
        }

        static bool IsBst(TreeNode<int> node)
        {
            return IsBinarySearchTree(node, int.MinValue, int.MaxValue);
        }

        static bool IsBinarySearchTree(TreeNode<int> node, int min, int max)
        {
            if (node == null) return true;

            return (node.Item < max && node.Item > min) &&
                IsBinarySearchTree(node.LeftNode, min, node.Item)
                && IsBinarySearchTree(node.RightNode, node.Item, max);
        }


        static int FindMin(TreeNode<int> node)
        {
            if (node.LeftNode == null) return node.Item;
            return FindMin(node.LeftNode);
        }

        static int FindMax(TreeNode<int> node)
        {
            if (node.RightNode == null) return node.Item;
            return FindMax(node.RightNode);
        }

        private static Queue queue = new Queue();
        static void LevelOrderTraversal(TreeNode<int> node)
        {
            if (node == null) return;

            if (node.LeftNode != null) queue.Enqueue(node.LeftNode);
            if (node.RightNode != null) queue.Enqueue(node.RightNode);
            Console.WriteLine(node.Item);
            if (queue.Count > 0)
                LevelOrderTraversal(queue.Dequeue() as TreeNode<int>);
        }
    }
}
