using static Bankomat.EigeneExceptions;

namespace Bankomat
{

    class Konto
    {
        private string pin;
        public decimal Kontostand { get; private set; }

        public Konto(string pin, decimal startBetrag)
        {
            this.pin = pin;
            Kontostand = startBetrag;
        }

        public void PruefePin(string eingabePin)
        {
            if(pin != eingabePin)
                throw new FalschePinException();
        }

        public void Abheben(decimal betrag)
        {
            if (betrag <= 0)
                throw new BetragMussGrößer0Sein();
            if (betrag > Kontostand)
                throw new NichtGenügendGuthabenException();

            Kontostand -= betrag;
            Console.WriteLine($"{betrag} Euro abgehoben. Neuer Kontostand: {Kontostand} Euro");

        }

        public void Einzahlen(decimal betrag)
        {
            if (betrag <= 0)
                throw new BetragMussGrößer0Sein();

            Kontostand += betrag;
            Console.WriteLine($"{betrag} Euro eingezahlt. Neuer Kontostand: {Kontostand} Euro");
        }
    }
}
