using System;

namespace hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        private readonly int _mates;
        private readonly long _consumeTotal;

        public Hamster(int portion, int greed, int mates)
        {
            Portion = portion;
            Greed = greed;
            _mates = mates;
            _consumeTotal = GetConsumption(_mates);
        }

        public long Portion { get; }

        public long Greed { get; }

        public long GetConsumption(int mates)
        {
            return Portion + Greed * mates;
        }

        public int CompareTo(Hamster other)
        {
            return _consumeTotal.CompareTo(other._consumeTotal);
        }

        public override string ToString()
        {
            return $"Portion: {Portion}, Greed: {Greed}";
        }
    }
}