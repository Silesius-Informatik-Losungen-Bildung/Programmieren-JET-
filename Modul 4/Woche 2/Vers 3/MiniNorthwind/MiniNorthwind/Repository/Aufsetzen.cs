using MiniNorthwind.Data;
using MiniNorthwind.Models;

namespace MiniNorthwind.Repository
{
    internal class Aufsetzen
    {
        internal static void Start()
        {
            using var context = new MiniNorthwindContext();

            if (!context.Categories.Any())
            {

                var category1 = new Category()
                {
                    CategoryName = "Beverages",
                    Description = "Soft drinks, coffees, teas, beers, and ales",
                    Picture = null
                };
                context.Categories.Add(category1);

                var category2 = new Category()
                {
                    CategoryName = "Condiments",
                    Description = "Sweet and savory sauces, relishes, spreads, and seasonings",
                    Picture = null
                };
                context.Categories.Add(category2);


                var category3 = new Category()
                {
                    CategoryName = "Confections",
                    Description = "Desserts, candies, and sweet breads",
                    Picture = null
                };
                context.Categories.Add(category3);

                context.SaveChanges();
            }


            if (!context.Suppliers.Any())
            {
                var supplier1 = new Supplier()
                {
                    CompanyName = "Exotic Liquids",
                    ContactName = "Charlotte Cooper",
                    ContactTitle = "Purchasing Manager",
                    Address = "49 Gilbert St.",
                    City = "London",
                    Region = null,
                    PostalCode = "EC1 4SD",
                    Country = "UK",
                    Phone = "(171) 555-2222",
                    Fax = null,
                    HomePage = null
                };
                context.Suppliers.Add(supplier1);

                var supplier2 = new Supplier()
                {
                    CompanyName = "New Orleans Cajun Delights",
                    ContactName = "Shelley Burke",
                    ContactTitle = "Order Administrator",
                    Address = "P.O. Box 78934",
                    City = "New Orleans",
                    Region = "LA",
                    PostalCode = "70117",
                    Country = "USA",
                    Phone = "(100) 555-4822",
                    Fax = null,
                    HomePage = "#CAJUN.HTM#"
                };
                context.Suppliers.Add(supplier2);

                var supplier3 = new Supplier()
                {
                    CompanyName = "Grandma Kelly's Homestead",
                    ContactName = "Regina Murphy",
                    ContactTitle = "Sales Representative",
                    Address = "707 Oxford Rd.",
                    City = "Ann Arbor",
                    Region = "MI",
                    PostalCode = "48104",
                    Country = "USA",
                    Phone = "(313) 555-5735",
                    Fax = "(313) 555-3349",
                    HomePage = null
                };
                context.Suppliers.Add(supplier3);

                context.SaveChanges();
            }


            if (!context.Products.Any())
            {
                var category1 = context.Categories.First(c => c.CategoryName == "Beverages");
                var category2 = context.Categories.First(c => c.CategoryName == "Condiments");

                var supplier1 = context.Suppliers.First(s => s.CompanyName == "Exotic Liquids");
                var supplier2 = context.Suppliers.First(s => s.CompanyName == "New Orleans Cajun Delights");

                var product1 = new Product()
                {
                    ProductName = "Chai",
                    QuantityPerUnit = "10 boxes x 20 bags",
                    UnitPrice = 18,
                    UnitsInStock = 39,
                    UnitsOnOrder = 0,
                    ReorderLevel = 10,
                    Discontinued = false,
                    Supplier = supplier1,
                    Category = category1,
                };
                context.Products.Add(product1);

                var product2 = new Product()
                {
                    ProductName = "Chef Anton's Cajun Seasoning",
                    QuantityPerUnit = "48 - 6 oz jars",
                    UnitPrice = 22,
                    UnitsInStock = 53,
                    UnitsOnOrder = 0,
                    ReorderLevel = 0,
                    Discontinued = false,
                    Supplier = supplier2,
                    Category = category2,
                };
                context.Products.Add(product2);

                context.SaveChanges();
            }
        }
    }
}
