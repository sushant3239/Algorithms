using System;

namespace TreeDataStructure
{
    public class TreeNode<T> where T : IComparable
    {
        public TreeNode<T> LeftNode { get; set; }
        public TreeNode<T> RightNode { get; set; }
        public T Item { get; set; }
    }
}
