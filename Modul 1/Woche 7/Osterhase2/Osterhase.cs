namespace Osterhase2
{
    public sealed class Osterhase: Hase
    {
        // Eigenschaften
        public List<Ei> Eier { get; set; }
        private List<string> Versteckorte { get; set; }
        public double Geschwindigkeit { get; set; }
        public int Energielevel { get; private set; }
        public bool IstMüde
        {
            get
            {
                return (Energielevel < 20);
            }
        }

        public Osterhase(string name, string farbe, double gewichtInKg, List<string> versteckorte, int alter, List<Ei> eier):
            base(name, farbe, gewichtInKg, alter)
        {
            Versteckorte = versteckorte;
            Eier = eier;
            Energielevel = 100; // startet voller Energie
        }

        public void EierVerstecken(string versteckort, int anzahlEierZumVerstecken)
        {
            Console.WriteLine("\n**** " + nameof(EierVerstecken) + " -Operation am " + versteckort + " mit " + anzahlEierZumVerstecken + " Ei(ern) beginnt");

            if (IstMüde)
            {
                Console.WriteLine("Osterhase ist zu müde, um Eier zu vertecken. Füttern Sie ihn oder lassen Sie ihn schlafen!\n");
                return;
            }

            if (!Versteckorte.Contains(versteckort))
            {
                Console.WriteLine("Fehler: Versteckort " + versteckort + " gibt es nicht (mehr).\n");
                return;
            }
            if (anzahlEierZumVerstecken <= 0)
            {
                Console.WriteLine("Fehler: Sie müssen mindestens ein Ei vertecken wollen..\n");
                return;
            }
            if (Eier.Count == 0)
            {
                Console.WriteLine("Fehler: Ihr Eier-Kontingent ist leer oder aufgebraucht.\n");
                return;
            }
            if (Eier.Count - anzahlEierZumVerstecken < 0)
            {
                Console.WriteLine("Warnung: Sie haben zu wenige Eier, als Sie es verstecken wollen");
            }

            for (int i = 0; i < anzahlEierZumVerstecken; i++)
            {
                if (Eier.Count > 0)
                {
                    Console.WriteLine("Das Ei mit der Id: " + Eier.First().Id + " und der Farbe " + Eier.First().Farbe + " und der Größe " + Eier.First().Größe + " wird am Ort " + versteckort + " gelegt.");
                    Eier.Remove(Eier.First());
                }
            }

            Energielevel = Energielevel - 20;
            Versteckorte.Remove(versteckort);
        }
    }
}

