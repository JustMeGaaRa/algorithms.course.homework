using System;

namespace hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        private readonly int _mates;

        public Hamster(int portion, int greed, int mates)
        {
            _mates = mates;
            Portion = portion;
            Greed = greed;
        }

        public long Portion { get; }

        public long Greed { get; }

        public long GetConsumption(int mates)
        {
            return Portion + Greed * mates;
        }

        public int CompareTo(Hamster other)
        {
            if (GetConsumption(_mates) < other.GetConsumption(_mates))
                return -1;

            if (GetConsumption(_mates) > other.GetConsumption(_mates))
                return 1;

            return 0;
        }
    }
}