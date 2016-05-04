using System;
using System.Collections.Generic;

namespace Dijkstra_ShortestPath
{
    public class Vertex<T> where T : IComparable
    {
        public T Data { get; set; }
        public List<Edge<T>> Edges { get; set; }
    }
}
