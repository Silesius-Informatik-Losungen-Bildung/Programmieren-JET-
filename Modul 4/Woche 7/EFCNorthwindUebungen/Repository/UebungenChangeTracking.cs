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
                var category = context.Categories
                    .FirstOrDefault(c => c.CategoryName == "Beverages");
                var product = new Product
                {
                    ProductName = "Testprodukt",
                    UnitPrice = 9.99m,
                    CategoryId = category.CategoryId,
                    Discontinued = false
                };

                CheckStatus(product);

                context.Products.Add(product);
                CheckStatus(product);

                product = context.Products.FirstOrDefault(p => p.ProductName == "Chai");
                product.ProductName = "XXXX";
                CheckStatus(product);

                context.Products.Remove(product);
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
            var category = context.Categories
                .FirstOrDefault(c => c.CategoryName == "Beverages");
            var name1 = Guid.NewGuid().ToString();
            var p1 = new Product
            {
                ProductName = name1,
                UnitPrice = 9.99m,
                CategoryId = category.CategoryId,
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
            var produktTracked = context.Products
                 .FirstOrDefault(p => p.ProductName == name1);

            // Produkt OHNE Tracking aus DB holen
            var produktUntracked = context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.ProductName == name2);

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

    }
}
