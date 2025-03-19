
namespace Osterhase2
{
    internal class Program
    {

        static Dictionary<int, string> VersteckOrte = new Dictionary<int, string>();
        static List<Ei> Eier = new List<Ei>();
        static Osterhase Osterhase;

        static Program()
        {
            InitRessources();
        }

        private static void InitRessources()
        {
            VersteckOrte.Add(1, "Unter dem Kirschbaum");
            VersteckOrte.Add(2, "Unter dem Rosenstrauss");
            VersteckOrte.Add(3, "Am Brunnen");

            Eier.Add(new Ei { Farbe = "Blau", Größe = "M" });
            Eier.Add(new Ei { Farbe = "Rot", Größe = "XL" });
            Eier.Add(new Ei { Farbe = "Rose", Größe = "S" });
            Eier.Add(new Ei { Farbe = "Grün", Größe = "XLL" });
        }

        static void Main(string[] args)
        {
            Osterhase = new Osterhase("Bunny", "Blau", gewichtInKg: 3.4, VersteckOrte, alter: 1, Eier);

            string antwort = String.Empty;
            while (antwort != "3")
            {
                Console.WriteLine("Was möchten Sie machen?");
                Console.WriteLine("1: Eier verstecken.");
                Console.WriteLine("2: Eier kaufen.");
                Console.WriteLine("xx: Füttern");
                Console.WriteLine("3: Abbrechen.");

                antwort = Console.ReadLine();

                switch (antwort)
                {
                    case "1":
                        EierVerstecken();
                        break;
                    case "2":
                        EierKaufen();
                        break;
                    default:
                        return;
                }


            }
        }

        private static void EierKaufen()
        {
            Console.WriteLine("Wie viele Eier wollen Sie kaufen (zur Zeit nur Blau M verfügbar)?");
            int.TryParse(Console.ReadLine(), out int anzahlEier);
            for (var i = 0; i < anzahlEier; i++)
            {
                Eier.Add(new Ei { Farbe = "Blau", Größe = "M" });
            }
            Console.WriteLine("Sie haben " + anzahlEier + " Eier gekauft.");
        }

        private static void EierVerstecken()
        {
            Console.WriteLine("Wählen Sie einen Versteckort aus:");

            foreach (KeyValuePair<int, string> item in VersteckOrte)
                Console.WriteLine(item.Key + ": " + item.Value);

            int.TryParse(Console.ReadLine(), out int versteckOrtKey);

            if(Eier.Count == 0)
            {
                Console.WriteLine("Keine Eire mehr vorhanden");
                return;
            }
            
            Console.WriteLine("Wie viele Eier wollen Sie vertecken? (" + Eier.Count + ") Eier verfügbar." );
            int.TryParse(Console.ReadLine(), out int anzahlEierZumVerstecken);

            Osterhase.EierVerstecken(VersteckOrte.First(x => x.Key == versteckOrtKey), anzahlEierZumVerstecken);
        }
    }
}
