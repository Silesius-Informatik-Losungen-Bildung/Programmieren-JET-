namespace Osterhase2
{
    public class Hase: Tier
    {
        protected Hase(string name, string farbe, double gewichtInKg, int alter):
            base(ArtenTyp.Säugetier, new List<string>() { "Karotten", "Löwenzahn", "Redbull" })
        {
            Name = name;
            Farbe = farbe;
            GewichtInKg = gewichtInKg;
            Alter = alter;
        }

        protected void Hoppeln()
        {
            
        }
    }
}

