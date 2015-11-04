using System;
using System.Collections.Generic;
using discnt;

namespace hamstr
{
    public class HamsterCage
    {
        private readonly DataStructures.BinaryMaxHeap<Hamster> _hamsters;
        private long _consume;

        public HamsterCage(int foodSupplies, int initialHamstersCount)
        {
            FoodSupplies = foodSupplies;
            _hamsters = new DataStructures.BinaryMaxHeap<Hamster>(initialHamstersCount);
        }

        public int FoodSupplies { get; set; }

        public long Consume
        {
            get { return _consume; }
        }

        public int HamstersCount
        {
            get { return _hamsters.CurrentSize; }
        }

        public void AddHamster(Hamster hamster)
        {
            hamster.Cage = this;
            _hamsters.Add(hamster);
            RecalculateConsumption();
        }

        public Hamster RemoveHamster()
        {
            var hamster = _hamsters.RemoveMax();
            RecalculateConsumption();
            return hamster;
        }

        public int FeedHamsters(IEnumerable<Hamster> hamsters)
        {
            foreach (var hamster in hamsters)
            {
                AddHamster(hamster);
            }

            while (Consume > FoodSupplies)
            {
                RemoveHamster();
            }

            Console.WriteLine($"Food supplies: {FoodSupplies}");
            Console.WriteLine($"Hamsters count: {HamstersCount}");
            Console.WriteLine($"Hamsters fed: {_hamsters.CurrentSize}");
            Console.WriteLine($"Food consumed: {_consume}");

            return _hamsters.CurrentSize;
        }

        private void RecalculateConsumption()
        {
            _consume = 0;
            foreach (var current in _hamsters)
            {
                _consume += current.Consumes;
            }
        }
    }
}