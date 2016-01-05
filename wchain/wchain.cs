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

            var groups = GroupSortStrings(lines);
            var keys = groups.Keys;
            int maxLevelReached = 0;

            if (keys.Count == 1)
            {
                return 1;
            }

            for (int levelIndex = 0; levelIndex < keys.Count - 1; levelIndex++)
            {
                int currentLevels = FindChainLength(groups, keys, levelIndex, 1);
                if (maxLevelReached < currentLevels)
                {
                    maxLevelReached = currentLevels;
                }
            }

            return maxLevelReached;
        }

        private int FindChainLength(SortedList<int, List<string>> groups, IList<int> keys, int levelIndex, int maxLevelReached)
        {
            if(levelIndex + 1 == keys.Count)
                return maxLevelReached;

            int currentMaximum = 0;
            int currentKey = keys[levelIndex];
            int nextKey = keys[levelIndex + 1];
            if (currentKey - nextKey == 1)
            {
                foreach (var currentLevelGroup in groups[currentKey])
                {
                    foreach (var nextLevelGroup in groups[nextKey])
                    {
                        if (MatchStrings(currentLevelGroup, nextLevelGroup))
                        {
                            int currentLevels = FindChainLength(groups, keys, levelIndex + 1, maxLevelReached + 1);
                            if (currentMaximum < currentLevels)
                            {
                                currentMaximum = currentLevels;
                            }
                        }
                    }
                }
            }

            if (currentMaximum > maxLevelReached)
            {
                maxLevelReached = currentMaximum;
            }

            return maxLevelReached;
        }

        public class Group
        {
            public Group(string word)
            {
                Word = word;
                SubGroups = new List<Group>();
            }

            public string Word { get; }

            public int Length { get { return Word.Length; } }

            public List<Group> SubGroups { get; }
        }

        public SortedList<int, List<string>> GroupSortStrings(string[] lines)
        {
            var groupSorted = new SortedList<int, List<string>>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            int count = int.Parse(lines[0]);

            for (int i = 0; i < count; i++)
            {
                string line = lines[i + 1];
                if (!groupSorted.ContainsKey(line.Length))
                {
                    groupSorted.Add(line.Length, new List<string> { line });
                }
                else
                {
                    groupSorted[line.Length].Add(line);
                }
            }

            return groupSorted;
        }

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

        private bool MatchStrings(string string1, string string2)
        {
            if (string1.Length - string2.Length != 1)
                return false;

            string aligned1;
            string aligned2;
            int penalty = AlignStrings(string1, string2, 1, 10, out aligned1, out aligned2);

            bool stringsMatch = string1.Length == aligned1.Length
                && string1.Length == aligned2.Length
                && penalty == 1;

            return stringsMatch;
        }
    }
}
