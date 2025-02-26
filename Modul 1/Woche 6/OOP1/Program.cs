using Test;

class Programm
{
    static void Main(string[] args)
    {

        // Auto1: Vor der Einführung von Objektorientierung
        int kmStandAuto1 = 100;
        int bauJahrAuto1 = 1999;
        var markeModell_Auto1 = "Suzuki Swift";
        var autoFarbe_Auto1 = "blau";
        var autoBauJahr_Auto1 = 1999;
        var autoKmStand_Auto1 = 160000;
        var AutoIsGebrauchtWagen_Auto1 = kmStandAuto1 > 10;

        // Auto2: Vor der Einführung von Objektorientierung
        int kmStandAuto2 = 100;
        int bauJahrAuto2 = 1999;
        var markeModell_Auto2 = "Suzuki Swift";
        var autoFarbe_Auto2 = "blau";
        var autoBauJahr_Auto2 = 1999;
        var autoKmStand_Auto2 = 160000;
        var AutoIsGebrauchtWagen_Auto2 = kmStandAuto2 > 10;



        // Auto 1 mit Objektorientierung
        Auto auto1 = new Auto("Suzuki Swift");
        //to1.BauJahr = 2012;
        auto1.MarkeModell = "markeModell_Auto2;";

        Console.WriteLine(auto1.KmStand);
        auto1.KmStand = 10000;
        //auto1.IsGebrauchtWagen = true;
        Console.WriteLine(auto1.IsGebrauchtWagen);


        // Auto 2 mit Objektorientierung
        Auto auto2 = new Auto("Opel XX", 223);
        auto2.IsMeinAuto = true;
        Console.WriteLine(auto2.IsMeinAuto);


    }



}

