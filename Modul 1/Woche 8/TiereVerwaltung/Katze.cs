namespace TiereVerwaltung
{
    class Katze : Tier
    {
        public bool HatKrallen { get; private set; }

        public Katze(string name, int alter, double gewicht, bool hatKrallen)
            : base(ArtType.Katze, name, alter, gewicht)
        {
            HatKrallen = hatKrallen;
        }
    }

}
