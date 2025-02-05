namespace Programmier_Grundkonzepte_2_
{
    public static class Switch
    {
        public static void Klassisch()
        {
            int tag = 3;

            switch (tag)
            {
                case 1:
                    Console.WriteLine("Montag");
                    break;
                case 2:
                    Console.WriteLine("Dienstag");
                    break;
                case 3:
                    Console.WriteLine("Mittwoch");
                    break;
                case 4:
                    Console.WriteLine("Donnerstag");
                    break;
                case 5:
                    Console.WriteLine("Freitag");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Wochenende!");
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe.");
                    break;
            }
        }

        enum Status { Offen, InBearbeitung, Abgeschlossen, Storniert }
        public static void MitEnum()
        {
            Status auftragsStatus = Status.InBearbeitung;
            switch (auftragsStatus)
            {
                case Status.Offen:
                    Console.WriteLine("Auftrag wurde erfasst.");
                    break;
                case Status.InBearbeitung:
                    Console.WriteLine("Auftrag ist in Bearbeitung.");
                    break;
                case Status.Abgeschlossen:
                    Console.WriteLine("Auftrag ist abgeschlossen.");
                    break;
                case Status.Storniert:
                    Console.WriteLine("Auftrag wurde storniert.");
                    break;
            }
        }

        public static void MitWhen()
        {
            int alter = 17;

            switch (alter)
            {
                case int n when n < 18:
                    Console.WriteLine("Du bekommst einen Jugendrabatt.");
                    break;
                case int n when n >= 65 && n <= 130:
                    Console.WriteLine("Seniorenrabatt verfügbar.");
                    break;
                default:
                    Console.WriteLine("Normaler Preis.");
                    break;
            }

        }

        public static void MitExpressions()
        {
            int punkte = 85;
            string note = punkte switch
            {
                >= 90 => "Sehr gut",
                >= 80 => "Gut",
                >= 70 => "Befriedigend",
                >= 60 => "Ausreichend",
                _ => "Nicht bestanden"
            };

            Console.WriteLine(note);

        }

        public static void MitTupeln()
        {
            (string figur, bool istErsterZug) = ("Bauer", true);

            int maxFelder = (figur, istErsterZug) switch
            {
                ("Bauer", true) => 2,
                ("Bauer", false) => 1,
                ("Springer", _) => 3,  // "_" bedeutet, dass der Wert egal ist
                ("Läufer", _) => 8,
                _ => 0
            };
        }
    }
}
