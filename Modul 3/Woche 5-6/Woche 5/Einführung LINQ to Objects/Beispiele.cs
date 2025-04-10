using System.Collections.Generic;

namespace Einführung_Linq_to_Objects
{
    public static class Beispiele
    {

        public static void FilterKlassichMitArray()
        {
            string[] namen = { "Anna", "Roman", "Tobias", "Matthias" };

            var result = Filter(namen, "ias");
            for (var i = 0; i < result.Length; i++)
                Console.WriteLine(result[i]);

            static string[] Filter(string[] arr, string suchWort)
            {
                string[] ret = [];
                for (int i = 0; i < arr.Length; i++)
                    if (arr[i].Contains(suchWort))
                    {
                        Array.Resize(ref ret, ret.Length + 1);
                        ret.SetValue(arr[i], ret.Length - 1);
                    }
                return ret;
            }
        }

        public static void FilterKlassichMitList()
        {
            var namen = new List<string>() { "Anna", "Roman", "Tobias", "Matthias" };
            var result = Filter(namen, "ias");
            foreach (var item in result)
                Console.WriteLine(item);

            static IEnumerable<string> Filter(IEnumerable<string> list, string suchWort)
            {
                var ret = new List<string>();
                foreach (string name in list.AsEnumerable())
                {
                    if (name.Contains(suchWort))
                        ret.Add(name);
                }
                return ret;
            }
        }

        public static void FilterMitListUndLinqWieInSql()
        {
            var namen = new List<string>() { "Anna", "Roman", "Tobias", "Matthias" };
           
            // Definition der Linq-Abfrage
            var result = from name in namen
                         where name.Contains("ias")
                         select name;

            // Erst hier wird die Linq-Abfrage ausgeführt
            foreach (var item in result)
                Console.WriteLine(item);
        }

        public static void FilterMitListUndLinq()
        {
            var namen = new List<string>() { "Anna", "Roman", "Tobias", "Matthias" };
            var result = namen.Where(name => name.Contains("ias"));
            foreach (var item in result)
                Console.WriteLine(item);
        }



        public static void TestIEnumerable()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };

            //IEnumerable<int> enumerableZahlen = [1, 2, 3, 4, 5];

