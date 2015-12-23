using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.DataStructures;

namespace Common.Algorithms
{
    public static class GraphExtensions
    {
        public static void Parse(this Graph graph, string[] lines, bool directedGraph = false)
        {
            foreach (string line in lines)
            {
                var labels = line.Split(' ');
                var startLabel = labels[0];
                var endLabel = labels[1];
                var weight = labels.Length > 2 ? int.Parse(labels[2]) : 1;

                if (!graph.ContainsVertex(startLabel))
                {
                    graph.SetVertex(new Vertex(startLabel));
                }

                if (!graph.ContainsVertex(endLabel))
                {
                    graph.SetVertex(new Vertex(endLabel));
                }

                var startVertex = graph[startLabel];
                var endVertex = graph[endLabel];

                graph.SetEdge(new Edge(startVertex, endVertex, weight));

                if (!directedGraph)
                {
                    graph.SetEdge(new Edge(endVertex, startVertex, weight));
                }
            }
        }

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
            var distnaces = graph.Vertices.ToDictionary(vertex => vertex, vertex => long.MaxValue);
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
                    long alternativeDistance = distnaces[shortestDistanceVertex] + outboundEdge.Weight;

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
            var topologicalOrder = new List<Vertex>();
            var visitedVertices = new Dictionary<Vertex, TarjansVisitStatus>();

            foreach (var vertex in graph.Vertices)
            {
                if (!TarjanDfsRecursive(vertex, topologicalOrder, visitedVertices))
                {
                    throw new NotDirectlyAcyclicGraphException();
                }
            }

            return topologicalOrder;
        }

        /// <summary>
        /// Prim's algorithm to find the minimum span tree on graph
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <returns> Minimum span tree containing edges and minimum distance. </returns>
        public static MinimumSpanTree PrimsMinimumSpanningTree(this Graph graph)
        {
            var currentVertex = graph.Vertices.FirstOrDefault();
            if (currentVertex == null)
                return new MinimumSpanTree(Enumerable.Empty<Edge>().ToList(), 0);

            int minimumDistance = 0;
            var minimumSpanTree = new List<Edge>();
            var edgesToVisit = new BinaryHeap<Edge>(BinaryHeapType.MinimumHeap, currentVertex.OutboundEdges.Count, new EdgeComparer());
            var verticesVisited = new HashSet<Vertex>();

            while (minimumSpanTree.Count < graph.Vertices.Count - 1)
            {
                foreach (var edge in currentVertex.OutboundEdges)
                {
                    edgesToVisit.Add(edge);
                }

                verticesVisited.Add(currentVertex);
                Edge minimumEdge = null;

                while (edgesToVisit.Count > 0)
                {
                    minimumEdge = edgesToVisit.Remove();
                    if (verticesVisited.Contains(minimumEdge.StartVertex) != verticesVisited.Contains(minimumEdge.EndVertex))
                        break;
                }

                if (minimumEdge == null)
                {
                    throw new MultipleMinimumSpanningTreesException();
                }

                minimumSpanTree.Add(minimumEdge);
                minimumDistance += minimumEdge.Weight;
                currentVertex = verticesVisited.Contains(minimumEdge.EndVertex)
                                      ? minimumEdge.StartVertex
                                      : minimumEdge.EndVertex;
            }

            return new MinimumSpanTree(minimumSpanTree, minimumDistance);
        }

        /// <summary>
        /// Kruskal's algorithm to find the minimum span tree on graph
        /// </summary>
        /// <param name="graph"> <see cref="Graph"/> instance. </param>
        /// <returns> Minimum span tree containing edges and minimum distance. </returns>
        public static MinimumSpanTree KruskalsMinimumSpanningTree(this Graph graph)
        {
            return new MinimumSpanTree(Enumerable.Empty<Edge>().ToList(), 0);
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

        private class EdgeComparer : IComparer<Edge>
        {
            public int Compare(Edge x, Edge y)
            {
                if (x.Weight < y.Weight)
                {
                    return -1;
                }

                if (x.Weight > y.Weight)
                {
                    return 1;
                }

                return 0;
            }
        }

        public class Roadmap
        {
            private readonly IDictionary<Vertex, Vertex> _roadmap;

            private readonly IDictionary<Vertex, long> _distances;

            private readonly IDictionary<Vertex, Pathway> _pathways = new Dictionary<Vertex, Pathway>();

            public Roadmap(IDictionary<Vertex, Vertex> roadmap, IDictionary<Vertex, long> distances, Vertex startVertex)
            {
                _roadmap = roadmap;
                _distances = distances;
                StartVertex = startVertex;
            }

            public Pathway this[Vertex endVertex]
            {
                get
                {
                    if (!_pathways.ContainsKey(endVertex))
                    {
                        _pathways[endVertex] = ReconstructPath(endVertex);
                    }

                    return _pathways[endVertex];
                }
            }

            public Vertex StartVertex { get; }

            public Pathway ReconstructPath(Vertex endVertex)
            {
                var predcessor = _roadmap[endVertex];
                var pathVertices = new Stack<Vertex>();
                pathVertices.Push(endVertex);

                while (predcessor != null)
                {
                    pathVertices.Push(predcessor);
                    predcessor = _roadmap.ContainsKey(predcessor) ? _roadmap[predcessor] : null;
                }

                return new Pathway(pathVertices.ToList(), _distances[endVertex]);
            }
        }

        public class Pathway : IEnumerable<Vertex>
        {
            public Pathway(ICollection<Vertex> vertices, long distance)
            {
                Vertices = vertices;
                Distance = distance;
            }

            public ICollection<Vertex> Vertices { get; set; }

            public long Distance { get; set; }

            public IEnumerator<Vertex> GetEnumerator()
            {
                return Vertices.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public class MinimumSpanTree : IEnumerable<Edge>
        {
            public MinimumSpanTree(ICollection<Edge> edges, int distance)
            {
                Edges = edges;
                Distance = distance;
            }

            public ICollection<Edge> Edges { get; }

            public int Distance { get; set; }

            public IEnumerator<Edge> GetEnumerator()
            {
                return Edges.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }

    public class MultipleMinimumSpanningTreesException : Exception
    {
    }

    public class NotDirectlyAcyclicGraphException : Exception
    {
    }
}