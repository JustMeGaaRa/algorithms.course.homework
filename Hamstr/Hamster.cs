using System;

namespace Hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        private readonly int _mates;
        private readonly int _comparementValue;

        public Hamster(int portion, int greed, int mates)
        {
            Portion = portion;
            Greed = greed;
            _mates = mates;
            _comparementValue = portion + greed * mates;
        }

        public int Portion { get; private set; }

        public int Greed { get; private set; }

        public int CompareTo(Hamster other)
        {
            if (_comparementValue < other._comparementValue)
                return -1;

            if (_comparementValue > other._comparementValue)
                return 1;

            return 0;
        }
    }
}