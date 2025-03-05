namespace Osterhase2
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            var versteckOrte = new List<string>();
            versteckOrte.Add("Unter dem Kirschbaum");
            versteckOrte.Add("Unter dem Rosenstrauss");
            versteckOrte.Add("Am Brunnen");

            var eier = new List<Ei>();
            eier.Add(new Ei { Farbe = "Blau", Größe = "M" });
            eier.Add(new Ei { Farbe = "Rot", Größe = "XL" });
            eier.Add(new Ei { Farbe = "Rose", Größe = "S" });
            eier.Add(new Ei { Farbe = "Grün", Größe = "XLL" });

            var osterhase = new Osterhase("Bunny", "Blau", gewichtInKg: 3.4, versteckOrte, alter: 1, eier);

            osterhase.EierVerstecken("Unter dem Rosenstrauss", 1);

            osterhase.EierVerstecken("Unter dem Kirschbaum", 2);

            osterhase.EierVerstecken("Unter dem Rosenstrauss", 1);

            osterhase.EierVerstecken("Am Brunnen", 1);

        }
    }
}
