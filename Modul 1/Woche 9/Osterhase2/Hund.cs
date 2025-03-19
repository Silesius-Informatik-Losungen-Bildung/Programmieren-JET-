namespace Osterhase2
{
    public sealed class Hund : Tier
    {
        public Hund(string name, string farbe, double gewichtInKg, int alter):
            base(ArtenTyp.Säugetier, new List<string>() { "Knochen", "Hundefutter", "Wasser" })
        {
            Name = name;
            Farbe = farbe;
            GewichtInKg = gewichtInKg;
            Alter = alter;
        }

        public void Bellen()
        {

        }

    }
}
