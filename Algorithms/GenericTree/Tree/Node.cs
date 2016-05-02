using System;

namespace GenericTree.Tree
{
    class Node<T> where T : IComparable
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Data { get; set; }
    }
}
