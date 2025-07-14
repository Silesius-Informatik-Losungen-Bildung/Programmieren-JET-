using AbstraktVersiegeltPolymorph.Models;
using AbstraktVersiegeltPolymorph.Models.Base;

class Program
{
    static void Main(string[] args)
    {

        //// folgende Zeile einkommentieren, um zu sehen, dass man abtrakte Klasse ElektroGeraet nicht instaziieren kann.
        // var elektroGeraet = new ElektroGeraet();

        // Test abtrakte Methode MessageBeimHochfahren

        var kuehlschrank = new Kuehlschrank("Liebherr", "MRFvc 5501", 120, 544);
        Console.WriteLine(kuehlschrank.MomentaneTemperatur);
        Console.WriteLine(kuehlschrank.MessageBeimHochfahren());
        kuehlschrank.MessageBeimHerunterfahren();


        // Test abtrakte Methode MessageBeimHochfahren
        var smartphone = new Smartphone("Samsung", "Galaxy XCover7", 120);

        Console.WriteLine(smartphone.MessageBeimHochfahren());
    }
}

