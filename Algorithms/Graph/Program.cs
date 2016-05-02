using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new GraphDirect<int>();
            graph.InsertEadge(1, 3);
            graph.InsertEadge(1, 4);
            graph.InsertEadge(1, 5);
            graph.InsertEadge(3, 6);
            graph.InsertEadge(4, 8);
            graph.InsertEadge(6, 8);
            graph.InsertEadge(8, 7);            
            graph.InsertEadge(5, 7);
            graph.InsertEadge(7, 15);
            graph.InsertEadge(15, 1);
            //graph.InsertEadge(0, 1);
            //graph.InsertEadge(0, 2);
            //graph.InsertEadge(1, 2);
            //graph.InsertEadge(2, 0);
            //graph.InsertEadge(2, 3);
            //graph.InsertEadge(3, 2);

            graph.RemoveCycles();
            //var path = graph.FindPath(1, 8);
            Console.ReadLine();
        }
    }
}
