namespace MethodenWerttypenVerweistypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var person = new Person() { Name = "Müller" };
            //ChangePersonNameToHuber(person);
            //Console.WriteLine(person.Name);

            //ChangePersonNameToHuber(person);
            //Console.WriteLine(person.Name);


            //int zahl = 1;
            //ChangeZahl(ref zahl);
            //Console.WriteLine(zahl);

            //int zahl = 45;

            //Beispiele.Verdopple(zahl: zahl, out int ergebnis);
            ////Console.WriteLine(ergebnis);

            //var str = Beispiele.GetName(nachname: "Müller", vorname: "Franz");

            //Beispiele.Addiere(wort: "", zahl: 0);

            //var str3 = Beispiele.MacheKommaseparierteZeichenkette("Fluss", "Meer", "Fische");


            Beispiele.Fakultät(10);
        }


        public static void ChangeZahl(ref int z)
        {
            z = z + 1;
        }


        public static void ChangePersonNameToHuber2(Person p)
        {
            const string name = "Huber";
            p.Name = name;
        }

        public static Person ChangePersonNameToHuber(Person person)
        {
            const string name = "Huber";
            person.Name = name;
            return person;
        }



        public class Person()
        {
            public string Name { get; set; }
        }
    }
}
