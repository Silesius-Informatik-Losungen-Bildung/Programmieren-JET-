namespace RecordsDemoApp
{
    internal class Program
    {
        // Kurze Syntax mit Auto-Init
        public record Fahrzeug(string Marke, string Modell);
        public record Auto(string Marke, string Modell, int Baujahr) : Fahrzeug(Marke, Modell);

        static void Main(string[] args)
        {
            // Objekte, die auf Klassen aufbauen vergleichen ihre Adressen im Speicher

            var p1 = new PersonClass("Max", 33);
            var p2 = new PersonClass("Max", 33);
            var p3 = new PersonClass("Max", 33);
            var p4 = new PersonClass("Max", 33);
            var p5 = new PersonClass("Max", 33);
            var p6 = new PersonClass("Max", 33);
            var p7 = new PersonClass("Max", 33);

            bool istGleich = p1 == p2;
            Console.WriteLine(istGleich);

            var classList = new List<PersonClass> { p1, p2, p3, p4, p5, p6, p7 };

            // Objekte, die auf Records aufbauen vergleichen ihre Inhalte
            var p1r = new PersonRecord("Max", 33);
            var p2r = new PersonRecord("Max", 33);
            var p3r = new PersonRecord("Max", 33);
            var p4r = new PersonRecord("Adam", 33);
            var p5r = new PersonRecord("Adam", 33);
            var p6r = new PersonRecord("Max", 33);
            var p7r = new PersonRecord("Adam", 33);

            // p1r.Name = "Adam"; unverännderbar!
            var p1rCopy = p1r with { Name = "Maxima" };


            bool istGleichr = p1r == p2r;
            Console.WriteLine(istGleichr);

            var recordList = new List<PersonRecord> { p1r, p2r, p3r, p4r, p5r, p6r, p7r };

            // Iterrieren Sie classList und zählen Sie doppelte Einträge in einer separaten Variable und geben Sie diese aus
            DopplerCheck(classList);

            // Iterrieren Sie recordList und zählen Sie doppelte Einträge in einer separaten Variable und geben Sie diese aus
            DopplerCheck(recordList);


            Fahrzeug fahrzeug = new Auto("VW", "Golf", 2022);

            switch (fahrzeug)
            {
                case Auto(var marke, var modell, var baujahr):
                    Console.WriteLine($"{marke} {modell} ({baujahr})");
                    break;

                case Fahrzeug(var marke, var modell):
                    Console.WriteLine($"{marke} {modell}");
                    break;
            }

            Console.WriteLine(fahrzeug);
        }

        private static void DopplerCheck<T>(IList<T> list)
        {
            var zaehler = 0;
            var besucht = new bool[list.Count];
            for (int i = 0; i < list?.Count; i++)
            {
                var item1 = list[i];

                for (int j = (i + 1); j < list.Count; j++)
                {
                    if (!besucht[j] && item1 != null && item1.Equals(list[j]))
                    {
                        zaehler++;
                        besucht[j] = true;
                        Console.WriteLine(list[i] + " ist an der Index-Stelle " + j + " doppellt.");
                    }
                }
            }
            Console.WriteLine(zaehler + " Doppelte gefunden.");
        }
    }
}
