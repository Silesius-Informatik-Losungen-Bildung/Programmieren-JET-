namespace Polymorphie
{
    public class PrivatKunde : Kunde
    {
        public string Wohnort { get; set; }

        public PrivatKunde(string anrede, string name, string wohnort) : base(anrede, name)
        {
            Wohnort = wohnort;
        }

        public override string GetAdresse() // Überschreibung 
        {
            return $"{base.GetAdresse()} {Wohnort}"; // Wohnort wird zusätzlich ausgegeben 
        }

        public override void AddGuthaben(decimal betrag)
        {
            // Die Polymorphie ermöglicht in einer überschriebenen Methode der Kindklasse die Hinterlegung einer ganz anderen Logik, 
            // als jene, die Elternkalsse in ihrer gleichnamigen Methode anbietet.

            // Hier rufe ich z.B. die zugrunde liegende Methode AddGuthaben der Elternklasse GAR NICHT auf
            // stattdessen erhöhe ich das Guthaben, indem ich die protected-Property der Elternklasss "Guthaben" direkt verwende
            
            base.Guthaben += (0.05m * betrag); 
        }

    }
}
