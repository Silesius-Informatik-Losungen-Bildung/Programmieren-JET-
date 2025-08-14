namespace BankomatAppSimple
{
    public  class UngueltigeKontonummer: Exception
    {
        public UngueltigeKontonummer() : base("Fehler bei Eingabe: ungültige Kontonummer")
        {

        }
    }
   }
