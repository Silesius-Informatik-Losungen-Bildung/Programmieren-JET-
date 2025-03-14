namespace TiereVerwaltung
{
    class Tier
    {
        public enum ArtType
        {
            Hund,
            Katze
        }
        
        public ArtType Art { get; private set; }
        public string Name { get; private set; }
        public int Alter { get; private set; }
        public double Gewicht { get; private set; }

        public Tier(ArtType art, string name, int alter, double gewicht)
        {
            Art = art;
            Name = name;
            Alter = alter;
            Gewicht = gewicht;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine("Art: " + Art + ", Name: " + Name + ", Alter: " + Alter + " Jahre, Gewicht:" + Gewicht + " kg.");
        }
    }
}
