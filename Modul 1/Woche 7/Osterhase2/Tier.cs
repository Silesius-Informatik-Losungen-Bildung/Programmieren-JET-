namespace Osterhase2
{
    public abstract class Tier
    {
        public string Name { get; set; }
        public string Farbe { get; set; }
        protected double GewichtInKg { get; set; }
        protected IEnumerable<string> Nahrung { get; private set; }
        protected int Alter { get; set; }
        protected ArtenTyp Art { get; private set; }

        public enum ArtenTyp
        {
            Säugetier,
            Vogel,
            Reptilia,
            Amphibia,
            Fisch
        }

        public Tier(ArtenTyp art, IEnumerable<string> nahrung)
        {
            Art = art;
            if (nahrung == null)
                new Exception("Geben Sie Ihrem Tier Nahrung!");
            Nahrung = nahrung;    
        }
    }
}
