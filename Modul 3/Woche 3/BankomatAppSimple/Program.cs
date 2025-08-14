namespace BankomatAppSimple
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Konto konto1 = new Konto("Mustermann", "bbrz123");
            bool exit = false;



            Console.WriteLine("Wilkommen beim Bankomaten");
            Console.WriteLine("Bitte geben sie Ihre Kontonummer ein.");
            try
            {
                var inputKtoNummer = Console.ReadLine();

                if (!inputKtoNummer.Contains("bbrz"))
                {
                    throw new UngueltigeKontonummer();
                }



                Console.WriteLine("Bitte geben sie Ihren Pin ein");

                int.TryParse(Console.ReadLine(), out int inputPin);

                if (inputPin != konto1.Pin)
                {
                    throw new UngueltigePinException();
                }
                while (!exit)
                {

                    Console.WriteLine("\nwählen sie eine Aktion");
                    Console.WriteLine("1 Kontostand");
                    Console.WriteLine("2 Geld abheben");
                    Console.WriteLine("3 Geld einzahlen");
                    Console.WriteLine("27 Beenden\n");

                    int.TryParse(Console.ReadLine(), out int aktion);

                    switch (aktion)
                    {

                        case 1:
                            konto1.ShowKontostand();
                            break;

                        case 2:
                            Console.WriteLine("Geben sie den gewünschten Betrag ein.");
                            double.TryParse(Console.ReadLine(), out double betrag);
                            konto1.GeldAbheben(betrag);
                            konto1.ShowKontostand();
                            break;
                        case 3:
                            Console.WriteLine("Geben sie den gewünschten Betrag ein.");
                            double.TryParse(Console.ReadLine(), out double Einzahlungsbetrag);
                            konto1.GeldEinzahlen(Einzahlungsbetrag);
                            konto1.ShowKontostand();
                            break;
                        case 27:
                            Console.WriteLine("Programm wird beendet"); exit = true; break;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

