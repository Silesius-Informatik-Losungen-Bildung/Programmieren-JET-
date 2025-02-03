namespace Polymorphie
{
    public class Kunde
    {
        public string Anrede { get; set; }
        public string Name { get; set; }
        public bool Stammkunde { get; set; }
        public decimal Guthaben { get; protected set; } // durch protected nur in Kindklassen beschreibbar

        public Kunde(string anrede, string name)
        {
            Anrede = anrede;
            Name = name;
        }

        public virtual string GetAdresse() // virtual macht Überschreibung in Kindlassen möglich
        {
            return $"{Anrede} {Name}";
        }

        public virtual void AddGuthaben(decimal betrag) // virtual macht Überschreibung in Kindlassen möglich
        {
            if (Stammkunde) // Nur ein Stammkunde darf hier sein Guthaben erhöhen 
                Guthaben += betrag;
        }

    
    }
}
