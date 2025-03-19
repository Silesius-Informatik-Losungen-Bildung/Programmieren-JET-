namespace Wichtigste_Collections_List_Dictionary_und_foreach
{
    internal class Beispiele
    {
        public static void List()
        {

            // List von Datentyp String instanzieren und Elemente hinzufügen
            List<string> namen = new List<string>();
            namen.Add("Anna");
            namen.Add("Ben");
            namen.Add("Chris");

            Console.WriteLine("Anzahl der Namen: " + namen.Count);

            // Überprüfung nach bestimmtem Element
            if (namen.Contains("Ben"))
            {
                Console.WriteLine("Ben ist in der Liste enthalten.");
            }

            // Entfernen von betseimmtem Element 
            namen.Remove("Chris");
            Console.WriteLine("Nach dem Entfernen von Chris: " + namen.Count);

            // Entfernen von Element an einer bestimmten Stelle
            namen.RemoveAt(0);
            Console.WriteLine("0te Stelle wurde gelöscht. Jetzt hat die Liste " + namen.Count + " Elemente.");

            // Hinzufügen von Element am Listende
            namen.AddRange(namen);
            Console.WriteLine("Nach Verdoppelung haben wir: " + namen.Count + " Elemente.");

            for (int i = 0; i <= 100; i++)
            {
                namen.Add(Guid.NewGuid().ToString());
            }

            Console.WriteLine("100 neue Elemente hinzugefügt. Jetzt haben wir: " + namen.Count + " Elemente.");

            // Ausfsteigendes Sortieren der Liste
            namen.Sort();
            Console.WriteLine("Nach Sortierung");
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(namen[i]);

            }

            // Umkehr der aktullen Sortierung
            namen.Reverse();
            Console.WriteLine("Nach Umkehr der Sortierung");
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine(namen[i]);

            }

            // Löschen von allen Elementen
            namen.Clear();
            Console.WriteLine("Nach Clear(): Anzahl Elemente: " + namen.Count);
        }

        public static void Dictionary()
        {
            // Instanzieren und befüllen mit Schlüssel-Werte-Paaren
            Dictionary<int, string> studenten = new Dictionary<int, string>();
            studenten.Add(101, "Anna");
            studenten.Add(102, "Ben");

            Console.WriteLine("Student mit ID 101: " + studenten[101]);

            // Ob ein Elemenet mit gegebenem Schlüssel existiert
            if (studenten.ContainsKey(103))
                Console.WriteLine("Student mit ID 103 existiert.");
            else
                Console.WriteLine("Student mit ID 103 existiert nicht.");

            // Entfernen eines Elements nach Key
            studenten.Remove(101);

        }

        public static void Foreach()
        {
            List<string> namen = new List<string>();
            namen.Add("Anna");
            namen.Add("Ben");
            namen.Add("Chris");

            foreach (var name in namen)
            {
                Console.WriteLine(name);
            }

            Dictionary<int, string> studenten = new Dictionary<int, string>();
            studenten.Add(101, "Anna");
            studenten.Add(102, "Ben");

            foreach (KeyValuePair<int, string> eintrag in studenten)
            {
                Console.WriteLine("ID: " + eintrag.Key + " , Name: " + eintrag.Value);
            }
        }



    }

}


