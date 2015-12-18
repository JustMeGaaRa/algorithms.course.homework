using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures
{
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

        public static Pathway Dijkstra(this Graph graph, Vertex startVertex, Vertex endVertex)
        {
            var roadmap = Dijkstra(graph, startVertex);
            return roadmap[endVertex];
        }

        public static Roadmap Dijkstra(this Graph graph, Vertex startVertex)
        {
            var distnaces = graph.Vertices.ToDictionary(vertex => vertex, vertex => int.MaxValue);
            distnaces[startVertex] = 0;

            var pathVertices = new Dictionary<Vertex, Vertex>();
            var visit = graph.Vertices.ToList();

            while (visit.Count > 0)
            {
                var shortestDistanceVertex = visit[0];

                foreach (Vertex vertex in visit)
                {
                    if (distnaces[vertex] < distnaces[shortestDistanceVertex])
                    {
                        shortestDistanceVertex = vertex;
                    }
                }

                visit.Remove(shortestDistanceVertex);

                foreach (var outboundEdge in shortestDistanceVertex.OutboundEdges)
                {
                    var outboundEndVertex = outboundEdge.EndVertex;
                    int alternativeDistance = distnaces[shortestDistanceVertex] + outboundEdge.Weight;

                    if (alternativeDistance < distnaces[outboundEndVertex])
                    {
                        distnaces[outboundEndVertex] = alternativeDistance;
                        pathVertices[outboundEndVertex] = shortestDistanceVertex;
                    }
                }
            }

            return new Roadmap(pathVertices, distnaces, startVertex);
        }
    }
}