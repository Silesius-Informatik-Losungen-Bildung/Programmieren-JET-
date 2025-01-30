public static class BuchFilter
{
    // Bücher-Bestand
    static List<Buch> buecher = new List<Buch>
        {
            new Buch { Titel = "C# Grundlagen", Autor = "Max Mustermann", Seiten = 300, Erscheinungsjahr = 2020, Preis = 29.99 },
            new Buch { Titel = "C# Fortgeschritten", Autor = "Erika Musterfrau", Seiten = 400, Erscheinungsjahr = 2018, Preis = 39.99 },
            new Buch { Titel = "LINQ lernen", Autor = "Max Mustermann", Seiten = 150, Erscheinungsjahr = 2021, Preis = 19.99 },
            new Buch { Titel = "ASP.NET Core", Autor = "John Doe", Seiten = 500, Erscheinungsjahr = 2022, Preis = 49.99 },
            new Buch { Titel = "Datenbanken mit SQL", Autor = "Jane Doe", Seiten = 250, Erscheinungsjahr = 2019, Preis = 24.99 }
        };

    static List<Buch> FiltereBuecher(List<Buch> buecher, Func<Buch, bool> filter)
    {
        return buecher.Where(filter).ToList();
    }

    public static void Query()
    {
        // Beispiel 1: Bücher, die mehr als 300 Seiten haben
        var buecherMitMehrAls300Seiten = FiltereBuecher(buecher, buch => buch.Seiten > 300);
        Console.WriteLine("Bücher mit mehr als 300 Seiten:");
        buecherMitMehrAls300Seiten.ForEach(Console.WriteLine);


        // Beispiel 2: Bücher, die von "Max Mustermann" sind
        var buecherVonMax = FiltereBuecher(buecher, buch => buch.Autor == "Max Mustermann");
        Console.WriteLine("\nBücher von Max Mustermann:");
        buecherVonMax.ForEach(Console.WriteLine);

        // Beispiel 3: Bücher, die im Jahr 2020 oder später veröffentlicht wurden
        var neuereBuecher = FiltereBuecher(buecher, buch => buch.Erscheinungsjahr >= 2020);
        Console.WriteLine("\nBücher, die ab 2020 erschienen sind:");
        neuereBuecher.ForEach(Console.WriteLine);

        // Beispiel 4: Bücher, die weniger als 30 Euro kosten
        var guenstigeBuecher = FiltereBuecher(buecher, buch => buch.Preis < 30);
        Console.WriteLine("\nBücher, die weniger als 30€ kosten:");
        guenstigeBuecher.ForEach(Console.WriteLine);

        // Beispiel 5: Bücher, die "SQL" im Titel enthalten
        var sqlBuecher = FiltereBuecher(buecher, buch => buch.Titel.Contains("SQL"));
        Console.WriteLine("\nBücher mit 'SQL' im Titel:");
        sqlBuecher.ForEach(Console.WriteLine);

    }

    internal class Buch
    {
        public required string Titel { get; set; }
        public required string Autor { get; set; }
        public int Seiten { get; set; }
        public int Erscheinungsjahr { get; set; }
        public double Preis { get; set; }
        public override string ToString() => $"\"{Titel}\" von {Autor}, {Seiten} Seiten, {Erscheinungsjahr}, {Preis:C}";
    }

}