            foreach (int zahl in list.AsEnumerable())
            {
                Console.WriteLine(zahl);
            }
        }

        public static void PrüfungNachGeradenZahlenTraditionlleLösungOhneLinq()
        {
            // Prüfung nach geraden Zahlen (traditionlle Lösung - ohne Linq)
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var geradeZahlen = new List<int>();
            foreach (int zahl in list)
            {
                if (zahl % 2 == 0) // Prüfen, ob die Zahl gerade ist
                {
                    geradeZahlen.Add(zahl); // Gerade Zahl zur Liste hinzufügen
                }
            }

            foreach (int zahl in geradeZahlen)
            {
                Console.WriteLine(zahl);
            }
        }

        public static void LinqToObjectsQuerySyntaxÄhnlichSQL()
        {
            // Linq to Objects 
            // Query-Syntax (ähnlich SQL)
            IEnumerable<int> enumerableZahlen = [1, 2, 3, 4, 5];
            var ergebnis = from zahl in enumerableZahlen
                           where zahl % 2 == 0
                           // orderby zahl descending
                           select zahl;

            foreach (int zahl in ergebnis)
            {
                Console.WriteLine(zahl);
            }
        }

        public static void LinqToObjectsMethodenSyntaxMitLambda()
        {
            // Methoden - Syntax(mit Lambda - Ausdrücken)
            IEnumerable<int> enumerableZahlen = [1, 2, 3, 4, 5];
            var ergebnis = enumerableZahlen.Where(zahl => zahl % 2 == 0).OrderByDescending(zahl => zahl);

            foreach (int zahl in ergebnis)
            {
                Console.WriteLine(zahl);
            }

            // Nicht-anonymer Typ
            var person = new Person();
        }

        public class Person
        {
            public string Name { get; set; }
            public int Alter { get; set; }
        }

        // Anonyme Objekte
        public static void AnonymeObjekteBsp1()
        {
            var person = new { Name = "Anna", Alter = 25 };
            Console.WriteLine($"Name: {person.Name}, Alter: {person.Alter}");
        }

        public static void AnonymeObjekteBsp2()
        {
            var personen = new List<string> { "Anna", "Bernd", "Clemens", "Diana" };
            var ergebnis = from name in personen
                           where name.StartsWith("A")
                           select new { Name = name, Laenge = name.Length };

            foreach (var person in ergebnis)
            {
                Console.WriteLine($"Name: {person.Name}, Länge: {person.Laenge}");
            }
        }


        public static void LinqWhere()
        {
            var zahlen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var geradeZahlen = zahlen.Where(x => x % 2 == 0); // Nur gerade Zahlen

            Console.WriteLine("Where-Ergebnis:");
            foreach (var zahl in geradeZahlen)
                Console.WriteLine(zahl); // Ausgabe: 2, 4, 6, 8, 10
        }

        public static void LinqFirst()
        {

            var namen = new List<string> { "Heinrich", "Anna", "Carla", "Albert" };
            var ersterNameMitA = namen.First(name => name.StartsWith("A"));

            Console.WriteLine($"First-Ergebnis: {ersterNameMitA}"); // Ausgabe: Anna
        }

        public static void LinqFirstOrDefault()
        {
            var leereListe = new List<string>();
            var name = leereListe.FirstOrDefault();

            Console.WriteLine($"FirstOrDefault-Ergebnis: {name}"); // Ausgabe: (leer)
        }

        public static void LinqOrderBy()
        {
            var zahlen = new List<int> { 5, 2, 8, 3, 1 };
            var sortierteZahlen = zahlen.OrderBy(x => x);

            Console.WriteLine("OrderBy-Ergebnis:");
            foreach (var zahl in sortierteZahlen)
                Console.WriteLine(zahl); // Ausgabe: 1, 2, 3, 5, 8
        }

        public static void LinqOrderByThenBy()
        {
            var personen = new List<(string Name, int Alter)>
            {
                ("Anna", 30),
                ("Ben", 20),
                ("Anna", 25),
                ("David", 40)
            };

            var sortiertePersonen = personen
                .OrderBy(p => p.Name)   // Zuerst nach Name sortieren
                .ThenBy(p => p.Alter);  // Dann nach Alter sortieren

            Console.WriteLine("ThenBy-Ergebnis:");
            foreach (var person in sortiertePersonen)
                Console.WriteLine($"{person.Name}, {person.Alter}");

        }

        public static void LinqAny()
        {
            // Any: Prüft, ob mindestens ein Element eine Bedingung erfüllt.
            var zahlen = new List<int> { 1, 3, 5, 7, 9 };
            bool hatGeradeZahl = zahlen.Any(x => x % 2 == 0);

            Console.WriteLine($"Any-Ergebnis: {hatGeradeZahl}"); // Ausgabe: False
        }

        public static void LinqAll()
        {

            // All: Prüft, ob alle Elemente eine Bedingung erfüllen.
            var zahlen = new List<int> { 2, 4, 6, 8, 2 };
            bool sindAlleGerade = zahlen.All(x => x % 2 == 0);

            Console.WriteLine($"All-Ergebnis: {sindAlleGerade}"); // Ausgabe: True
        }

        public static void LinqSum()
        {
            var zahlen = new List<int> { 1, 2, 3, 4, 5 };
            int summe = zahlen.Sum();

            Console.WriteLine($"Sum-Ergebnis: {summe}"); // Ausgabe: 15
        }

        public static void LinqAverage()
        {

            // Average: Gibt den Durchschnittswert der Elemente in der Sammlung zurück.
            var zahlen = new List<int> { 1, 2, 3, 4, 5 };
            double durchschnitt = zahlen.Average();

            Console.WriteLine($"Average-Ergebnis: {durchschnitt}"); // Ausgabe: 3.0
        }

        public static void LinqMin()
        {
            var zahlen = new List<int> { 3, 7, 2, 8, 1 };
            int minZahl = zahlen.Min();

            Console.WriteLine($"Min-Ergebnis: {minZahl}"); // Ausgabe: 1
        }
        public static void LinqMax()
        {
            var zahlen = new List<int> { 3, 7, 2, 8, 1 };
            int maxZahl = zahlen.Max();

            Console.WriteLine($"Max-Ergebnis: {maxZahl}"); // Ausgabe: 8
        }

        public static void Misc()
        {
            {
                var namen = new List<string>() { "Anna", "Roman", "Tobias", "Matthias" };

                //var erster = namen.First();

                var erster = namen.FirstOrDefault();
                Console.WriteLine(erster);


                var sortiert = namen.Order();
                foreach (var item in sortiert)
                {
                    Console.WriteLine(item);
                }

                namen.Reverse();
                foreach (var item in namen)
                {
                    Console.WriteLine(item);
                }

                var any = namen.Any(name => name == "Lukas" || name == "Anna");
                Console.WriteLine(any);

                var personen = new List<Person> { new() { Alter = 45, Name = "Name1" }, new() { Age = 34, Name = "Name2" }, new() { Age = 34, Name = "Alex" } };

                var jüngste = personen.Min(person => person.Alter);
                Console.WriteLine(jüngste);

                var durchnittalter = personen.Average(person => person.Alter);
                Console.WriteLine(durchnittalter);

                var summeAlter = personen.Sum(person => person.Alter);
                Console.WriteLine(summeAlter);

                var nameNameOrderByAge = personen
                    .Where(person => person.Name.Contains("Name"))
                    .OrderBy(personen => personen.Alter)
                    .LastOrDefault();

                Console.WriteLine(nameNameOrderByAge?.Name);
            }

        }
    }
}
