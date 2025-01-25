
using BankKonto;

var bankkonto = new Bankkonto()
{
    Name = "Kevin",
    Nummer = "34832483204234"
};

Console.WriteLine("Herzlich willkommen am Bankomat!");
try
{
    var antwort = getKudnenAntwort();
    do
    {
        if (antwort == "1")
        {
            Console.WriteLine("Welchen Betrag möchten Sie einzahlen?");
            bankkonto.Einzahlen(getBetrag());
        }
        else if (antwort == "2")
        {
            Console.WriteLine("Welchen Betrag möchten Sie ausbezahlt bekommen?");
            bankkonto.Abheben(getBetrag());
        }
        antwort = getKudnenAntwort();
    }
    while (antwort != "3");

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
Console.WriteLine("Aufwiederschaun");


double getBetrag()
{
    return double.Parse(Console.ReadLine());
}

string getKudnenAntwort()
{
    Console.WriteLine("KontoStand: " + bankkonto.Stand);
    Console.WriteLine("Was möchten Sie tun? Einzahlen (1), Auszahlen (2), Abbrechen (3)");
    return Console.ReadLine();
}

