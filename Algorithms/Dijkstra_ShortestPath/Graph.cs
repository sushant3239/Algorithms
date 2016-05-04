using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_ShortestPath
{
    public class Graph<T> where T : IComparable
    {
        public Dictionary<T, Vertex<T>> _vertexes = new Dictionary<T, Vertex<T>>();

        public void InsertEdge(T sourceVertex, T destinationVertex, int weightFromSource)
        {
            var source = GetVertexFromMap(sourceVertex);
            if (source == null) source = CreateNewVertex(sourceVertex);
            source.Edges.Add(CreateNewEdge(destinationVertex, weightFromSource));
        }

        private Vertex<T> CreateNewVertex(T sourceData)
        {
            var vertex = new Vertex<T> { Data = sourceData, Edges = new List<Edge<T>>() };
            _vertexes.Add(sourceData, vertex);
            return vertex;
        }

        private Vertex<T> GetVertexFromMap(T sourceKey)
        {
            return _vertexes.ContainsKey(sourceKey) ? _vertexes[sourceKey] : default(Vertex<T>);
        }

        private Edge<T> CreateNewEdge(T data, int weight)
        {
            var edge = new Edge<T>();
            edge.Weight = weight;
            edge.Data = data;
            var destinationVertext = GetVertexFromMap(data);
            if (destinationVertext == null) destinationVertext = CreateNewVertex(data);
            edge.DestinationVertex = destinationVertext;
            return edge;
        }

        public void DijkstraShortestPath(T root)
        {
            var visitedVertexes = new List<T>();
            var shortestPath = InitShortestPath().ToList();
            visitedVertexes.Add(root);
            var currentVertex = _vertexes[root];
            var currentMinWeight = 0;
            while (visitedVertexes.Count != shortestPath.Count)
            {
                foreach (var edge in currentVertex.Edges)
                {
                    if (!IsVertexVisited(edge.Data, visitedVertexes))
                        AssignWeightToEdge(shortestPath, edge, (edge.Weight + currentMinWeight));
                }
                var edgeWithMinWeight = GetEdgeWithMinimunWeight(shortestPath, visitedVertexes);
                currentMinWeight = edgeWithMinWeight.Weight;
                currentVertex = _vertexes[edgeWithMinWeight.Data];
                visitedVertexes.Add(currentVertex.Data);
            }
        }

        private void AssignWeightToEdge(List<Edge<T>> edges, Edge<T> sourceEdge, int newWeight)
        {
            var edge = edges.FirstOrDefault(e => e.Data.CompareTo(sourceEdge.Data) == 0);
            edge.Weight = newWeight;
        }

        private IEnumerable<Edge<T>> InitShortestPath()
        {
            List<Edge<T>> edges = new List<Edge<T>>();
            foreach (T vertex in _vertexes.Keys) edges.Add(new Edge<T> { Data = vertex, Weight = int.MaxValue });
            return edges;
        }

        private Edge<T> GetEdgeWithMinimunWeight(IEnumerable<Edge<T>> edges, IEnumerable<T> visitedVertex)
        {
            var minEdge = new Edge<T> { Weight = int.MaxValue };
            foreach (var edge in edges)
            {
                var visited = visitedVertex.Any(e => e.CompareTo(edge.Data) == 0);
                if (!visited && minEdge.Weight > edge.Weight) minEdge = edge;
            }
            return minEdge;
        }

        private bool IsVertexVisited(T sourceVertex, IEnumerable<T> visitedVetexList)
        {
            return visitedVetexList.Any(v => v.CompareTo(sourceVertex) == 0);
        }
    }
}
