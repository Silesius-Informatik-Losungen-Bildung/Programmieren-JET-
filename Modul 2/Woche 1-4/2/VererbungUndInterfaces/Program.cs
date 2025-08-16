using VererbungUndInterfaces;


var ahorn = new Ahorn // ist ein Ahorn, die von Baum erbt
{
    Blattfarbe = "gelb",
    Hoehe = 3,
    Kronenform = "normal",
};

var tanne = new Tanne() // ist eine Tanne, die von Baum erbt die auch Eigenschaften von Produkt implementiert
{
    Hoehe = 9,
    Kronenform = "schön",
    AnzahlZapfen = 120,
    IstWeihnachtsProdukt = true,
    Preis = 120,
    ProduktId = 5454
};

var rucksack = new Rucksack() // ist ein Rucksack, die auch Eigenschaften von Produkt implementiert
{
    AnzahlFaecher = 12,
    IstWeihnachtsProdukt = false,
    Material = "Baumwolle",
    Preis = 55,
    ProduktId = 123
};