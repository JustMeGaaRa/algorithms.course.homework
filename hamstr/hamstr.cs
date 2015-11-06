using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Algorithms;
using Common.DataStructures;

namespace hamstr
{
    public class Hamstr
    {
        private BinaryHeap<Hamster> _hamstersHeap;
        private List<Hamster> _hamstersList;

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

                // range: 0 <= S <= 1 000 000 000
                int foodSupplies = int.Parse(lines[0]);

                // range: 1 <= C <= 100 000
                int hamsterCount = int.Parse(lines[1]);

                var hamsters = new Hamster[hamsterCount];
                //_hamstersHeap = new BinaryHeap<Hamster>(BinaryHeapOrder.Minimum, hamsterCount);
                //_hamstersList = new List<Hamster>();

                // complexity: O(N * log N) because of heap insert
                for (int i = 2; i < hamsterCount + 2; i++)
                {
                    var numbers = lines[i].Split(' ');
                    int h = int.Parse(numbers[0]);
                    int g = int.Parse(numbers[1]);
                    var hamster = new Hamster(h, g, hamsterCount - 1);
                    hamsters[i - 2] = hamster;
                    //_hamstersHeap.Add(hamster);
                }

                var result = FeedHamsters(foodSupplies, hamsters);
                File.WriteAllText(outputFileName, result.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public int FeedHamsters(int foodSupplies, Hamster[] hamsters)
        {
            long consumedTotal = 0;
            long greedSoFar = 0;
            int hamstersCount = 0;
            Arrays.MergeSort(hamsters);

            // complexity: O(N * log N) because of heap remove, heap peek
            while (hamstersCount < hamsters.Length)
            {
                long currentHamsterWillConsume = hamsters[hamstersCount].GetConsumption(hamstersCount);
                long totallyConsumedlIfAdded = consumedTotal + greedSoFar + currentHamsterWillConsume;

                // check if adding next hamster will fit the food supplies
                if (totallyConsumedlIfAdded > foodSupplies)
                {
                    //var firstHamsterAdded = _hamstersList.FirstOrDefault();
                    //var nextHamsterToAdd = hamsters[hamstersCount];
                    //if (firstHamsterAdded != null && nextHamsterToAdd != null)
                    //{
                    //    // check if removing the hamster that consumes the most
                    //    // and adding next hamsterwill reduce the total consumption
                    //    long firstHamserConsumes = firstHamsterAdded.GetConsumption(hamstersCount);
                    //    long nextHamsterWillConsume = nextHamsterToAdd.GetConsumption(hamstersCount);

                    //    // check if first added consumes more that next one
                    //    // and if it is better to replace him with next one
                    //    if (firstHamserConsumes > nextHamsterWillConsume)
                    //    {
                    //        consumedTotal = consumedTotal - firstHamsterAdded.GetConsumption(hamstersCount - 1) + nextHamsterToAdd.GetConsumption(hamstersCount - 1);
                    //        greedSoFar = greedSoFar - firstHamsterAdded.Greed + nextHamsterToAdd.Greed;
                    //        continue;
                    //    }
                    //}

                    break;
                }

                consumedTotal = totallyConsumedlIfAdded;
                greedSoFar += hamsters[hamstersCount].Greed;
                //_hamstersList.Add(hamsters[hamstersCount]);
                hamstersCount++;
            }

            Console.WriteLine($"Food supplies: {foodSupplies}");
            Console.WriteLine($"Hamsters count: {hamsters.Length}");
            Console.WriteLine($"Hamsters fed: {hamstersCount}");
            Console.WriteLine($"Food consumed: {consumedTotal}");

            return hamstersCount;
        }
    }
}
