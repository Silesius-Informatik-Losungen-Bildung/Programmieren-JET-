namespace GenerischeKlassen
{
    using System;

    public class LagerEintrag<TProdukt, TKategorie, TMenge>
        where TProdukt : class
        where TKategorie : class
        where TMenge : IComparable<TMenge>
    {
        public TProdukt Produkt { get; set; }
        public TKategorie Kategorie { get; set; }
        public TMenge Menge { get; set; }

        public LagerEintrag(TProdukt produkt, TKategorie kategorie, TMenge menge)
        {
            Produkt = produkt;
            Kategorie = kategorie;
            Menge = menge;
        }

        public void ZeigeEintrag()
        {
            Console.WriteLine($"Produkt: {Produkt}");
            Console.WriteLine($"Kategorie: {Kategorie}");
            Console.WriteLine($"Menge: {Menge}");
        }

        public bool IstNiedrig(TMenge grenzwert)
        {
            // nach grenzwert sortieren
            return Menge.CompareTo(grenzwert) < 0;
        }

        public override string ToString()
        {
            return $"Produkt={Produkt}, Kategorie={Kategorie}, Menge={Menge}";
        }
    }

}
