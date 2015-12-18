using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures
{
    using System.Collections;

    public class Graph
    {
        private readonly Dictionary<string, Vertex> _vertices;
        private readonly Dictionary<Tuple<string, string>, Edge> _edges;

        private ICollection<Vertex> _cachedVertices;
        private ICollection<Edge> _cachedEdges;

        public Graph()
        {
            _vertices = new Dictionary<string, Vertex>();
            _edges = new Dictionary<Tuple<string, string>, Edge>();
        }

        public Graph(IEnumerable<Vertex> vertices, IEnumerable<Edge> edges)
        {
            _vertices = new Dictionary<string, Vertex>();
            _edges = new Dictionary<Tuple<string, string>, Edge>();

            AddVertices(vertices);
            AddEdges(edges);
        }

        public Vertex this[string label]
        {
            get
            {
                return _vertices[label];
            }
        }

        public Edge this[string startLabel, string endLabel]
        {
            get
            {
                var key = new Tuple<string, string>(startLabel, endLabel);
                return _edges[key];
            }
        }

        public Edge this[Vertex strartVertex, Vertex endVertex]
        {
            get
            {
                return this[strartVertex.Label, endVertex.Label];
            }
        }

        public IEnumerable<Vertex> Vertices
        {
            get
            {
                return _cachedVertices ?? (_cachedVertices = _vertices.Values);
            }
        }

        public IEnumerable<Edge> Edges
        {
            get
            {
                return _cachedEdges ?? (_cachedEdges = _edges.Values);
            }
        }

        public void Parse(string[] lines)
        {
            int vectexCount = int.Parse(lines[0]);
            int edgeCount = int.Parse(lines[1]);

            for (int i = 0; i < edgeCount; i++)
            {
                var labels = lines[i + 2].Split(' ');
                var startLabel = labels[0];
                var endLabel = labels[1];
                var weight = labels.Length > 2 ? int.Parse(labels[2]) : 1;

                if (!_vertices.ContainsKey(startLabel))
                {
                    this.SetVertex(new Vertex(startLabel));
                }

                if (!_vertices.ContainsKey(endLabel))
                {
                    this.SetVertex(new Vertex(endLabel));
                }

                var startVertex = _vertices[startLabel];
                var endVertex = _vertices[endLabel];

                this.SetEdge(new Edge(startVertex, endVertex, weight));
            }
        }

        public bool SetVertex(Vertex vertex)
        {
            if (vertex == null)
                return false;

            _vertices[vertex.Label] = vertex;
            _cachedVertices = null;

            return true;
        }

        public bool SetEdge(Edge edge)
        {
            if (edge == null)
                return false;

            var key = new Tuple<string, string>(edge.StartVertex.Label, edge.EndVertex.Label);
            _edges[key] = edge;
            _cachedEdges = null;

            return true;
        }

        private bool AddVertices(IEnumerable<Vertex> vertices)
        {
            return vertices.Aggregate(true, (current, vertex) => current & this.SetVertex(vertex));
        }

        private bool AddEdges(IEnumerable<Edge> edges)
        {
            return edges.Aggregate(true, (current, edge) => current & this.SetEdge(edge));
        }
    }

    public class Roadmap
    {
        private readonly IDictionary<Vertex, Vertex> _roadmap;

        private readonly IDictionary<Vertex, int> _distances;

        private readonly IDictionary<Vertex, Pathway> _pathways;

        public Roadmap(IDictionary<Vertex, Vertex> roadmap, IDictionary<Vertex, int> distances, Vertex startVertex)
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

            return new Pathway(pathVertices, _distances[endVertex]);
        }
    }

    public class Pathway : IEnumerable<Vertex>
    {
        public Pathway(IEnumerable<Vertex> vertices, int distance)
        {
            Vertices = vertices;
            Distance = distance;
        }

        public IEnumerable<Vertex> Vertices { get; set; }

        public int Distance { get; set; }

        public IEnumerator<Vertex> GetEnumerator()
        {
            return Vertices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}