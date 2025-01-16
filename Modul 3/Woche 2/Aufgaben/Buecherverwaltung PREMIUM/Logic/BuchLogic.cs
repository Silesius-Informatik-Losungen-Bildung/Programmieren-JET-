using Buecherverwaltung.Interfaces;
using Buecherverwaltung.Models;
using System.Text.Json;

namespace Buecherverwaltung.Logic
{
    public class BuchLogic : IBuchLogic
    {
        static readonly string dateiName = "bibliothek.json";
        static List<Buch>? buchListe;

        public bool HatBibliothek { get => File.Exists(dateiName); }

        public bool BibliothekHatBuecher { get => buchListe?.Count > 0; }

        public void BibliothekSpeichern()
        {
            if(buchListe==null)
                buchListe = new List<Buch>();
            var jsonString = JsonSerializer.Serialize(buchListe);
            File.WriteAllText(dateiName, jsonString);
        }

        public void BibliothekAnzeigen()
        {
            var jsonString = File.ReadAllText(dateiName);
            buchListe = JsonSerializer.Deserialize<List<Buch>>(jsonString);
            if (buchListe?.Count == 1)
                Console.WriteLine("Sie haben in Ihrer Bibliothek " + buchListe.Count + " Buch.");
            else
                Console.WriteLine("Sie haben in Ihrer Bibliothek " + buchListe?.Count + " Bücher");

            Console.WriteLine("-------------------------------------------------");
            for (int i = 0; i < buchListe?.Count; i++)
            {
                var buch = buchListe[i];
                Console.WriteLine(buch.Id + ": " + buch.Titel);
            }
            Console.WriteLine("-------------------------------------------------");

        }

        public void BuchLoseschen(int buchId)
        {
            var zuLoeschendesBuch = buchListe?.Where(x => x.Id == buchId).FirstOrDefault();
            if (zuLoeschendesBuch != null)
            {
                buchListe?.Remove(zuLoeschendesBuch);
                BibliothekSpeichern();
                Console.WriteLine("Das Buch mit der Id " + buchId + " wurde erfolgreich gelöscht");
                BibliothekAnzeigen();
            }
            else
            {
                Console.WriteLine("Buch mit der Id " + buchId + " existiert nicht! Kein Löschen möglich");
            }
        }

        public void BuchSpeichern()
        {
            var buch = new Buch();
            Console.WriteLine("Titel?");
            buch.Titel = Console.ReadLine();
            Console.WriteLine("Autor?");
            buch.Autor = Console.ReadLine();

            if (buchListe?.Count > 0)
                buch.Id = (buchListe.Select(x => x.Id).Max() + 1);
            else
                buch.Id = 1;

            buchListe?.Add(buch);

            BibliothekSpeichern();
        }
    }
}
