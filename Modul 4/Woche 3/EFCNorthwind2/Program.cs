using EFCNorthwindUebungen.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EFCNorthwind2
{
    internal class Program
    {
        static void Main(string[] args)
        {     
        Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Teil 1
            Uebungen.AlleProdukte();
            Uebungen.AlleProdukteZuKategorie();
            Uebungen.TeuerstesProdukt();
            Uebungen.ProdukteNachPreis();
            Uebungen.NeuesProduktHinzufügen();
            Uebungen.ProduktPreisAktualisieren();
            Uebungen.ProduktLöschen();

            // Teil 2
            Uebungen.NeueKategorieUndProduktHinzu();
            Uebungen.DurchschnittlicherPreisProKategorie();
            Uebungen.AlleKategorienAlphabetischSortiert();
            Uebungen.ProduktanzahlProKategorie();
            Uebungen.TeuerstesProduktProKategorie();
            Uebungen.ProdukteMitNullPreisFinden();
            Uebungen.Günstigste3ProdukteDerKategorieCondiments();
            Uebungen.NeueBeschreibungFürEineKategorieSetzen();
            Uebungen.ProdukteOhneZugeordneteKategorie();
            Uebungen.AlleProdukteEinerKategorieAlphabetischAuflisten();
            Uebungen.GibtEsProdukteOhneNamen();
            Uebungen.ProduktpreisStatistik();
        }
    }
}
