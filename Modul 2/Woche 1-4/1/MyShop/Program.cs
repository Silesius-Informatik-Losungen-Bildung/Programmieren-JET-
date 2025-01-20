// Company instanzieren
using MyShop.Models;

var company = new Company()
{
    Name = "Billa",
    Email = "bill@billa.xy",
    Phone = "3432432432",
    PostCode = 1140,
    City = "Wien",
    Street = "Kendlerstr 34",
    Uid = "AT123456789",
    Website = "www.example.com",
    Contact = "Alexander"
};



Console.WriteLine(company.CompanyId);
Console.WriteLine(company.CompanyId);



var company2 = new Company()
{
    Name = "Billa",
    Email = "bill@billa.xy",
    Phone = "3432432432",
    PostCode = 1140,
    City = "Wien",
    Street = "Kendlerstr 34",
    Uid = "AT123456789",
    Website = "www.example.com",
    Contact = "Alexander"
};

Console.WriteLine(company2.CompanyId);
Console.WriteLine(company2.CompanyId);
Console.WriteLine(company2.CompanyId);
Console.WriteLine(company2.CompanyId);

// Lieferanten für Produkte instanzieren
var supplier1 = new Supplier
{
    Name = "Lieferant 1",
    Email = "aaa@bbb.at",
    Street = " Kendlerstr 34",
    City = "Wien",
    PostCode = 1140,
    Phone = "32423423",
};
var supplier2 = new Supplier
{
    Name = "Lieferant 2",
    Email = "dsds@dsdsd.at",
    Street = " Kendlerstr 34",
    City = "Wien",
    PostCode = 1140,
    Phone = "65487789789",
};

// Produkt 1 instanzieren
var product1 = new Product
{
    Name = "Kugeschreiber gelb",
    Price = 1.20m,
    // Mehrere Produkte können von mehreren Lieferanten geliefert werden (N:M - Beziehung, "viele zu viele")
    Suppliers = new List<Supplier> { supplier1, supplier2 }
};

// Produkt 2 instanzieren
var product2 = new Product
{
    Name = "Druckpapier premium",
    Price = 9.9m,
    // Mehrere Produkte können von mehreren Lieferanten geliefert werden (N:M - Beziehung, "viele zu viele")
    Suppliers = new List<Supplier> { supplier1 }
};

//// Produkte in Company einstellen
//// 1 Company kann mehrere Produkte haben (1:N - Beziehung, "eins zu viele")
//company.AddProduct(product1);
//company.AddProduct(product2);