using System;
using System.Collections.Generic;

namespace Graph
{
    public class Vertex<T> where T : IComparable
    {
        public T Data { get; set; }
        public bool Visited { get; set; }
        public List<T> Edges { get; set; }
}
}
