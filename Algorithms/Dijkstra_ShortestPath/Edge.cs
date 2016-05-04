using System;

namespace Dijkstra_ShortestPath
{
    public class Edge<T> where T : IComparable
    {
        public T Data { get; set; }
        public Vertex<T> DestinationVertex { get; set; }
        public int Weight { get; set; }
    }
}
