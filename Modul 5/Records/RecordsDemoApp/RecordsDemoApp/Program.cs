
namespace RecordsDemoApp
{
    public record Fahrzeug(string Marke, string Modell);
    public record Auto(string Marke, string Modell, int Baujahr) : Fahrzeug(Marke, Modell);
    class Program
    {
        static void Main(string[] args)
        {
            // Erstellen von Records
            var p1 = new Person("Max", "Müller");
            var p2 = new Person("Max", "Müller");
            var p3 = new Person("Anna", "Schmidt");

            Console.WriteLine("=== ToString() Ausgabe ===");
            Console.WriteLine(p1); // Automatische Ausgabe: Person { Vorname = Max, Nachname = Müller }

            Console.WriteLine("\n=== Equals / == Vergleich ===");
            Console.WriteLine($"p1 == p2 ? {p1 == p2}"); // True, da Records Werte vergleichen
            Console.WriteLine($"p1 == p3 ? {p1 == p3}"); // False

            Console.WriteLine("\n=== Mit with-Expression kopieren ===");
            var p4 = p1 with { Nachname = "Schneider" };
            Console.WriteLine(p4); // Person { Vorname = Max, Nachname = Schneider }

            Console.WriteLine("\n=== Unveränderlichkeit ===");
            //p1.Vorname = "Peter"; // Geht nicht! Records sind immutable, da init-only Properties
            Console.WriteLine("p1 bleibt unverändert: " + p1);

            
            // Bsp von Unterricht:
            var personc1 = new PersonenClass("Max", 33);
            var personc2 = new PersonenClass("Max", 33);

            var istGleich = personc1 == personc2;


            var personr1 = new PersonenRecord("Max", 33);
            var personr2 = new PersonenRecord("Max", 33);
            var personr3 = new PersonenRecord("Adam", 33);

            istGleich = personr1 == personr2; // true
            Console.WriteLine(istGleich);
            istGleich = personr1 == personr3; // false

            var recordList = new List<PersonenRecord> { personr1, personr2 };
            var classList = new List<PersonenClass> { personc1, personc2 };


            // Auskommentieren:

            //for (var i = 0; i < recordList.Count; i++)
            //{
            //    if (i > 0)
            //    {
            //        if (recordList[i] == recordList[i - 1])
            //            throw new Exception("hab gleiches gefunden");
            //    }
            //}

            for (var i = 0; i < classList.Count; i++)
            {
                if (i > 0)
                {
                    if (classList[i] == classList[i - 1])
                        throw new Exception("hab gleiches gefunden");
                }
            }

            var personX = personr1 with { Name = "Adam" };



            Fahrzeug fzg = new Auto("VW", "Golf", 2022);

            string info;

            switch (fzg)
            {
                case Auto(var marke, var modell, var baujahr):
                    info = $"{marke} {modell} ({baujahr})";
                    break;

                case Fahrzeug(var marke, var modell):
                    info = $"{marke} {modell}";
                    break;

                default:
                    info = "Unbekannt";
                    break;
            }
            Console.WriteLine(info); // VW Golf (2022)
        }
    }
}
