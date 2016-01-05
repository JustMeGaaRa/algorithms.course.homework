using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace wchain
{
    public class Wchain
    {
        private static void Main(string[] args)
        {
            var wchain = new Wchain();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "wchain.in";
                outputFileName = "wchain.out";
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

            wchain.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var result = FindMaximumChainLength(lines);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int FindMaximumChainLength(string[] lines)
        {
            if (lines.Length == 1)
            {
                return 0;
            }

            var words = new HashSet<string>(lines);
            var wordsMapping = new Dictionary<string, StringNode>();

            for (int i = 1; i < lines.Length; i++)
            {
                string word = lines[i];

                if (!wordsMapping.ContainsKey(word))
                {
                    var wordNode = new StringNode(word);
                    wordsMapping[word] = wordNode;
                }

                for (int j = 0; j < word.Length; j++)
                {
                    var newWord = word.Remove(j, 1);
                    if (words.Contains(newWord))
                    {
                        if (!wordsMapping.ContainsKey(newWord))
                        {
                            wordsMapping.Add(newWord, new StringNode(newWord));
                        }
                        var newWordNode = wordsMapping[newWord];
                        wordsMapping[word].Children.Add(newWordNode);
                    }
                }
            }

            var nodes = wordsMapping.Values;
            var visited = new HashSet<StringNode>();
            int maxDepth = 1;

            foreach (var node in nodes)
            {
                visited.Clear();
                visited.Add(node);
                int currentDepth = ExpandNode(node, visited, 1);
                if (currentDepth > maxDepth)
                {
                    maxDepth = currentDepth;
                }
            }

            return maxDepth;
        }

        private int ExpandNode(StringNode node, HashSet<StringNode> visited, int depth)
        {
            int maxDepth = depth;
            foreach (var child in node.Children)
            {
                if (!visited.Contains(child))
                {
                    visited.Add(child);
                    int currentDepth = ExpandNode(child, visited, depth + 1);
                    if (currentDepth > maxDepth)
                    {
                        maxDepth = currentDepth;
                    }
                }
            }

            return maxDepth;
        }

        private class StringNode
        {
            public StringNode(string word)
            {
                Word = word;
                Children = new List<StringNode>();
            }

            public string Word { get; }

            public List<StringNode> Children { get; }
        }

        #region Sequence Alignement

        public int AlignStrings(
            string string1, 
            string string2, 
            int spacePenalty, 
            int replacePenalty, 
            out string aligned1, 
            out string aligned2)
        {
            var solutions = new int[string1.Length + 1, string1.Length + 1];

            for (int i = 0; i < string1.Length + 1; i++)
            {
                solutions[i, 0] = solutions[0, i] = i * spacePenalty;
            }

            for (int i = 1; i < string1.Length + 1; i++)
            {
                for (int j = 1; j < string2.Length + 1; j++)
                {
                    int penalty = string1[i - 1] != string2[j - 1] ? replacePenalty : 0;
                    var case1 = solutions[i - 1, j - 1] + penalty;
                    var case2 = solutions[i - 1, j] + spacePenalty;
                    var case3 = solutions[i, j - 1] + spacePenalty;
                    solutions[i, j] = new[] {case1, case2, case3}.Min();
                }
            }
            
            ReconstructStrings(string1, string2, solutions, spacePenalty, replacePenalty, out aligned1, out aligned2);
            return solutions[string1.Length, string2.Length];
        }

        private void ReconstructStrings(
            string original1, 
            string original2, 
            int[,] solutions, 
            int spacePenalty,
            int replacePenalty,
            out string aligned1, 
            out string aligned2)
        {
            aligned1 = string.Empty;
            aligned2 = string.Empty;

            int i = original1.Length;
            int j = original2.Length;

            while (!(i == 0 && j == 0))
            {
                int penalty = (i > 0 && j > 0 && original1[i - 1] != original2[j - 1]) ? replacePenalty : 0;
                var case1 = (i > 0 && j > 0) ? solutions[i - 1, j - 1] + penalty : int.MaxValue;
                var case2 = i > 0 ? solutions[i - 1, j] + spacePenalty : int.MaxValue;
                var case3 = j > 0 ? solutions[i, j - 1] + spacePenalty : int.MaxValue;
                var solution = new[] { case1, case2, case3 }.Min();

                if (solution == case1)
                {
                    aligned1 = original1[i - 1] + aligned1;
                    aligned2 = original2[j - 1] + aligned2;
                    i--;
                    j--;
                }
                else if (solution == case2)
                {
                    aligned1 = original1[i - 1] + aligned1;
                    aligned2 = " " + aligned2;
                    i--;
                }
                else if (solution == case3)
                {
                    aligned1 = " " + aligned1;
                    aligned2 = original2[j - 1] + aligned2;
                    j--;
                }
            }
        }

        #endregion
    }
}
