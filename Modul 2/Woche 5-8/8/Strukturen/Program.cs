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

            // struct-Beispeil aus .NET-Framework
            DateTime jetzt = DateTime.Now;
            DateTime zukunft = jetzt.AddDays(5); // Zuweisung des neunen Wertes
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
    }
}