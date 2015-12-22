using System;
using System.Collections.Generic;

namespace Common.DataStructures
{
    public class Vertex : IEquatable<Vertex>
    {
        public Vertex(string label)
        {
            Label = label;
            InboundEdges = new List<Edge>();
            OutboundEdges = new List<Edge>();
        }

        public string Label { get; set; }

        public List<Edge> InboundEdges { get; }

        public List<Edge> OutboundEdges { get; }

        public bool Equals(Vertex other)
        {
            return other != null
                   && Label.Equals(other.Label)
                   && InboundEdges.Count.Equals(other.InboundEdges.Count)
                   && OutboundEdges.Count.Equals(other.OutboundEdges.Count);
        }

        public override string ToString()
        {
            return $"Label: {Label},\t Outbound Edges: {InboundEdges.Count},\t Inbound Edges: {OutboundEdges.Count}";
        }

        public override int GetHashCode()
        {
            return Label.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex);
        }
    }
}