using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.DataStructures
{
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

        public ICollection<Vertex> Vertices
        {
            get
            {
                return _cachedVertices ?? (_cachedVertices = _vertices.Values);
            }
        }

        public ICollection<Edge> Edges
        {
            get
            {
                return _cachedEdges ?? (_cachedEdges = _edges.Values);
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

        public bool ContainsVertex(string label)
        {
            return _vertices.ContainsKey(label);
        }

        public bool ContainsEdge(string startLabel, string endLabel)
        {
            return _edges.ContainsKey(new Tuple<string, string>(startLabel, endLabel));
        }

        private bool AddVertices(IEnumerable<Vertex> vertices)
        {
            return vertices.Aggregate(true, (current, vertex) => current & SetVertex(vertex));
        }

        private bool AddEdges(IEnumerable<Edge> edges)
        {
            return edges.Aggregate(true, (current, edge) => current & SetEdge(edge));
        }
    }
}