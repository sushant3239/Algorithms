using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphDirect<T> where T : IComparable
    {
        private Dictionary<T, Vertex<T>> Vertexes { get; set; }

        public GraphDirect()
        {
            Vertexes = new Dictionary<T, Vertex<T>>();
        }

        public void InsertEadge(T vertextSource, T vertexDestination)
        {
            Vertex<T> foundVertex = default(Vertex<T>);
            if (VertexAlreadyExisit(vertextSource, out foundVertex))
            {
                foundVertex.Edges.Add(vertexDestination);
                return;
            }
            Vertexes.Add(vertextSource, new Vertex<T>
            {
                Data = vertextSource,
                Edges = new List<T> { vertexDestination }
            });
        }

        private bool VertexAlreadyExisit(T vertextSource, out Vertex<T> foundVertext)
        {
            if (Vertexes.ContainsKey(vertextSource))
            {
                foundVertext = Vertexes[vertextSource];
                return true;
            }
            foundVertext = default(Vertex<T>);
            return false;
        }

        private Queue<T> visitQueue = new Queue<T>();


        public void BreadthFirstTraversal(T data)
        {
            visitQueue.Enqueue(data);
            Bfs(data);
        }

        private void Bfs(T data)
        {
            var vertexToVisit = visitQueue.Dequeue();
            var currentVertex = Vertexes[vertexToVisit];
            if (!currentVertex.Visited)
            {
                foreach (var eadge in currentVertex.Edges)
                {
                    visitQueue.Enqueue(eadge);
                }
                Console.WriteLine(currentVertex.Data);
                currentVertex.Visited = true;
            }

            if (visitQueue.Count > 0) BreadthFirstTraversal(visitQueue.Dequeue());
        }

        Stack<T> stack = new Stack<T>();
        public void DepthFirstTraversal(T data)
        {
            if (Vertexes.ContainsKey(data))
            {
                var currentVertex = Vertexes[data];
                if (currentVertex.Visited) return;

                Console.WriteLine(currentVertex.Data);
                currentVertex.Visited = true;
                if (currentVertex.Edges != null)
                {
                    foreach (var vertex in currentVertex.Edges)
                    {
                        stack.Push(vertex);
                        DepthFirstTraversal(stack.Pop());
                    }
                }
            }

        }

        public IEnumerable<T> FindPath(T source, T destination)
        {
            var stack = new Stack<T>();
            var path = new List<T>();
            stack.Push(source);
            var current = source;
            while (current.CompareTo(destination) != 0)
            {
                current = stack.Pop();
                var currentVertex = Vertexes[current];
                if (!currentVertex.Visited)
                {
                    currentVertex.Visited = true;
                    foreach (var vetex in currentVertex.Edges)
                    {
                        stack.Push(vetex);
                    }
                }
                path.Add(current);
            }
            return path;
        }

        public bool IsCyclicGraph()
        {
            bool isCyclic = false;
            return IsCyclicGraph(Vertexes.Keys.ElementAt(0));

        }

        private bool IsCyclicGraph(T source)
        {
            var stack = new Stack<T>();
            stack.Push(source);
            while (stack.Count > 0)
            {
                var vertexToVisit = stack.Peek();
                if (Vertexes.ContainsKey(vertexToVisit))
                {
                    var currentVertex = Vertexes[vertexToVisit];

                    if (currentVertex.Visited && stack.Contains(vertexToVisit)) return true;

                    if (!currentVertex.Visited)
                    {
                        currentVertex.Visited = true;
                        stack.Pop();
                        foreach (var vertex in currentVertex.Edges) stack.Push(vertex);
                    }
                }

            }
            return false;
        }

        public void RemoveCycles()
        {
            RemoveCycles(Vertexes.Keys.ElementAt(0));
        }

        private void RemoveCycles(T source)
        {
          
        }

        private void RemoveEddge()
        {

        }
    }
}
