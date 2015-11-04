using System;

namespace hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        public Hamster(int portion, int greed)
        {
            Portion = portion;
            Greed = greed;
        }

        public long Portion { get; }

        public long Greed { get; }

        public HamsterCage Cage { get; set; }

        public long Consumes
        {
            get { return Portion + Greed * (Cage.HamstersCount - 1); }
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