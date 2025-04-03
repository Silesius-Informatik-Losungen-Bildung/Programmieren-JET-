using EFCNorthwindUebungen.Repository;

namespace EFCNorthwindUebungen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uebungen.AlleProdukte();
            Uebungen.AlleProdukteZuKategorie();
            Uebungen.TeuerstesProdukt();
            Uebungen.ProdukteNachPreis();
            Uebungen.NeuesProduktHinzufügen();
            Uebungen.ProduktPreisAktualisieren();
            Uebungen.ProduktLöschen();
        }
    }
}
