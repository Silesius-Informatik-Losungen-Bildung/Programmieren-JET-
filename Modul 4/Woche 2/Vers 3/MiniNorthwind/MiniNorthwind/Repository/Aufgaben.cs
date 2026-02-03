using Microsoft.EntityFrameworkCore;
using MiniNorthwind.Data;

namespace MiniNorthwind.Repository
{
    internal class Aufgaben
    {
        internal static void Start()
        {
            using MiniNorthwindContext context = new MiniNorthwindContext();

            // =========================
            // Aufgabe 1 – Alle Produkte
            // =========================
            Console.WriteLine("Aufgabe 1");
            var produkte1 = context.Products.ToList();

            foreach (var p in produkte1)
            {
                Console.WriteLine($"{p.ProductId} | {p.ProductName} | {p.UnitPrice}");
            }

            // =========================
            // Aufgabe 2 – Esrtes Produkt
            // =========================
            Console.WriteLine("\nAufgabe 2");
            var produkt2 = context.Products.FirstOrDefault();

            if (produkt2 != null)
                Console.WriteLine(produkt2.ProductName);
            else
                Console.WriteLine("Produkt nicht gefunden.");

            // =========================
            // Aufgabe 3 – Produkte nach Preis sortiert
            // =========================
            Console.WriteLine("\nAufgabe 3");
            var produkte3 = context.Products
                .OrderBy(p => p.UnitPrice)
                .ToList();

            foreach (var p in produkte3)
            {
                Console.WriteLine($"{p.ProductName} | {p.UnitPrice}");
            }

            // =========================
            // Aufgabe 4 – Produkte mit Kategorie
            // =========================
            Console.WriteLine("\nAufgabe 4");
            var produkte4 = context.Products
                .Include(p => p.Category)
                .ToList();

            foreach (var p in produkte4)
            {
                Console.WriteLine($"{p.ProductName} | {p.Category?.CategoryName}");
            }

            // =========================
            // Aufgabe 5 – Produkte mit Supplier
            // =========================
            Console.WriteLine("\nAufgabe 5");
            var produkte5 = context.Products
                .Include(p => p.Supplier)
                .ToList();

            foreach (var p in produkte5)
            {
                Console.WriteLine($"{p.ProductName} | {p.Supplier?.CompanyName}");
            }

            // =========================
            // Aufgabe 6 – Produkt mit Kategorie und Supplier
            // =========================
            Console.WriteLine("\nAufgabe 6");
            var produkt6 = context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.ProductName == "Chai");

            if (produkt6 != null)
            {
                Console.WriteLine(
                    $"{produkt6.ProductName} | {produkt6.Category?.CategoryName} | {produkt6.Supplier?.CompanyName}"
                );
            }

            // =========================
            // Aufgabe 7 – Produkte einer Kategorie
            // =========================
            Console.WriteLine("\nAufgabe 7");
            var firstCategory = context.Categories.FirstOrDefault();
            if (firstCategory != null)
            {
                var produkte7 = context.Products
                    .Where(p => p.CategoryId == firstCategory.CategoryId)
                    .ToList();

                foreach (var p in produkte7)
                {
                    Console.WriteLine(p.ProductName);
                }
            }

            // =========================
            // Aufgabe 8 – Produkte eines Suppliers
            // =========================
            Console.WriteLine("\nAufgabe 8");
            var lastSupplier = context.Suppliers.OrderByDescending(s=> s.SupplierId).FirstOrDefault();
            if (lastSupplier != null)
            {
                var produkte8 = context.Products
                    .Where(p => p.SupplierId == lastSupplier.SupplierId)
                    .ToList();

                foreach (var p in produkte8)
                {
                    Console.WriteLine($"{p.ProductName} | {p.UnitPrice}");
                }
            }
            // =========================
            // Aufgabe 9 – Anzahl der Produkte
            // =========================
            Console.WriteLine("\nAufgabe 9");
            int anzahl = context.Products.Count();
            Console.WriteLine($"Anzahl der Produkte: {anzahl}");

            // =========================
            // Aufgabe 10 – Durchschnittspreis
            // =========================
            Console.WriteLine("\nAufgabe 10");
            decimal? durchschnitt = context.Products.Average(p => p.UnitPrice);
            Console.WriteLine($"Durchschnittspreis: {durchschnitt}");
        }
    }
}



