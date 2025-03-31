using static Bankomat.EigeneExceptions;

namespace Bankomat
{
    sealed class Bankomat
    {
        private Konto aktuellesKonto = new Konto("1234", 1000);

        public void Start()
        {
            Console.WriteLine("Willkommen beim Bankomat!");

            Console.Write("Schieben Sie Ihre Bankomatkarte hinein (bitte Kartennummer eingeben)");
            if (Console.ReadLine()?.ToUpper().IndexOf("BBRZ") == -1)
                throw new FalscheKarteException();


            Console.Write("Bitte geben Sie Ihre PIN ein: ");
            aktuellesKonto.PruefePin(Console.ReadLine());


            MenuAnzeigen();
        }

        private void MenuAnzeigen()
        {
            Console.WriteLine("1. Kontostand");
            Console.WriteLine("2. Geld abheben");
            Console.WriteLine("3. Geld einzahlen");
            Console.WriteLine("Sonst. Taste: Abbruch");

            var antwort = Console.ReadLine();
            if (antwort != "1" && antwort != "2" && antwort != "3")
            {
                Console.WriteLine("Vielen Dank, Aufwiederschaun!");
                return;
            }
            
            switch (antwort)
            {
                case "1":
                    Console.WriteLine($"Ihr Kontostand beträgt: {aktuellesKonto.Kontostand} Euro");
                    break;
                case "2":
                    Console.Write("Betrag eingeben: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal betragAbheben))
                    {
                        aktuellesKonto.Abheben(betragAbheben);
                    }
                    break;
                case "3":
                    Console.Write("Betrag eingeben: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal betragEinzahlen))
                    {
                        aktuellesKonto.Einzahlen(betragEinzahlen);
                    }
                    break;
            }

            MenuAnzeigen();
        }
    }
}
