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
    }
}