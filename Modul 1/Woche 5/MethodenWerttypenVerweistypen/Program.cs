namespace MethodenWerttypenVerweistypen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var person = new Person() { Name = "Müller" };
            Console.WriteLine(person.Name);
            Methode1(person);
            Console.WriteLine(person.Name);


            var person2 = new Person() { Name = "Müller" };
            Console.WriteLine(person2.Name);
            var p = Mertode2(person2);
            Console.WriteLine(p.Name);


            var p3 = new Person();
            person = person2;
            p3 = person2;

            person2.Name = "ddd";

            person.Name = "YYYY";

            p3.Name = "ZZZ";





            int zahl = 1;
            Console.WriteLine(zahl);
            Methode3(zahl);
            Console.WriteLine(zahl);

            int a = 1;
            int b = 2;
            b = a;
            b = 3;


            Person p1 = new Person() { Name = "Alex" };
            Person p2 = new Person() { Name = "Max" };
            p2 = p1;
            p2.Name = "Alois";

            //int zahl = 45;

            //Beispiele.Verdopple(zahl: zahl, out int ergebnis);
            ////Console.WriteLine(ergebnis);

            //var str = Beispiele.GetName(nachname: "Müller", vorname: "Franz");

            //Beispiele.Addiere(wort: "", zahl: 0);

            //var str3 = Beispiele.MacheKommaseparierteZeichenkette("Fluss", "Meer", "Fische");


            // Beispiele.Fakultät(10);
        }



        public static void Methode3(int z)
        {
            z = z + 1;
        }


        public static void ChangeZahl(ref int z)
        {
            z = z + 1;
        }


        public static void Methode1(Person p)
        {
            const string name = "Nowack";
            p.Name = name;
        }

        public static Person Mertode2(Person person)
        {
            const string name = "Nowack";
            var p = new Person() { Name = name };
            return p;
        }


        public class Person()
        {
            public string Name { get; set; }
        }
    }
}
