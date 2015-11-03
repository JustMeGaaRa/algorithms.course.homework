using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using discnt;

namespace Hamstr
{
    public class Hamstr
    {
        private static void Main(string[] args)
        {
            var hamstr = new Hamstr();
            string inputFileName;
            string outputFileName;

            if (args == null || args.Length == 0)
            {
                inputFileName = "hamstr.in";
                outputFileName = "hamstr.out";
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

            hamstr.Run(inputFileName, outputFileName);
        }

        public void Run(string inputFileName, string outputFileName)
        {
            var lines = File.ReadLines(inputFileName).ToArray();

            // 0 <= S <= 1 000 000 000
            int foodSupplies = int.Parse(lines[0]);

            // 1 <= C <= 100 000
            int hamsterCount = int.Parse(lines[1]);

            var hamsters = lines.Skip(2).Select(line =>
            {
                var numbers = line.Split(' ');
                int h = int.Parse(numbers[0]);
                int g = int.Parse(numbers[1]);
                return new Hamster(h, g, hamsterCount - 1);
            });
            
            var result = FeedHamsters(foodSupplies, hamsterCount, hamsters);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int FeedHamsters(int foodSupplies, int hamsterCount, IEnumerable<Hamster> hamsters)
        {
            var hamstersArray = hamsters.ToArray();
            if (hamstersArray.Length < 100)
            {
                Arrays.SelectionSort(hamstersArray);
            }
            else
            {
                Arrays.MergeSort(hamstersArray);
            }

            return 0;
        }
    }
}
