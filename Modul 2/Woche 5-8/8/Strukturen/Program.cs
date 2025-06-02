namespace Strukturen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var punkt3D = new Punkt3D(23, 5, 87);
            Console.WriteLine(punkt3D.ToString());

            var bruch = new Bruch(10, 2);
            Console.WriteLine(bruch.AlsDezimalwert());

            // struct-Beispiel aus .NET-Framework
            DateTime jetzt = DateTime.Now;
            
            jetzt.AddDays(5); // wirkt sich nicht auf jetzt aus..
            Console.WriteLine(jetzt); // weil DateTime eine readonly-Struktur ist

            DateTime zukunft = jetzt.AddDays(5); // Zuweisung des neuen Wertes
                                                 // an eine separate Variable
                                     // da "jetzt" immutable (unveänderlich) ist

            Console.WriteLine(jetzt);   // Aktuelles Datum
            Console.WriteLine(zukunft); // In 5 Tagen


            // struct by ref
            Span<int> stackSpeicher = stackalloc int[5]; // Speicher direkt im Stack
            var stack = new StackBuffer(stackSpeicher);

            stack.Push(10);
            stack.Push(20);
            Console.WriteLine(stack.Pop());

        }

        static void Experiment()
        {
            var baum = new Baum();
            baum.AnzahlBlätter = 10000;
            baum.Name = "Buche";
            baum.Höhe = 25;

            ÄndereName(baum);

            Console.WriteLine("baum.Name nach Änderung: " + baum.Name);


            var fahrzeug = new Fahrzeug();
            fahrzeug.MarkeModel = "Opel Corsa";
            fahrzeug.AnzahlTüre = 5;
            fahrzeug.PS = 75;

            ÄndereName(fahrzeug);

            Console.WriteLine("fahrzeug.MarkeModel nach Änderung: " + fahrzeug.MarkeModel);
        }

        static void ÄndereName(Baum baum)
        {
            baum.Name = "Ahorn";
        }

        static void ÄndereName(Fahrzeug fahrzeug)
        {
            fahrzeug.MarkeModel = "Suzuki Swift";
        }
    }
}