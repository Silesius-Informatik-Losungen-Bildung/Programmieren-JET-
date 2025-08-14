namespace BankomatAppSimple
{
    internal class BetragZuHochException:Exception
    {
        public BetragZuHochException() : base("Betrag ist zu hoch.") { }
    }
}
