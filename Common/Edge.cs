namespace Common.DataStructures
{
    using System;

    public class Edge : IEquatable<Edge>
    {
        public Edge(Vertex startVertex, Vertex endVertex, int weight)
        {
            StartVertex = startVertex;
            EndVertex = endVertex;
            Weight = weight;
        }

        public Vertex StartVertex { get; }

        public Vertex EndVertex { get; }

        public int Weight { get; }

        public bool Equals(Edge other)
        {
            return other != null
                   && StartVertex.Equals(other.StartVertex)
                   && EndVertex.Equals(other.EndVertex)
                   && Weight.Equals(other.Weight);
        }

        public override string ToString()
        {
            return $"Start Vertex: {StartVertex.Label} \t------- {Weight} ------>\t End Vertex: {EndVertex.Label}";
        }

        public override int GetHashCode()
        {
            return StartVertex.GetHashCode() ^ EndVertex.GetHashCode() ^ Weight;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge);
        }
    }
}