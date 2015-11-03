using System;

namespace Hamstr
{
    public class Hamster : IComparable<Hamster>
    {
        public Hamster(int portion, int greed, int mates)
        {
            Portion = portion;
            Greed = greed;
            Consumes = portion + greed * mates;
        }

        public int Portion { get; private set; }

        public int Greed { get; private set; }

        public int Consumes { get; private set; }

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