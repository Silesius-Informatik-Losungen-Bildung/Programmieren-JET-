using AbstraktVersiegeltPolymorph.Models;
using AbstraktVersiegeltPolymorph.Models.Base;

class Program
{
    static void Main(string[] args)
    {

        //// folgende Zeile einkommentieren, um zu sehen, dass man abtrakte Klasse ElektroGeraet nicht instaziieren kann.
        // var elektroGeraet = new ElektroGeraet();

        // Test abtrakte Methode MessageBeimHochfahren
        var kuehlschrank = new Kuehlschrank
        {
            Marke = "Liebherr ",
            Modell = "MRFvc 5501",
            Kuehlvolumen = 544,
            LeistungInWatt = 120
        };

        Console.WriteLine(kuehlschrank.MessageBeimHochfahren());


        // Test abtrakte Methode MessageBeimHochfahren
        var smartphone = new Smartphone
        {
            Marke = "Samsung",
            Modell = "Galaxy XCover7",
            AnzahlKameras = 2,
            HatAkku = true,
            LeistungInWatt = 6,
            HatNetzanschluss = false
        };

        Console.WriteLine(smartphone.MessageBeimHochfahren());
    }
}

