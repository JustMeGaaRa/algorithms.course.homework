using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures
{
    using System;

    public static class GraphExtensions
    {
        public static IEnumerable<Vertex> BreadthFirstSearch(this Graph graph, Vertex startVertex, Vertex endVertex)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();
            var queue = new Queue<Vertex>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                if (visited.Contains(currentVertex))
                    continue;

                visited.Add(currentVertex);
                var neighbors = currentVertex.OutboundEdges.Where(edge => !visited.Contains(edge.EndVertex)).Select(edge => edge.EndVertex);

                result.Add(currentVertex);

                foreach (var neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }

            return result;
        }

        public static IEnumerable<Vertex> DepthFirstSearch(this Graph graph, Vertex startVertex, Vertex endVertex)
        {
            var result = new List<Vertex>();
            var visited = new HashSet<Vertex>();
            var stack = new Stack<Vertex>();
            stack.Push(startVertex);

            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();

                if (visited.Contains(currentVertex))
                    continue;

                visited.Add(currentVertex);
                var neighbors = currentVertex.OutboundEdges.Where(edge => !visited.Contains(edge.EndVertex)).Select(edge => edge.EndVertex);

                result.Add(currentVertex);

                foreach (var neighbor in neighbors)
                {
                    stack.Push(neighbor);
                }
            }

            return result;
        }

        public static IEnumerable<Vertex> Dijkstra(this Graph graph, Vertex startVertex)
        {
            const int INFINITY = int.MaxValue;
            var distnaces = graph.Vertices.ToDictionary(vertex => vertex.Label, vertex => INFINITY);
            var path = new HashSet<Vertex>();
            var visit = graph.Vertices.ToList();

            //while (visit.Count > 0)
            //{
            //    var shortestDistanceVertex = visit[0];

            //    for (int i = 0; i < visit.Count; i++)
            //    {
            //        if (distnaces[visit[i].Label] < distnaces[shortestDistanceVertex.Label])
            //        {
            //            shortestDistanceVertex = visit[i];
            //        }
            //    }

            //    visit.Remove(shortestDistanceVertex);


            //}

            return path;
        }
    }
}