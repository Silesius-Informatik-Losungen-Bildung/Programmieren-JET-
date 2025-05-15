using EFCNorthwindUebungen.Data;
using EFCNorthwindUebungen.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCNorthwindUebungen.Repository
{
    internal class UebungenBasic
    {
        static EfcnorthwindContext? context;
        public static void AlleProdukte()
        {
            using (context = new EfcnorthwindContext())
            {
                var products = context.Products.ToList();

                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:C}");
                }
            }
        }

        public static void AlleProdukteZuKategorie()
        {
            using (context = new EfcnorthwindContext())
            {
                var beverages = context.Products
                    .Where(p => p.Category.CategoryName == "Beverages")
                    .ToList();

                foreach (var product in beverages)
                {
                    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:C}");
                }
            }
        }

        public static void TeuerstesProdukt()
        {
            using (context = new EfcnorthwindContext())
            {
                var expensiveProduct = context.Products
                    .OrderByDescending(p => p.UnitPrice)
                    .FirstOrDefault();

                if (expensiveProduct != null)
                {
                    Console.WriteLine($"Teuerstes Produkt: {expensiveProduct.ProductName} - {expensiveProduct.UnitPrice:C}");
                }
            }
        }

        public static void ProdukteNachPreis()
        {
            using (context = new EfcnorthwindContext())
            {
                var midRangeProducts = context.Products
                    .Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 20)
                    .ToList();

                foreach (var product in midRangeProducts)
                {
                    Console.WriteLine($"{product.ProductName} - {product.UnitPrice:C}");
                }
            }
        }

        public static void NeuesProduktHinzufügen()
        {
            using (context = new EfcnorthwindContext())
            {
                // Kategorie "Beverages" abrufen
                var category = context.Categories.FirstOrDefault(c => c.CategoryName == "Beverages");

                if (category != null)
                {
                    var newProduct = new Product
                    {
                        ProductName = "Testprodukt",
                        UnitPrice = 9.99m,
                        CategoryId = category.CategoryId,
                        Discontinued = false
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    Console.WriteLine("Neues Produkt wurde erfolgreich hinzugefügt.");
                }
                else
                {
                    Console.WriteLine("Kategorie 'Beverages' nicht gefunden.");
                }
            }

        }

        public static void ProduktPreisAktualisieren()
        {
            using (context = new EfcnorthwindContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductName == "Chai");

                if (product != null)
                {
                    product.UnitPrice *= 1.10m; // Preis um 10 % erhöhen
                    context.SaveChanges();
                    Console.WriteLine($"Der Preis von '{product.ProductName}' wurde auf {product.UnitPrice:C} erhöht.");
                }
                else
                {
                    Console.WriteLine("Produkt 'Chai' nicht gefunden.");
                }
            }
        }

        public static void ProduktAlsDiscontinuedMarkieren()
        {
            using (context = new EfcnorthwindContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductName == "Uncle Bob’s Organic Dried Pears");

                if (product != null)
                {
                    product.Discontinued = true;
                    context.SaveChanges();
                    Console.WriteLine($"Das Produkt '{product.ProductName}' wurde als eingestellt markiert.");
                }
                else
                {
                    Console.WriteLine("Produkt nicht gefunden.");
                }
            }
        }

        public static void ProduktLöschen()
        {
            using (context = new EfcnorthwindContext())
            {
                var product = context.Products.FirstOrDefault(p => p.ProductName == "Testprodukt");

                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                    Console.WriteLine("Produkt wurde erfolgreich gelöscht.");
                }
                else
                {
                    Console.WriteLine("Produkt nicht gefunden.");
                }
            }

        }

        public static void NeueKategorieUndProduktHinzu()
        {
            using (context = new EfcnorthwindContext())
            {
                var neueKategorie = new Category { CategoryName = "BBRZ Kategorie" };

                var neuesProdukt = new Product
                {
                    ProductName = "Tisch-Reservierungs-System",
                    UnitPrice = 12.99m,
                    Category = neueKategorie
                };

                context.Products.Add(neuesProdukt);
                context.SaveChanges();
            }

        }

        public static void DurchschnittlicherPreisProKategorie()
        {
            using (context = new EfcnorthwindContext())
            {
                var kategorien = context.Products
                    .Where(p => p.UnitPrice.HasValue)
                    .GroupBy(p => p.Category.CategoryName)
                    .Select(g => new
                    {
                        Kategorie = g.Key,
                        Durchschnitt = g.Average(p => p.UnitPrice)
                    })
                    .ToList();

                foreach (var k in kategorien)
                {
                    Console.WriteLine($"{k.Kategorie}: Ø {k.Durchschnitt:C}");
                }
            }

        }


        public static void AlleKategorienAlphabetischSortiert()
        {
            using (context = new EfcnorthwindContext())
            {
                var kategorien = context.Categories
                    .OrderBy(c => c.CategoryName)
                    .ToList();

                foreach (var c in kategorien)
                {
                    Console.WriteLine($"{c.CategoryName}: {c.Description}");
                }
            }

        }

        public static void ProduktanzahlProKategorie()
        {
            using (context = new EfcnorthwindContext())
            {
                var gruppiert = context.Products
                    .GroupBy(p => p.Category.CategoryName)
                    .Select(g => new
                    {
                        Kategorie = g.Key,
                        Anzahl = g.Count()
                    })
                    .OrderByDescending(g => g.Anzahl)
                    .ToList();

                foreach (var eintrag in gruppiert)
                {
                    Console.WriteLine($"{eintrag.Kategorie}: {eintrag.Anzahl} Produkte");
                }
            }

        }

        public static void TeuerstesProduktProKategorie()
        {
            using (context = new EfcnorthwindContext())
            {
                var teuersteProdukte = context.Products
                    .Where(p => p.UnitPrice.HasValue)
                    .GroupBy(p => p.Category.CategoryName)
                    .Select(g => g
                        .OrderByDescending(p => p.UnitPrice)
                        .Select(p => new
                        {
                            Kategorie = g.Key,
                            Produkt = p.ProductName,
                            Preis = p.UnitPrice
                        })
                        .First())
                    .ToList();

                foreach (var eintrag in teuersteProdukte)
                {
                    Console.WriteLine($"{eintrag.Kategorie}: {eintrag.Produkt} ({eintrag.Preis:C})");
                }
            }

        }

        public static void ProdukteMitNullPreisFinden()
        {
            using (context = new EfcnorthwindContext())
            {
                var produkte = context.Products
                    .Where(p => p.UnitPrice == null)
                    .ToList();

                foreach (var p in produkte)
                {
                    Console.WriteLine($"{p.ProductName} hat keinen Preis.");
                }
            }
        }


        public static void Günstigste3ProdukteDerKategorieCondiments()
        {
            using (context = new EfcnorthwindContext())
            {
                var produkte = context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Category.CategoryName == "Condiments")
                    .OrderBy(p => p.UnitPrice)
                    .Take(3)
                    .ToList();

                foreach (var p in produkte)
                {
                    Console.WriteLine($"{p.ProductName} - {p.UnitPrice:C}");
                }
            }
        }


        public static void NeueBeschreibungFürEineKategorieSetzen()
        {
            using (context = new EfcnorthwindContext())
            {
                var kategorie = context.Categories
                    .FirstOrDefault(c => c.CategoryName == "Fisch & Co.");

                if (kategorie != null)
                {
                    kategorie.Description = "Frische und konservierte Meeresfrüchte";
                    context.SaveChanges();
                }
            }
        }

        public static void ProdukteOhneZugeordneteKategorie()
        {
            using (context = new EfcnorthwindContext())
            {
                var produkte = context.Products
                    .Where(p => p.Category == null)
                    .ToList();

                foreach (var p in produkte)
                {
                    Console.WriteLine($"{p.ProductName} hat keine gültige Kategorie.");
                }
            }
        }


        public static void AlleProdukteEinerKategorieAlphabetischAuflisten()
        {
            using (context = new EfcnorthwindContext())
            {
                var produkte = context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Category.CategoryName == "Confections")
                    .OrderBy(p => p.ProductName)
                    .ToList();

                foreach (var p in produkte)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
        }

        public static void GibtEsProdukteOhneNamen()
        {
            using (context = new EfcnorthwindContext())
            {
                bool gibtEs = context.Products.Any(p => string.IsNullOrEmpty(p.ProductName));
                Console.WriteLine(gibtEs ? "Es gibt Produkte ohne Namen." : "Alle Produkte haben Namen.");
            }
        }

        public static void ProduktpreisStatistik()
        {
            using (context = new EfcnorthwindContext())
            {
                var stats = context.Products
                 .Where(p => p.UnitPrice.HasValue)
                 .Select(p => p.UnitPrice.Value);

                Console.WriteLine($"Min: {stats.Min():C}");
                Console.WriteLine($"Max: {stats.Max():C}");
                Console.WriteLine($"Ø: {stats.Average():C}"); ;
            }
        }

    }
}
