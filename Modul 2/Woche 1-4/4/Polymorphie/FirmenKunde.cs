namespace Polymorphie
{
    public class FirmenKunde : Kunde
    {
        private const double mwSt = 0.20;
        public string Firma { get; set; }

        public FirmenKunde(string anrede, string name, string firma) : base(anrede, name)
        {
            Firma = firma;
        }

        public override string GetAdresse()
        {
            return base.GetAdresse() + " " + Firma;
        }

        public override void AddGuthaben(decimal bruttoBetrag)
        {
            decimal netto = bruttoBetrag / (decimal)(1 + mwSt);
            base.AddGuthaben(netto * 0.01m); // Aufruf der Methode der Elternklasse
        }

        public double GetMwSt()
        {
            return mwSt;
        }

        public override string ToString()
        {
            return "die Klasse habe ich selbst progarmmiert.";
        }

    }
}
