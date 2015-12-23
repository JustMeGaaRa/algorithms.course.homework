using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Common.Algorithms;
using Common.DataStructures;

namespace gamsrv
{
    public class Gamsrv
    {
        private static void Main(string[] args)
        {
            var gamsrv = new Gamsrv();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "gamsrv.in";
                outputFileName = "gamsrv.out";
            }
            else if (args.Length == 2)
            {
                inputFileName = args[0];
                outputFileName = args[1];
            }
            else
            {
                Console.WriteLine("Command line parameters violation!");
                return;
            }

            gamsrv.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            long minimumLatency = FindMinimumLatency(lines);
            File.WriteAllText(outputFileName, minimumLatency.ToString());
        }

        public long FindMinimumLatency(string[] lines)
        {
            var graph = new Graph();
            graph.Parse(lines.Skip(2).ToArray());
            var clientVerticesLabels = lines[1].Split(' ');
            var clientVertices = new HashSet<Vertex>(clientVerticesLabels.Select(vertexLabel => graph[vertexLabel]));
            long minimumLatency = long.MaxValue;

            foreach (var currentVertex in graph.Vertices.Where(vertex => !clientVertices.Contains(vertex)))
            {
                var roadmap = graph.Dijkstra(currentVertex);
                var currentMinimumLatency = clientVertices.Max(x => roadmap[x].Distance);
                if (currentMinimumLatency < minimumLatency)
                {
                    minimumLatency = currentMinimumLatency;
                }
            }

            return minimumLatency;
        }
    }
}
