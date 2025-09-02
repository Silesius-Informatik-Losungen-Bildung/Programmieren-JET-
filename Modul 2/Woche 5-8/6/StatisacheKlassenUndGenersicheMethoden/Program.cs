
using System.Globalization;

namespace StatisacheKlassenUndGenersicheMethoden
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Einstellungen
            
            Console.WriteLine($"Version: {Einstellungen.Anwendungsversion}");
            Console.WriteLine($"Sprache: {Einstellungen.Sprache}");
            Console.WriteLine($"Timeout: {Einstellungen.TimeoutInSekunden} Sekunden");
                // Ressourcenfressende Werte sind gecacht für die ganze Anwendung
            Console.WriteLine(Einstellungen.DbConnectionString);
            Console.WriteLine(Einstellungen.WertAusDerDatenbank);
                // noch einmal auf  WertAusDerDatenbank zugreifen
            Console.WriteLine(Einstellungen.WertAusDerDatenbank);

     
            // Static in Non-Static
            double ergebnis1 = Mathematik.Addiere(5, 10);
            Console.WriteLine($"Ergebnis der Multiplikation: {ergebnis1}");

            double ergebnis2 = Mathematik.Subtrahiere(2, 3);
            Console.WriteLine($"Ergebnis der Potenzierung: {ergebnis2}");

                // Erstellung einer Instanz der Klasse
            Mathematik rechner = new Mathematik(5, 7);

            // Aufruf der nicht-statischen Methoden über die Instanz
            double ergebnis3 = rechner.Addiere();
            Console.WriteLine($"Letzter Wert nach Addition: {ergebnis3}");

            double ergebnis4 = rechner.Subtrahiere();
            Console.WriteLine($"Letzter Wert nach Subtraktion: {ergebnis4}");



            // Erweiterungsmethoden
            string text = "Hallo";
            Console.WriteLine(text.Verdoppeln());


            // Generische Methoden
            if (GenerischeMethoden.TryParse<int>("12", out int? resultInt))
                Console.WriteLine(resultInt);

            if (GenerischeMethoden.TryParse<bool>("true", out bool? resultBool))
                Console.WriteLine(resultBool);

            if (GenerischeMethoden.TryParse<decimal>("12,56", out decimal? resultDecimal))
                Console.WriteLine(resultDecimal);

            if (GenerischeMethoden.TryParse<char>('e', out char? resultChar))
                Console.WriteLine(resultChar);

        }
    }
}
