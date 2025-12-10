using EFCNorthwindUebungen.Data;
using EFCNorthwindUebungen.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCNorthwindUebungen.Repository
{
    internal class UebungenChangeTracking
    {
        static EfcnorthwindContext? context;

        public static void TrackingStatusse()
        {
            using (context = new EfcnorthwindContext())
            {
                var category = context.Categories.FirstOrDefault(c => c.CategoryName == "           ");

                // Erstelle neues Produkt im Speicher 
                var product = new Product
                {
                    ProductName = "Testprodukt",
                    UnitPrice = 9.99m,
                    Category = category,
                    Discontinued = false
                };

                // Gebe Status von product aus (Detached = keine Änderungen an Objekt erkannt)
                CheckStatus(product);

                // Produkt im Speicher in Products-DbSet hizufügen
                context.Products.Add(product);
                // Gebe Status von product aus (Added = Objekt hinzugefügt)
                CheckStatus(product);

                // Überschreibe produkt im Speicher mit einen anderen Produkt
                product = context.Products.FirstOrDefault(p => p.ProductName == "Chai");
                product.ProductName = "XXXX";

                // Gebe Status von product aus (Modiefied = Objekt geändert)
                CheckStatus(product);

                // Lösche product aus DbSet
                context.Products.Remove(product);
                // Gebe Status von product aus (Deleted = Objekt gelöscht)
                CheckStatus(product);

                //context.SaveChanges();

                static void CheckStatus(Product produkt)
                {
                    var entry = context.Entry(produkt);
                    Console.WriteLine($"Status von Product: {entry.State}");
                }
            }
        }

        public static void SpeicherVersuchMitundOhneTracking()
        {
            using var context = new EfcnorthwindContext();

            // Zwei neue Beispielprodukte anlegen
            var category = context.Categories.FirstOrDefault(c => c.CategoryName == "Beverages");
            var name1 = Guid.NewGuid().ToString();
            var p1 = new Product
            {
                ProductName = name1,
                UnitPrice = 9.99m,
                Category = category,
                Discontinued = false
            };
            context.Products.Add(p1);

            var name2 = Guid.NewGuid().ToString();
            var p2 = new Product
            {
                ProductName = name2,
                UnitPrice = 9.99m,
                CategoryId = category.CategoryId,
                Discontinued = false
            };
            context.Products.Add(p2);
            context.SaveChanges();

            //----------------------------------------------

            // Produkt MIT Tracking aus DB holen
            var produktTracked = context.Products.FirstOrDefault(p => p.ProductName == name1);

            // Produkt OHNE Tracking aus DB holen
            var produktUntracked = context.Products.AsNoTracking().FirstOrDefault(p => p.ProductName == name2);

            // Änderungen vorhemen
            produktTracked.ProductName = "Geändert mit Tracking";
            produktUntracked.ProductName = "Geändert ohne Tracking"; // wird in der DB nicht commitet

            // Änderungen Speichern
            context.SaveChanges();

            // Fertig – bitte prüfen Sie die Datenbank!

            //----------------------------------------------
            // Bereinigung
            context.Products.Remove(p1);
            context.Products.Remove(p2);
            context.SaveChanges();
        }

        public static void Uebung1()
        {

            using var context = new EfcnorthwindContext();

            // 1.	Laden Sie einen Kunden Ihrer Wahl mit der CustomerID aus der Datenbank.
            var kunde = context.Customers.FirstOrDefault(c => c.CustomerId == "ALFKI");

            if (kunde != null)
            {
                Console.WriteLine($"Ursprünglicher ContactName: {kunde.ContactName}");

                // 2.Ändern Sie lokal das Feld ContactName.
                kunde.ContactName = "Neuer Kontaktname";

                // 3.Nutzen Sie den Change Tracker, um den alten und den neuen Wert auszugeben.
                var eintrag = context.Entry(kunde);
                var original = eintrag.OriginalValues["ContactName"];
                var aktuell = eintrag.CurrentValues["ContactName"];

                Console.WriteLine($"Original: {original}, Aktuell: {aktuell}");

                // 4. Verwenden Sie KEIN SaveChanges().

                // 5.Setzen Sie die Änderung zurück (Revert durch SetValues).
                eintrag.CurrentValues.SetValues(eintrag.OriginalValues);

                // 6.	Geben Sie nach dem Revert den ContactName erneut aus.
                Console.WriteLine($"Nach Revert: {kunde.ContactName}");
            }
            else
            {
                Console.WriteLine("Kunde nicht gefunden.");
            }
        }

        public static void Uebung2()
        {
            using var context = new EfcnorthwindContext();

            // 1. Produkt laden
            var produkt = context.Products.FirstOrDefault(p => p.ProductId == 1);

            if (produkt != null)
            {
                Console.WriteLine($"Originaler Produktname: {produkt.ProductName}, Preis: {produkt.UnitPrice}");

                // 2. Lokale Änderungen
                produkt.ProductName = "Testprodukt";
                produkt.UnitPrice = 99.99m;

                // 3. Change Tracker anzeigen
                var eintrag = context.Entry(produkt);

                var originalName = eintrag.OriginalValues["ProductName"];
                var aktuellerName = eintrag.CurrentValues["ProductName"];

                var originalPreis = eintrag.OriginalValues["UnitPrice"];
                var aktuellerPreis = eintrag.CurrentValues["UnitPrice"];

                Console.WriteLine($"Name – Original: {originalName}, Aktuell: {aktuellerName}");
                Console.WriteLine($"Preis – Original: {originalPreis}, Aktuell: {aktuellerPreis}");

                // 4. Kein SaveChanges!

                // 5. Änderungen zurücksetzen
                eintrag.CurrentValues.SetValues(eintrag.OriginalValues);

                // 6. Kontrolle nach Revert
                Console.WriteLine($"Nach Revert – Produktname: {produkt.ProductName}, Preis: {produkt.UnitPrice}");
            }
            else
            {
                Console.WriteLine("Produkt nicht gefunden.");
            }

        }

    }
}
