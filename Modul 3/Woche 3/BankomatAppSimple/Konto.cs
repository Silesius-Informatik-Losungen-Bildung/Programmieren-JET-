namespace BankomatAppSimple
{
    public class Konto
    {
        public double Kontostand { get; set; }
        public string Kontonummer { get; set; }
        public string KundenName { get; set; }
        public int Pin { get; }
        public Konto(string kundenName, string kontonummer)
        {
            Kontostand = 10000;
            Kontonummer = kontonummer;
            Pin = 1234;
            KundenName = kundenName;

        }

        public void ShowKontostand()
        {
            Console.WriteLine("Ihr Kontostand ist: " + Kontostand);
        }
        public void GeldAbheben(double betrag)
        {
            if (betrag < 0)
            {
                throw new ArgumentException("Betrag darf nicht negativ sein");
            }
            if (Kontostand < betrag)
            {
                throw new BetragZuHochException();
            }
            Kontostand = Kontostand - betrag;

        }

        public void GeldEinzahlen(double betrag)
        {

            if (betrag < 0)
            {
                throw new ArgumentException("Betrag darf nicht negativ sein");
            }
            Kontostand = Kontostand + betrag;

        }


    }
}
