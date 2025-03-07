using System.Text.Json;

namespace ModultestSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // add Punkt 2.
            Console.WriteLine(Calculator.Calculator.Add(12, 3));


            // add Punkt 3.
            var produkt = new Produkt { Name = "Laptop", Preis = 1200.99m };
            string json = JsonSerializer.Serialize(produkt);
            Console.WriteLine(json);

            produkt = JsonSerializer.Deserialize<Produkt>(json);
            Console.WriteLine(produkt?.Name);


            // add Punkt 4
            try
            {
                Console.WriteLine(Calculator.Calculator.Divide(10, 0));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Fehler: " + ex.Message);
            }

            // Punkt 5.
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(3, 4));


            // Punkt 6.
            var zahlen = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int summe = zahlen.Where(x => x % 2 == 0).Sum();
            Console.WriteLine(summe);
        }

        // Punkt 1.
        public static int GetLength(string? input)
        {
            return input?.Length ?? -1;
        }
    }
}
