namespace Common.DataStructures
{
    using System.Collections.Generic;

    public class Graph
    {
        public Graph()
        {
            Vertices = new HashSet<Vertex>();
            Edges = new HashSet<Edge>();
        }

        public Graph(List<Vertex> vertices, List<Edge> edges)
        {
            Vertices = new HashSet<Vertex>(vertices);
            Edges = new HashSet<Edge>(edges);
        }

        public HashSet<Vertex> Vertices { get; private set; }

        public HashSet<Edge> Edges { get; private set; }

        public void Parse(string[] lines)
        {
            int vectexCount = int.Parse(lines[0]);
            int edgeCount = int.Parse(lines[1]);
            var vertices = new Dictionary<string, Vertex>();
            var edges = new HashSet<Edge>();

            for (int i = 1; i <= vectexCount; i++)
            {
                var label = i.ToString();
                vertices.Add(label, new Vertex(label));
            }

            for (int i = 0; i < edgeCount; i++)
            {
                var labels = lines[i + 2].Split(' ');
                var startLabel = labels[0];
                var endLabel = labels[1];
                var weight = labels.Length > 2 ? int.Parse(labels[2]) : 1;

                var startVertex = vertices[startLabel];
                var endVertex = vertices[endLabel];
                var edge = new Edge(startVertex, endVertex, weight);

                edges.Add(edge);
                startVertex.OutboundEdges.Add(edge);
                endVertex.InboundEdges.Add(edge);
            }

            Vertices = new HashSet<Vertex>(vertices.Values);
            Edges = new HashSet<Edge>(edges);
        }

        public bool AddVertex(Vertex vertex)
        {
            return Vertices.Add(vertex);
        }

        public bool AddEdge(Edge edge)
        {
            if (Vertices.Contains(edge.StartVertex) || Vertices.Contains(edge.EndVertex))
                return false;

            return Edges.Add(edge);
        }
    }
}