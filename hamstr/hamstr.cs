using System;
using System.IO;
using System.Linq;

namespace hamstr
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
            try
            {
                var lines = File.ReadLines(inputFileName).ToArray();

                // 0 <= S <= 1 000 000 000
                int foodSupplies = int.Parse(lines[0]);

                // 1 <= C <= 100 000
                int hamsterCount = int.Parse(lines[1]);

                DataStructures.BinaryMaxHeap<Hamster> hamsters = new DataStructures.BinaryMaxHeap<Hamster>(hamsterCount);
                for (int i = 2; i < hamsterCount; i++)
                {
                    var numbers = lines[i].Split(' ');
                    int h = int.Parse(numbers[0]);
                    int g = int.Parse(numbers[1]);
                    var hamster = new Hamster(h, g, hamsterCount - 1);
                    hamsters.Add(hamster);
                }

                var result = FeedHamsters(foodSupplies, hamsters);
                File.WriteAllText(outputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int FeedHamsters(int foodSupplies, DataStructures.BinaryMaxHeap<Hamster> hamsters)
        {
            long consumedTotal = 0;
            long greedSoFar = 0;
            int hamstersCount = 0;
            var hamster = hamsters.GetEnumerator();

            while (hamster.MoveNext())
            {
                long currentHamsterConsumes = hamster.Current.GetConsumption(hamstersCount);
                long consumptionTotalIfAdded = consumedTotal + greedSoFar + currentHamsterConsumes;

                if (consumptionTotalIfAdded > foodSupplies)
                    break;

                consumedTotal = consumptionTotalIfAdded;
                greedSoFar += hamster.Current.Greed;
                hamstersCount++;
            }

            Console.WriteLine($"Food supplies: {foodSupplies}");
            Console.WriteLine($"Hamsters count: {hamsters.CurrentSize}");
            Console.WriteLine($"Hamsters fed: {hamstersCount}");
            Console.WriteLine($"Food consumed: {consumedTotal}");

            return hamstersCount;
        }
    }
}
