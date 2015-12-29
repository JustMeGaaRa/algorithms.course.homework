using System;
using System.IO;
using System.Linq;

namespace career
{
    public class Career
    {
        private static void Main(string[] args)
        {
            var career = new Career();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "career.in";
                outputFileName = "career.out";
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

            career.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadAllLines(inputFileName);
            var result = FindMaximumExpirience(lines);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int FindMaximumExpirience(string[] lines)
        {
            int maximumExpirience = 0;
            int levels = int.Parse(lines[0]);

            if (levels > 1)
            {
                int[][] original = new int[levels][];
                int[][] solutions = new int[levels + 1][];
                solutions[0] = new int[levels + 1];
                
                for (int i = 1; i < levels + 1; i++)
                {
                    // get original values
                    original[i - 1] = lines[levels + 1 - i].Split(' ').Select(int.Parse).ToArray();

                    // allocate space for those values
                    solutions[i] = new int[levels + 1 - i];

                    for (int j = 0; j < levels + 1 - i; j++)
                    {
                        // get maximum from 2 cases
                        // case 1: left child + value (j)
                        // case 2: right child + value (j + 1)
                        int case1 = solutions[i - 1][j] + original[i - 1][j];
                        int case2 = solutions[i - 1][j + 1] + original[i - 1][j];
                        solutions[i][j] = Math.Max(case1, case2);
                    }
                }

                maximumExpirience = solutions[levels][0];
            }

            return maximumExpirience;
        }
    }
}
