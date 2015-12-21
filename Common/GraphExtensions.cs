using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures
{
    public static class GraphExtensions
    {
        /// <summary>
        /// Breadth-First-Search algorithm that traverses the graph
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <param name="startVertex"> <see cref="Vertex"/> to start traversing from. </param>
        /// <param name="endVertex"> <see cref="Vertex"/> to end traversing at. </param>
        /// <returns> The traversed path. </returns>
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

        /// <summary>
        /// Depth-First-Search algorithm that traverses the graph
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <param name="startVertex"> <see cref="Vertex"/> to start traversing from. </param>
        /// <param name="endVertex"> <see cref="Vertex"/> to end traversing at. </param>
        /// <returns> The traversed path. </returns>
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

        /// <summary>
        /// Dijkstras algorithm that traverses the graph to find shortest path
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <param name="startVertex"> The start <see cref="Vertex"/> of path to calculate minimum distance for. </param>
        /// <param name="endVertex"> The end <see cref="Vertex"/> of path to calculate minimum distance for. </param>
        /// <returns> The shortest (minimum cost) path from starting point to ending point. </returns>
        public static Pathway Dijkstra(this Graph graph, Vertex startVertex, Vertex endVertex)
        {
            var roadmap = Dijkstra(graph, startVertex);
            return roadmap[endVertex];
        }

        /// <summary>
        /// Dijkstras algorithm that traverses the graph to find shortest path
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <param name="startVertex"> The start <see cref="Vertex"/> of path to calculate minimum distance for. </param>
        /// <returns> The shortest (minimum cost) path from starting point to all other. </returns>
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

        /// <summary>
        /// Tarjans algorithm to topologically sort the graph
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <returns> The topologically sorted strongly connected conponents. </returns>
        public static IEnumerable<Vertex> Tarjan(this Graph graph)
        {
            bool isDirectlyAsyclicGraph = true;
            var topologicalOrder = new List<Vertex>();
            var visitedVertices = new Dictionary<Vertex, TarjansVisitStatus>();

            foreach (var vertex in graph.Vertices)
            {
                isDirectlyAsyclicGraph &= TarjanDfsRecursive(vertex, topologicalOrder, visitedVertices);
            }

            return topologicalOrder;
        }

        /// <summary>
        /// Recursive function for vertex traversal for Tarjans algorithm
        /// </summary>
        /// <param name="vertex"> <see cref="Vertex"/> instance to start traversing from. </param>
        /// <param name="topologicalOrder"> List of topologically sorted vertices so far. </param>
        /// <param name="visitedVertices"> Map of vertices status traversed so far. </param>
        /// <returns> Returns true if graph is a Directed Acyclic Graph. </returns>
        private static bool TarjanDfsRecursive(Vertex vertex, List<Vertex> topologicalOrder, Dictionary<Vertex, TarjansVisitStatus> visitedVertices)
        {
            if (!visitedVertices.ContainsKey(vertex))
            {
                visitedVertices.Add(vertex, TarjansVisitStatus.NotVisited);
            }

            if (visitedVertices[vertex] == TarjansVisitStatus.Visited)
            {
                return false;
            }

            if (visitedVertices[vertex] == TarjansVisitStatus.NotVisited)
            {
                visitedVertices[vertex] = TarjansVisitStatus.Visited;

                foreach (var outboundEdge in vertex.OutboundEdges)
                {
                    TarjanDfsRecursive(outboundEdge.EndVertex, topologicalOrder, visitedVertices);
                }

                visitedVertices[vertex] = TarjansVisitStatus.Resolved;
                topologicalOrder.Add(vertex);
            }

            return true;
        }

        /// <summary>
        /// Vertex visit status for Tarjan's algorithm
        /// </summary>
        private enum TarjansVisitStatus
        {
            NotVisited = 0,
            Visited = 1,
            Resolved = 2
        }
    }
}