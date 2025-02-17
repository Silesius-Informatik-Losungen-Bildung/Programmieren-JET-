using Microsoft.Extensions.Configuration;

namespace StatisacheKlassenUndGenersicheMethoden
{
    public static class Einstellungen
    {
        // Statischer Konstruktor zur Initialisierung
        static Einstellungen()
        {
            IConfiguration config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .Build();

            DbConnectionString = config["Datenbank:Verbindungszeichenkette"];

            SetWertAusDerDatenbank();
        }

        public static string Anwendungsversion { get; } = "1.0.0";
        public static string Sprache { get; } = "Deutsch";
        public static int TimeoutInSekunden { get; } = 30;
        public static string? DbConnectionString { get; }

        public static string? WertAusDerDatenbank { get; private set; }

        private static void SetWertAusDerDatenbank()
        {
            // ... Zugrifsslogik auf Datenbank....
            WertAusDerDatenbank = "Wert aus der Datenbank";
        }
    }

}
