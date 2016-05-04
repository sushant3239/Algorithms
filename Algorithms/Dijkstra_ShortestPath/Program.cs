using System;

namespace Dijkstra_ShortestPath
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<int> graph = new Graph<int>();
            graph.InsertEdge(1, 4, 10);
            graph.InsertEdge(1, 2, 2);
            graph.InsertEdge(1, 3, 1);
            graph.InsertEdge(2, 6, 3);
            graph.InsertEdge(2, 5, 1);
            graph.InsertEdge(2, 1, 2);
            graph.InsertEdge(3, 5, 1);
            graph.InsertEdge(3, 1, 1);
            graph.InsertEdge(4, 6, 20);
            graph.InsertEdge(4, 1, 10);
            graph.InsertEdge(5, 6, 1);
            graph.InsertEdge(5, 2, 1);
            graph.InsertEdge(6, 4, 20);
            graph.InsertEdge(6, 5, 1);
            graph.InsertEdge(6, 2, 3);

            graph.DijkstraShortestPath(1);
            Console.ReadLine();
        }
    }
}
