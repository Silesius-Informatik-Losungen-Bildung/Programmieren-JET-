using EFCNorthwindUebungen.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCNorthwindUebungen.Repository
{
    internal class UebungenNavigationsLoading
    {
        static EfcnorthwindContext? context;

        public static void CustomerOhneLoading()
        {
            using (context = new EfcnorthwindContext())
            {
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Take(5).ToList();

                try
                {
                    // Verbundene Entität steht von Haus aus nicht zur Verfügung.
                    // Bei Zugriff wird Exception hervorgerufen.
                    Console.WriteLine(orders[0].Customer.ContactName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Customer konnte nicht geladen werden: Fehler: " + ex.Message);
                }
            }
        }

        public static void CustomerPerEagerLoading()
        {
            using (context = new EfcnorthwindContext())
            {
                // Bei Eager Loading werden verbundene Entitäten mit Include (und ThenInclude) nachgeladen.
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Include(o => o.Customer)
                    .Take(5).ToList();
                Console.WriteLine(orders[0].Customer.ContactName);
            }
        }

        public static void CustomerUndOrderDetailsPerEagerLoading()
        {
            using (context = new EfcnorthwindContext())
            {
                // Bei Eager Loading werden verbundene Entitäten mit Include (und ThenInclude) nachgeladen.
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Include(o => o.Customer) // Customer nachladen
                    .Include(o => o.OrderDetails) // OrderDetails nachladen
                    .ThenInclude(od => od.Product) // Produkte von OrderDetails nachladen
                    .Take(5).ToList(); 

                foreach (var order in orders)
                {
                    Console.WriteLine(order.Customer.ContactName);

                    foreach (var orderDertail in order.OrderDetails)
                    {
                        Console.WriteLine("---" + orderDertail.UnitPrice);
                        Console.WriteLine("---" + orderDertail.Quantity);
                        Console.WriteLine("---" + orderDertail.Discount);
                    }
                }
            }
        }

        public static void CustomerUndOrderDetailsPerEagerLoadingAlsSqlCode()
        {
            using (context = new EfcnorthwindContext())
            {
                // Bei Eager Loading werden verbundene Entitäten mit Include (und ThenInclude) nachgeladen.
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Include(o => o.Customer) // Customer nachladen
                    .Include(o => o.OrderDetails) // OrderDetails nachladen
                    .ThenInclude(od => od.Product) // Produkte von OrderDetails nachladen
                    .Take(5);

                Console.WriteLine(orders.ToQueryString());
            }
        }

        public static void CustomerPerLazyLoading()
        {
            // Verwende DbContext mit zugelassenem UseLazyLoading 

            using (context = new EfcnorthwindContext(true))
            {
                // Lazy Loading: wird verbundene Entität bei Zugriff nachgeladen.
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Take(5).ToList();
                Console.WriteLine(orders[0]?.Customer?.ContactName);
            }
        }


        public static void CustomerPerExplicitLoading()
        {
            using (context = new EfcnorthwindContext())
            {
                var orders = context.Orders.OrderBy(o => o.OrderId)
                    .Take(5).ToList();

                foreach (var order in orders)
                {
                    if (order.OrderId % 2 == 0)
                    {
                        // "Manuelles" Nachladen von Customer mit gerader OrderId
                        context.Entry(order)
                         .Reference(o => o.Customer)
                         .Load();

                        Console.WriteLine(order?.Customer?.ContactName);
                    }
                }
            }
        }

        public static void MehrAls10Bestellungen()
        {
            using (context = new EfcnorthwindContext())
            {
                var kunden = context.Customers
                    .Include(c => c.Orders)
                    .Where(c => c.Orders.Count > 10)
                    .ToList();

                foreach (var kunde in kunden)
                {
                    Console.WriteLine($"Kunde: {kunde.CompanyName} ({kunde.Orders.Count} Bestellungen)");
                }
            }
        }

        public static void BestellungeAus1997()
        {
            using (context = new EfcnorthwindContext())
            {
                var bestellungen = context.Orders
                  .Where(o => o.OrderDate.HasValue && o.OrderDate.Value.Year == 1997)
                  .Include(o => o.Customer)
                  .Include(o => o.OrderDetails)
                      .ThenInclude(od => od.Product)
                  .ToList();

                foreach (var bestellung in bestellungen)
                {
                    Console.WriteLine($"Bestellung {bestellung.OrderId} von {bestellung?.Customer?.CompanyName}");

                    if (bestellung == null)
                        continue;
                    foreach (var od in bestellung.OrderDetails)
                    {
                        Console.WriteLine($"Produkt {od.Product.ProductName}");
                    }
                   
                }
            }
        }

        public static void PreisUeber50Eur()
        {
            using (context = new EfcnorthwindContext())
            {
                var produkte = context.Products
                    .Where(p => p.UnitPrice > 50)
                    .Include(p => p.Category)
                    .Include(p => p.Supplier)
                    .ToList();

                foreach (var produkt in produkte)
                {
                    Console.WriteLine($"{produkt.ProductName} ({produkt.UnitPrice} €) – Kategorie: {produkt.Category.CategoryName}, Lieferant: {produkt.Supplier.CompanyName}");
                }
            }
        }

        public static void KategorienMitMindestens5Produkten()
        {
            using (context = new EfcnorthwindContext())
            {
                var kategorien = context.Categories
                    .Include(c => c.Products)
                    .Where(c => c.Products.Count >= 5).ToList();

                foreach (var kategorie in kategorien)
                {
                    Console.WriteLine($"Kategorie: {kategorie.CategoryName} ({kategorie.Products.Count} Produkte)");
                }
            }
        }
    }
}
