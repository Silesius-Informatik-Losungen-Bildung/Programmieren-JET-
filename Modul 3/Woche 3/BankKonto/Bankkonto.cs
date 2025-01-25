namespace BankKonto
{
    public class Bankkonto
    {
        public required string Nummer { get; set; }
        public required string Name { get; set; }
        public double Stand { get; set; } = 0;

        public void Einzahlen(double betrag)
        {
            if (betrag > 0)
                Stand = Stand + betrag;
        }

        public void Abheben(double betrag)
        {
            if (betrag > Stand)
                throw new BankingException();

            if (betrag > 0)
                Stand = Stand - betrag;
        }
    }
}
