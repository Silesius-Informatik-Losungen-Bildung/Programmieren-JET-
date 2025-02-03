namespace Polymorphie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var privatKunde = new PrivatKunde("Herr", "Erich", "Innsbruck")
            {
                Stammkunde = false
            };

            var firmenKunde1 = new FirmenKunde("Frau", "Wallus", "Wallus Inernational")
            {
                Stammkunde = true
            };

            var firmenKunde2 = new FirmenKunde("Herr", "Grünspann", "Plachutta-Gastro")
            {
                Stammkunde = false
            };

            // Array von Typ Kunde (Kunde ist ja Elternklasse für PrivatKunde und FirmenKunde),
            // denn PrivatKunde is-a Kunde und FirmenKunde is-a Kunde
            var kunden = new Kunde[3];
            kunden[0] = privatKunde;
            kunden[1] = firmenKunde1;
            kunden[2] = firmenKunde2;


            Console.WriteLine(kunden[2].ToString());
           



            // Prozess
            var brutto = 125;
            for (int i = 0; i < kunden.Length; i++)
            {
                // hier wird ERST ZUR LAUFZEIT der Anwednung entschieden welche Implementierung der
                // GetAdresse() und AddGuthaben-Methoden wirklich aufgerufen wird.
                kunden[i].AddGuthaben(brutto);
                Console.WriteLine(kunden[i].GetAdresse() + ", Guthaben: " + kunden[i].Guthaben);
            }

        }
    }
}
