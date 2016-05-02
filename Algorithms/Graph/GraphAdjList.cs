using System;
using System.Collections.Generic;

namespace Graph
{
    public class VertexAdjList<T> where T : IComparable
    {
        public T Value { get; set; }
        public AdjencyListNode<T> Head { get; set; }
        public AdjencyListNode<T> Tail { get; set; }

        public void AddEdge(T data)
        {
            var node = CreateNewNode(data);
            if (Head == null)
            {
                InitHead(node);
                return;
            }

            AppendToTail(node);
        }

        private void AppendToTail(AdjencyListNode<T> node)
        {
            Tail.Next = node;
        }

        private AdjencyListNode<T> CreateNewNode(T data)
        {
            var node = new AdjencyListNode<T>
            {
                Data = data,
                Next = null
            };
            return node;
        }

        private void InitHead(AdjencyListNode<T> node)
        {
            Head = node;
            Tail = node;
        }
    }

    public class AdjencyListNode<T> where T : IComparable
    {
        public T Data { get; set; }
        public AdjencyListNode<T> Next { get; set; }
    }

    public class Graph<T> where T : IComparable
    {
       
    }

}
