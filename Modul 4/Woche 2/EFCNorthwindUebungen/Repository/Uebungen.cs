using EFCNorthwindUebungen.Data;
using EFCNorthwindUebungen.Models;

namespace EFCNorthwindUebungen.Repository
{
    internal class Uebungen
    {
        static EFCNorthwindContext? context;
        public static void AlleProdukte()
        {
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
            using (context = new EFCNorthwindContext())
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
    }
}
