using Test;

class Programm
{
    static void Main(string[] args)
    {

        // Prozedurale Programmierung (Ablauflogik statt Objekte)
        // Auto1: Vor der Einführung von Objektorientierung
        var markeModell_Auto1 = "Opel Corsa";
        var autoFarbe_Auto1 = "rot";
        int kmStand_Auto1 = 100;
        int bauJahr_Auto1 = 1999;
        var autoBauJahr_Auto1 = 1999;
        var autoKmStand_Auto1 = 160000;
        var isGebrauchtWagen_Auto1 = kmStand_Auto1 > 10;

        // Auto2: Vor der Einführung von Objektorientierung
        var markeModell_Auto2 = "Suzuki Swift";
        var autoFarbe_Auto2 = "blau";
        int kmStand_Auto2 = 100;
        int bauJahr_Auto2 = 1999;
        var autoBauJahr_Auto2 = 1999;
        var autoKmStand_Auto2 = 160000;
        var isGebrauchtWagen_Auto2 = kmStand_Auto2 > 10;

        //-----------------------------------------------------------

        // Objektorientierung (Klassen können als Objektvorlagen wiederverwendet werden)
        // Auto 1 mit Objektorientierung
        Auto auto1 = new Auto("Opel Corsa", 100,"AHJKKR&JJLKJL");
        auto1.Huppen();
        //auto1.BauJahr = 2012;
        //auto1.MarkeModell = "Suzuki Swift";
        Console.WriteLine(auto1.KmStand);
        auto1.KmStand = 10000;
        //auto1.IsGebrauchtWagen = true;
        Console.WriteLine(auto1.IsGebrauchtWagen);


        // Auto 2 mit Objektorientierung
        Auto auto2 = new Auto("Suzuki Swift", 223);
        auto2.IsMeinAuto = true;
        //
        //Console.WriteLine(auto2.IsMeinAuto);


    }



}

