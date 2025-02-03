namespace Log
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string msg = "Der Server wurde wegen Wartungsarbeiten heruntergefahren.";
            var logBasis = new Log(msg);
            var logVers2 = new LogVers2(msg);
            var logXy = new LogXy(msg);


            // Alle drei Objekte vereint eines: sie sind von Typ Log
            // Ich kann also in allen Dreiern die Methode Send() des Objektes Log aufrufen.
            Log log = logBasis;
            log.Send();
            Console.WriteLine("----------------------------------------------------------");

            // Von Log erbende Objekte können sogar ihre eigene Send()-Implemetierung (das eigene Gesicht davon) nach Außen zeigen lassen
            log = logVers2;
            log.Send();
            Console.WriteLine("----------------------------------------------------------");

            log = logXy;
            log.Send();
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");

            // Überschreibung von Methoden ist keine Pflicht.
            var logEinfachWieEsBasisWill = new LogEinfachWieEsBasisWill(msg);
            logEinfachWieEsBasisWill.Send();
            Console.WriteLine("----------------------------------------------------------");

        }
    }
}
