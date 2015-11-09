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
        private BinaryHeap<Hamster> _hamstersHeapTarget;
        private BinaryHeap<Hamster> _hamstersHeapSource;
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
            var lines = File.ReadLines(inputFileName).ToArray();

            // range: 0 <= S <= 1 000 000 000
            int foodSupplies = int.Parse(lines[0]);

            // range: 1 <= C <= 100 000
            int hamsterCount = int.Parse(lines[1]);

            var hamsters = GetHamsters(lines);
            var result = FeedHamsters(foodSupplies, hamsterCount, hamsters);
            File.WriteAllText(outputFileName, result.ToString());
        }

        public int FeedHamsters(int foodSupplies, int hamsterCount, IEnumerable<Hamster> hamsters)
        {
            long consumedTotal = 0;
            long greedSoFar = 0;

            _hamstersHeapTarget = new BinaryHeap<Hamster>(false, hamsterCount);
            var hamsterComparer = new HamsterComparer(_hamstersHeapTarget);
            _hamstersHeapSource = new BinaryHeap<Hamster>(true, hamsterCount, hamsterComparer);

            foreach (var hamster in hamsters)
            {
                _hamstersHeapSource.Add(hamster);
            }

            // complexity: O(N * log N) because of heap remove, heap peek
            while (consumedTotal <= foodSupplies && _hamstersHeapSource.Count > 0)
            {
                var targetHamstersCount = _hamstersHeapTarget.Count;
                var nextHamster = _hamstersHeapSource.Remove();

                long currentHamsterWillConsume = nextHamster.GetConsumption(targetHamstersCount);
                long totallyConsumedlIfAdded = consumedTotal + greedSoFar + currentHamsterWillConsume;

                // check if adding next hamster will fit the food supplies
                if (totallyConsumedlIfAdded > foodSupplies)
                {
                    //break;
                    var targetHamster = _hamstersHeapTarget.Count > 0 ? _hamstersHeapTarget.Peek() : null;
                    if (targetHamster == null)
                        break;

                    if (nextHamster.GetConsumption(targetHamstersCount) > targetHamster.GetConsumption(targetHamstersCount))
                        break;

                    var hamster = _hamstersHeapTarget.Remove();
                    _hamstersHeapTarget.Add(nextHamster);
                    //_hamstersHeapSource.Add(hamster);

                    int mates = targetHamstersCount - 1;
                    consumedTotal = consumedTotal + nextHamster.GetConsumption(mates) - targetHamster.GetConsumption(mates);
                    greedSoFar = greedSoFar + nextHamster.Greed - targetHamster.Greed;

                    continue;
                }

                consumedTotal = totallyConsumedlIfAdded;
                greedSoFar += nextHamster.Greed;
                _hamstersHeapTarget.Add(nextHamster);
            }

            Console.WriteLine($"Food supplies: {foodSupplies}");
            Console.WriteLine($"Hamsters count: {hamsterCount}");
            Console.WriteLine($"Hamsters fed: {_hamstersHeapTarget.Count}");
            Console.WriteLine($"Food consumed: {consumedTotal}");

            return _hamstersHeapTarget.Count;
        }

        private IEnumerable<Hamster> GetHamsters(string[] lines)
        {
            // complexity: O(N * log N) because of heap insert
            for (int i = 2; i < lines.Length; i++)
            {
                var numbers = lines[i].Split(' ');
                int h = int.Parse(numbers[0]);
                int g = int.Parse(numbers[1]);
                yield return new Hamster(h, g, 1);
            }
        }

        private class HamsterComparer : IComparer<Hamster>
        {
            private readonly BinaryHeap<Hamster> _hamstersHeap;

            public HamsterComparer(BinaryHeap<Hamster> hamstersHeap)
            {
                _hamstersHeap = hamstersHeap;
            }

            public int Compare(Hamster x, Hamster y)
            {
                return x.GetConsumption(_hamstersHeap.Count).CompareTo(y.GetConsumption(_hamstersHeap.Count));
            }
        }
    }
}
