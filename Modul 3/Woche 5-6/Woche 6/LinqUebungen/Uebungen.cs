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

        public static void Gruppierungen()
        {
            var personen = new List<Person>
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
                .GroupBy(p => p.Alter);
            //.Select(x => new { Alter = x.Key, Anzahl = x.Count() });

            foreach (var item in personenProAlterGruppe)
            {
                Console.Write("Gruppe: " + item.Key + ": ");
                foreach (var innerItem in item)
                {
                    Console.Write(innerItem.Name + ", ");
                }
                Console.WriteLine();
            }
        }

        public static void Bestellungen()
        {
            var bestellungen = new List<Bestellung>
            {
                new() { Id = 1, Kunde = "Müller", Betrag = 100 },
                new() { Id = 2, Kunde = "Schmidt", Betrag = 200 },
                new() { Id = 3, Kunde = "Müller", Betrag = 150 },
                new() { Id = 4, Kunde = "Schneider", Betrag = 300 },
                new() { Id = 5, Kunde = "Schmidt", Betrag = 150 }
            };

            Console.WriteLine("kundeHoechsteBestellWert");
            var gesamtBetrag = bestellungen.Sum(x => x.Betrag);
            Console.WriteLine(gesamtBetrag);

            Console.WriteLine("kundeHoechsteBestellWert");
            var kundeHoechsteBestellWert = bestellungen.GroupBy(x => x.Kunde)
                .Select(k => new { Kunde = k.Key, Summe = k.Sum(b => b.Betrag) })
                .MaxBy(g => g.Summe);

            Console.WriteLine(kundeHoechsteBestellWert);

            Console.WriteLine("nachKundeMitGesamtBetrag");
            var nachKundeMitGesamtBetrag = bestellungen
                .GroupBy(x => x.Kunde)
                .Select(k => new { Kunde = k.Key, Gesamtbetrag = k.Sum(k => k.Betrag) });
            foreach (var item in nachKundeMitGesamtBetrag)
                Console.WriteLine(item);

            var result = bestellungen
               .GroupBy(k => k.Kunde)
               .OrderBy(k => k.Key)
               .Select(b => new { Kunde = b.Key, Summe = b.Sum(k => k.Betrag) });

            foreach (var item in result)
                Console.WriteLine($"Summe der Bestellungen: {item.Kunde} = {item.Summe:C}");

        }

        public static void Joins()
        {
            var bestellungen = new List<BestellungVers2>
            {
                new() { Id = 1, KundeId = 1, Betrag = 100, Produkt = "Smartphone" },
                new() { Id = 2, KundeId = 2, Betrag = 200, Produkt = "Fernseher"  },
                new() { Id = 3, KundeId = 2, Betrag = 150, Produkt = "Kasten"  },
                new() { Id = 4, KundeId = 3, Betrag = 300, Produkt = "Hose"  },
                new() { Id = 5, KundeId = 2, Betrag = 50, Produkt = "Haube"  }
            };
            var kunden = new List<Kunde>
            {
                new()  { Id = 1, Name = "Müller" },
                new()  { Id = 2, Name = "Schmidt" },
                new()  { Id = 3, Name = "Schneider" },
                new()  { Id = 4, Name = "Krawietz" }
            };

            Console.WriteLine("fuerJedeBesetllungDenKunden");
            var fuerJedeBesetllungDenKunden =
                from bestellung in bestellungen
                join kunde in kunden on bestellung.KundeId equals kunde.Id
                select new { bestellung.Produkt, kunde.Name };

            foreach (var item in fuerJedeBesetllungDenKunden)
                Console.WriteLine(item);

            Console.WriteLine("kundenMitBestellungen");
            var kundenMitBestellungen = from kunde in kunden
                                        join bestellung in bestellungen on kunde.Id equals bestellung.KundeId
                                        into bestellungenGruppe
                                        from bestellung in bestellungenGruppe.DefaultIfEmpty() // Entspricht einem LEFT JOIN
                                        select new
                                        {
                                            kunde.Name,
                                            Produkt = bestellung?.Produkt ?? "Keine Bestellung"
                                        };

            foreach (var item in kundenMitBestellungen)
                Console.WriteLine(item);
        }

        public static void ZeichenKetten()
        {
            List<string> staedte = new List<string>
            {
                "Wien", "Graz", "Linz", "Salzburg", "Innsbruck", "Klagenfurt", "Villach", "Wels", "St. Pölten", "Dornbirn"
            };

            Console.WriteLine("orteMitD");
            var orteMitD = staedte.Where(o => o.StartsWith("D"));
            foreach (var item in orteMitD)
                Console.WriteLine(item);

            Console.WriteLine("orteSortiert");
            var orteSortiert = staedte.Order();
            foreach (var item in orteSortiert)
                Console.WriteLine(item);

            Console.WriteLine("orteMitMehrAl6Buchstaben");
            var orteMitMehrAl6Buchstaben = staedte.Where(o => o.Length > 6).Count();
            Console.WriteLine(orteMitMehrAl6Buchstaben);

            Console.WriteLine("neueListeMitGRossBuchstaben");
            var neueListeMitGRossBuchstaben = staedte
                .Select(o => o.ToUpper());
            foreach (var item in neueListeMitGRossBuchstaben)
                Console.WriteLine(item);
        }

        public static void DatumUndUhrzeit()
        {
            var ereignisse = new List<Ereignis>
            {
                new() { Beschreibung = "Projektstart", Datum = new DateTime(2024, 1, 10) },
                new() { Beschreibung = "Meilenstein 1", Datum = new DateTime(2027, 2, 15) },
                new() { Beschreibung = "Meilenstein 2", Datum = new DateTime(2029, 3, 20) },
                new() { Beschreibung = "Abschluss", Datum = new DateTime(2024, 2, 25) }
            };

            Console.WriteLine("erreignisseInDerZukunft");
            var erreignisseInDerZukunft = ereignisse.Where(e => e.Datum > DateTime.Now);
            foreach (var item in erreignisseInDerZukunft)
                Console.WriteLine(item.Datum + ": " + item.Beschreibung);

            Console.WriteLine("dasFruehersteErreichnis");
            var dasFruehersteErreichnis = ereignisse.OrderBy(e => e.Datum).First();
            Console.WriteLine(dasFruehersteErreichnis.Datum + ": " + dasFruehersteErreichnis.Beschreibung);

            Console.WriteLine("nachDatumAbsteigend");
            var nachDatumAbsteigend = ereignisse.OrderByDescending(e => e.Datum);
            foreach (var item in nachDatumAbsteigend)
                Console.WriteLine(item.Datum + ": " + item.Beschreibung);

            Console.WriteLine("wieVieleImFebruar");
            var wieVieleImFebruar = ereignisse.Count(e => e.Datum.Month == 2);
            Console.WriteLine(wieVieleImFebruar);

        }

        public static void FilterUndTransformatioen()
        {
            var mitarbeiter = new List<Mitarbeiter>
            {
                new() { Name = "Anna", Abteilung = "IT", Gehalt = 4500 },
                new() { Name = "Bernd", Abteilung = "HR", Gehalt = 3200 },
                new() { Name = "Clara", Abteilung = "IT", Gehalt = 5000 },
                new() { Name = "David", Abteilung = "Marketing", Gehalt = 3500 },
                new() { Name = "Emma", Abteilung = "IT", Gehalt = 4800 }
            };

            Console.WriteLine("alleAusDerIt");
            var alleAusDerIt = mitarbeiter.Where(ma => ma.Abteilung == "IT");
            foreach (var item in alleAusDerIt)
                Console.WriteLine(item);

            Console.WriteLine("durchschnitsGehalt");
            var durchschnitsGehalt = mitarbeiter.Average(ma => ma.Gehalt);
            Console.WriteLine(durchschnitsGehalt);


            Console.WriteLine("gehaltsErhoehungUm10Prozent");
            var gehaltsErhoehungUm10Prozent = mitarbeiter
                .Select(ma => new { Kunde = ma.Name, GehaltErhoeht = (ma.Gehalt + (ma.Gehalt / 100) * 10) });
            foreach (var item in gehaltsErhoehungUm10Prozent)
                Console.WriteLine(item);

            Console.WriteLine("gruppeNachAbteilungUndHoechstesGehalt");
            var gruppeNachAbteilungUndHoechstesGehalt = mitarbeiter
                .GroupBy(ma => ma.Abteilung)
                .Select(ma => new { Abteilung = ma.Key, HoechstGehalt = ma.Max(ma => ma.Gehalt) });
            foreach (var item in gruppeNachAbteilungUndHoechstesGehalt)
                Console.WriteLine(item);
        }


        public static void Dictionaries()
        {
            var bestellungen = new Dictionary<int, double>
            {
                { 1001, 150.50 },
                { 1002, 99.99 },
                { 1003, 250.00 },
                { 1004, 75.25 },
                { 1005, 300.00 }
            };

            Console.WriteLine("bestellungenUeber100Eur");
            var bestellungenUeber100Eur = bestellungen.Where(b => b.Value > 100);
            foreach (var item in bestellungenUeber100Eur)
                Console.WriteLine(item);

            Console.WriteLine("gesmatWert");
            var gesamtWert = bestellungen.Sum(b => b.Value);
            Console.WriteLine(gesamtWert);

            Console.WriteLine("bestellNurMitHoechstBetrag");
            var bestellNurMitHoechstBetrag = bestellungen.MaxBy(b => b.Value).Key;
            Console.WriteLine(bestellNurMitHoechstBetrag);

            Console.WriteLine("listeMitBestellungenAlsZeichenkette");
            var listeMitBestellungenAlsZeichenkette = bestellungen
                .Select(b => $"Bestellung: {b.Key}");
            Console.WriteLine(string.Join(", ", listeMitBestellungenAlsZeichenkette));
        }

        public static void FortgeschritteneJoins()
        {
            var kunden = new List<Kunde>
            {
                new() { Id = 1, Name = "Meier" },
                new() { Id = 2, Name = "Schulz" },
                new() { Id = 3, Name = "Becker" }
            };
            var bestellungen = new List<BestellungVers2>
            {
                new() { Id = 101, KundeId = 1, Betrag = 250 },
                 new(){ Id = 102, KundeId = 2, Betrag = 150 },
                 new() { Id = 103, KundeId = 1, Betrag = 300 },
                 new() { Id = 104, KundeId = 3, Betrag = 50 }
            };

            Console.WriteLine("alleBestellungenMitKundennamen");
            var alleBestellungenMitKundennamen = from b in bestellungen
                                                 join k in kunden on b.KundeId equals k.Id
                                                 select new { b.Id, k.Name, b.Betrag };

            foreach (var item in alleBestellungenMitKundennamen)
                Console.WriteLine(item);

            Console.WriteLine("alleKundenMitBestellungenMitLefJoin");
            var alleKundenMitBestellungenMitLefJoin = from k in kunden
                                                      join b in bestellungen on k.Id equals b.KundeId into bestellungenVonKunde
                                                      from b in bestellungenVonKunde.DefaultIfEmpty()
                                                      select new { k.Name, BestellungId = b?.Id, Betrag = b?.Betrag ?? 0 };

            foreach (var item in alleKundenMitBestellungenMitLefJoin)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("kundeHechstenGesamtsumme");
            var kundeHechstenGesamtsumme =
                (from b in bestellungen
                 group b by b.KundeId into gruppe
                 select new
                 {
                     KundeId = gruppe.Key,
                     Summe = gruppe.Sum(b => b.Betrag)
                 })
                .OrderByDescending(x => x.Summe)
                .FirstOrDefault();

            if (kundeHechstenGesamtsumme != null)
            {
                var kundeMitHöchsterSumme = kunden.FirstOrDefault(k => k.Id == kundeHechstenGesamtsumme.KundeId);
                Console.WriteLine(kundeMitHöchsterSumme.Name);
            }
        }

        public static void VerschachtelteObjekte()
        {
            var kurse = new List<Kurs>
            {
               new() { Titel = "C# Grundlagen", Teilnehmer = new()  { new() { Name = "Lisa" }, new() { Name = "Markus" } } },
               new() { Titel = "Datenbanken", Teilnehmer = new()  { new() { Name = "Markus" }, new() { Name = "Tom" } } },
               new() { Titel = "Webentwicklung", Teilnehmer = new()  { new() { Name = "Anna" }, new() { Name = "Lisa" } } }
            };

            Console.WriteLine("alleTeilnehmerAlleKurseOhneDuplikate");
            var alleTeilnehmerAlleKurseOhneDuplikate = kurse
                .SelectMany(k => k.Teilnehmer)
                .Select(t => t.Name)
                .Distinct();

            foreach (var item in alleTeilnehmerAlleKurseOhneDuplikate)
                Console.WriteLine(item);

            Console.WriteLine("alleAnDenenLisaTeilnimmt");
            var alleAnDenenLisaTeilnimmt = kurse
              .Where(k => k.Teilnehmer.Any(t => t.Name == "Lisa"))
              .Select(k => k.Titel);
            foreach (var item in alleAnDenenLisaTeilnimmt)
                Console.WriteLine(item);

            Console.WriteLine("kursMitDenMeistenTeilnehmern");
            var kursMitDenMeistenTeilnehmern = kurse
                .OrderByDescending(k => k.Teilnehmer.Count)
                .First();
            Console.WriteLine(kursMitDenMeistenTeilnehmern.Titel);

            Console.WriteLine("gruppeTeilnehmerNachAnzahlDerBelegtenKurse");
            var gruppeTeilnehmerNachAnzahlDerBelegtenKurse = kurse
              .SelectMany(k => k.Teilnehmer.Select(t => t.Name))
              .GroupBy(name => name)
              .Select(g => new { Name = g.Key, AnzahlKurse = g.Count() })
              .OrderByDescending(g => g.AnzahlKurse);
            foreach (var item in gruppeTeilnehmerNachAnzahlDerBelegtenKurse)
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
        class BestellungVers2
        {
            public int Id { get; set; }
            public int KundeId { get; set; }
            public double Betrag { get; set; }
            public string Produkt { get; set; }
        }

        class Kunde
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Ereignis
        {
            public string Beschreibung { get; set; }
            public DateTime Datum { get; set; }
        }
        class Mitarbeiter
        {
            public string Name { get; set; }
            public string Abteilung { get; set; }
            public double Gehalt { get; set; }
            public override string ToString()
            {
                return Name + " " + Abteilung;
            }
        }

        class Teilnehmer
        {
            public string Name { get; set; }
        }

        class Kurs
        {
            public string Titel { get; set; }
            public List<Teilnehmer> Teilnehmer { get; set; }
        }

    }
}
