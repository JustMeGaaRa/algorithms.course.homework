using System;

namespace Hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        private readonly HamsterCage _cage;

        public Hamster(int portion, int greed, HamsterCage cage)
        {
            _cage = cage;
            Portion = portion;
            Greed = greed;
        }

        public int Portion { get; }

        public int Greed { get; }

        public int Consumes
        {
            get { return Portion + Greed*(_cage.HamstersCount - 1); }
        }

        public int CompareTo(Hamster other)
        {
            if (Consumes < other.Consumes)
                return -1;

            if (Consumes > other.Consumes)
                return 1;

            return 0;
        }
    }
}