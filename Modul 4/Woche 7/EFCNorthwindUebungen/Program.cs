using EFCNorthwindUebungen.Data;
using EFCNorthwindUebungen.Repository;

namespace EFCNorthwindUebungen
{
    internal class Program
    {
        static void Main(string[] args)
        {     
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // RunUebungenBasic();
            // RunUebungenUebungenNavigationsLoading();

            // UebungenChangeTracking.ddd();
            //UebungenChangeTracking.TrackingStatusse();

            UebungenChangeTracking.SpeicherVersuchMitundOhneTracking();
        }

        static void RunUebungenUebungenNavigationsLoading()
        {
            //Teil 1
            UebungenNavigationsLoading.CustomerOhneLoading();
            UebungenNavigationsLoading.CustomerPerEagerLoading();
            UebungenNavigationsLoading.CustomerUndOrderDetailsPerEagerLoading();
            UebungenNavigationsLoading.CustomerUndOrderDetailsPerEagerLoadingAlsSqlCode();
            UebungenNavigationsLoading.CustomerPerLazyLoading();
            UebungenNavigationsLoading.CustomerPerExplicitLoading();

            // Teil 2
            UebungenNavigationsLoading.MehrAls10Bestellungen();
            UebungenNavigationsLoading.BestellungeAus1997();
            UebungenNavigationsLoading.BestellungeAus1997();
            UebungenNavigationsLoading.PreisUeber50Eur();
            UebungenNavigationsLoading.KategorienMitMindestens5Produkten();
        }

        static void RunUebungenBasic()
        {
            // Teil 1
            UebungenBasic.AlleProdukte();
            UebungenBasic.AlleProdukteZuKategorie();
            UebungenBasic.TeuerstesProdukt();
            UebungenBasic.ProdukteNachPreis();
            UebungenBasic.NeuesProduktHinzufügen();
            UebungenBasic.ProduktPreisAktualisieren();
            UebungenBasic.ProduktLöschen();

            // Teil 2
            UebungenBasic.NeueKategorieUndProduktHinzu();
            UebungenBasic.DurchschnittlicherPreisProKategorie();
            UebungenBasic.AlleKategorienAlphabetischSortiert();
            UebungenBasic.ProduktanzahlProKategorie();
            UebungenBasic.TeuerstesProduktProKategorie();
            UebungenBasic.ProdukteMitNullPreisFinden();
            UebungenBasic.Günstigste3ProdukteDerKategorieCondiments();
            UebungenBasic.NeueBeschreibungFürEineKategorieSetzen();
            UebungenBasic.ProdukteOhneZugeordneteKategorie();
            UebungenBasic.AlleProdukteEinerKategorieAlphabetischAuflisten();
            UebungenBasic.GibtEsProdukteOhneNamen();
            UebungenBasic.ProduktpreisStatistik();
        }
    }
}
