using Logik;
using Newtonsoft.Json;
namespace App
{
    class Program
    {
        delegate double Rechenoperation(double a, double b);

        static async Task Main(string[] args)
        {
            // Aufgabe 1
            var zahlen = new List<int> { 4, 8, 15, 16 };
            Console.WriteLine("Durchschnitt: " + MatheTools.BerechneDurchschnitt(zahlen));
            Console.WriteLine("Max: " + MatheTools.MaxWert(zahlen));

            // Aufgabe 2
            var produkte = new List<Produkt>
            {
                new Produkt { Id = 1, Name = "Tasse", Preis = 5.99 },
                new Produkt { Id = 2, Name = "Buch", Preis = 12.49 },
                new Produkt { Id = 3, Name = "Lampe", Preis = 24.99 }
            };

            string pfad = "produkte.json";
            try
            {
                string json = JsonConvert.SerializeObject(produkte); ;
                File.WriteAllText(pfad, json);
            }
            catch (Exception ex)
            {
                File.AppendAllText("fehler.log", ex.Message + "\n");
            }

            // Aufgabe 3
            Rechenoperation addition =  (double a, double b) => a + b;
            Rechenoperation multiplikation = (a, b) => a * b;
            Func<double, double, double> division = (a, b) => b != 0 ? a / b : 0;


            Console.WriteLine("Ergebnis: " + addition(10, 5));
            Console.WriteLine("Ergebnis: " + multiplikation(10, 5));
            Console.WriteLine("Division mit Func: " + division(10, 5));


            // Aufgabe 4
            var teureProdukte = produkte.Where(p => p.Preis > 10).OrderByDescending(p => p.Preis);
            foreach (var p in teureProdukte)
                Console.WriteLine($"{p.Name}: {p.Preis}");

            Console.WriteLine("Ø Preis: " + produkte.Average(p => p.Preis));

            var produktePreisDesc = produkte.OrderByDescending(p => p.Preis);
            foreach (var p in produktePreisDesc)
                Console.WriteLine($"{p.Name}: {p.Preis}");

            // Aufgabe 5
            var geladeneProdukte = LadeProdukte(pfad);
            await ZeigeProdukteMitVerzoegerungAsync(geladeneProdukte);
        }

        static List<Produkt> LadeProdukte(string pfad)
        {
            try
            {
                var json = File.ReadAllText(pfad);
                return JsonConvert.DeserializeObject<List<Produkt>>(json) ?? new List<Produkt>();
            }
            catch (Exception ex)
            {
                File.AppendAllText("fehler.log", ex.Message + "\n");
                return new List<Produkt>();
            }
        }

        static async Task ZeigeProdukteMitVerzoegerungAsync(List<Produkt> produkte)
        {
            foreach (var p in produkte)
            {
                Console.WriteLine($"{p.Id}: {p.Name} - {p.Preis} €");
                await Task.Delay(1000);
            }
        }
    }
}
