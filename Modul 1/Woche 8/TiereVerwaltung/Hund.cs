namespace TiereVerwaltung
{
    class Hund : Tier
    {
        public bool KannBellen { get; private set; }
        public string Rasse { get; private set; }

        public Hund(string name, int alter, double gewicht, string rasse, bool kannBellen)
            : base(ArtType.Hund, name, alter, gewicht)
        {
            Rasse = rasse;
            KannBellen = kannBellen;
        }
    }
}
