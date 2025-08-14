namespace BankomatAppSimple
{
    internal class UngueltigePinException:Exception
    {
        public UngueltigePinException():base("Fehler bei Eingabe: ungültige Pin") {}
    }
}
