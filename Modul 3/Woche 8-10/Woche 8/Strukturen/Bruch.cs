namespace Strukturen
{
    struct Bruch
    {
        public int Zähler { get; }
        public int Nenner { get; }

        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner == 0 ? 1 : nenner;
        }

        public double AlsDezimalwert() => (double)Zähler / Nenner;
    }
}
