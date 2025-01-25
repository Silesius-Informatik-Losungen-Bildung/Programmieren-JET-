namespace BankKonto
{
    public class BankingException : Exception
    {
        public BankingException() : base("Sie haben zu wenig Mitteln, um diese Operation auszuführen!")
        {
        }
    }

}
