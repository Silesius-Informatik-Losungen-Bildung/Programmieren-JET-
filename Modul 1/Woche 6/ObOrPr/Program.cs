namespace ObOrPr
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Auto auto1 = new Auto("Opel Corsa", 2000);
            auto1.Anbotspreis = 15000;
            //auto1.Baujahr = 1700;
            // auto1.MarkeModell = "Opel Corsa";
            auto1.Farbe = new Farbe() { IsMetalic =true, Color = System.Drawing.Color.Blue };
            auto1.Antriebsart = "Allrad";
            // auto1.Baujahr = 2025;
            auto1.Geschwindigkeit = 300;
            auto1.Fahren();
            auto1.Huppen();
           
            Console.WriteLine(auto1.IstZweispurig);

            Auto auto2 = new Auto("Suzuki Swift", 1999);
            auto2.Anbotspreis = 10000;
            // auto2.MarkeModell = "Suzuki Swift";
            auto1.Farbe = new Farbe() { IsMetalic = false, Color = System.Drawing.Color.Black };
            auto2.Antriebsart = "Allrad";
            auto2.Huppen();

            // auto2.Baujahr = 2012;

            auto2.Geschwindigkeit = 150;
            auto2.Fahren();


            //// Prozedurale Programmierung (Ablauflogik statt Objekte)
            //// Auto1: Vor der Einführung von Objektorientierung
            //var markeModell_Auto1 = "Opel Corsa";
            //var autoFarbe_Auto1 = "rot";
            //int kmStand_Auto1 = 100;
            //var autoBauJahr_Auto1 = 1999;
            //var autoKmStand_Auto1 = 160000;
            //var isGebrauchtWagen_Auto1 = kmStand_Auto1 > 10;


            //// Auto2: Vor der Einführung von Objektorientierung
            //var markeModell_Auto2 = "Suzuki Swift";
            //var autoFarbe_Auto2 = "blau";
            //int kmStand_Auto2 = 100;
            //int bauJahr_Auto2 = 1999;
            //var autoBauJahr_Auto2 = 1999;
            //var autoKmStand_Auto2 = 160000;
            //var isGebrauchtWagen_Auto2 = kmStand_Auto2 > 10;
        }
    }
}
