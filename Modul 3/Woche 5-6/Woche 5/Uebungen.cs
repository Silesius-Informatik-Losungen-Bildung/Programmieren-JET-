namespace LinqUebungen
{
    public static class Uebungen
    {
        public static void Produkte()
        {
            var produkte = new List<Produkt>
            {
                new() { Name = "Apfel", Preis = 1.2 },
                new() { Name = "Banane", Preis = 0.8 },
                new() { Name = "Kirsche", Preis = 2.5 },
                new() { Name = "Mango", Preis = 3.0 },
                new() { Name = "Orange", Preis = 1.5 }
            };

            Console.WriteLine("wenigerAls2Euro");
            var wenigerAls2Euro = produkte.Where(p => p.Preis < 2);
            foreach (var item in wenigerAls2Euro)
                Console.WriteLine(item.Preis);
            
            Console.WriteLine("nachPreisAuf");
            var nachPreisAuf = produkte.OrderBy(x => x.Preis);
            foreach (var item in nachPreisAuf)
                Console.WriteLine(item.Preis);
            
            Console.WriteLine("nurNamen");
            var nurNamen = produkte.Select(p => p.Name).ToList();
            foreach (var item in nurNamen)
                Console.WriteLine(item);
            
            Console.WriteLine("durchnittsPreis");
            var durchnittsPreis = produkte.Average(p => p.Preis);
            Console.WriteLine(durchnittsPreis);
        }

        public static void Grppierungen()
        {
            List<Person> personen = new List<Person>
            {
                new() { Name = "Alice", Alter = 25 },
                new() { Name = "Bob", Alter = 30 },
                new() { Name = "Charlie", Alter = 25 },
                new() { Name = "David", Alter = 35 },
                new() { Name = "Eve", Alter = 30 }
            };

            Console.WriteLine("gruppeNachAlter");
            var gruppeNachAlter = personen.GroupBy(p => p.Alter);
            
            foreach (var item in gruppeNachAlter)
                Console.WriteLine(item.Key);
            
            Console.WriteLine("durchnittsAlter");
            var durchnittsAlter = personen.Average(p => p.Alter);
            
            Console.WriteLine(durchnittsAlter);
            
            Console.WriteLine("personenProAlterGruppe");

            var personenProAlterGruppe = personen
                .GroupBy(p => p.Alter)
                .Select(x => new { Alter = x.Key, Anzahl = x.Count() });


            foreach (var item in personenProAlterGruppe)
                Console.WriteLine(item);
        }

        class Produkt
        {
            public string Name { get; set; }
            public double Preis { get; set; }
        }
        class Person
        {
            public string Name { get; set; }
            public int Alter { get; set; }
        }
        class Bestellung
        {
            public int Id { get; set; }
            public string Kunde { get; set; }
            public double Betrag { get; set; }
        }

    }
}
