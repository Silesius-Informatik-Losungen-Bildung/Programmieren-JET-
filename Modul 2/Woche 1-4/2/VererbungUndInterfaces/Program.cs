using VererbungUndInterfaces;

Console.WriteLine("Hello, World!");

var ahorn = new Ahorn
{
    Blattfarbe = "gelb",
    Hoehe = 3,
    Kronenform = "normal"
};

var tanne = new Tanne()
{
    Hoehe = 9,
    Kronenform = "schön",
    AnzahlZapfen = 120,
    IstWeihnachtsProdukt = true,
    Preis = 120
};