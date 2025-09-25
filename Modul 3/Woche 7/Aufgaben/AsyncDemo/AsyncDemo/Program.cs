using System.Diagnostics;

namespace AsyncDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Asynchrone Datenverarbeitung startet...");

            var stopwatch = Stopwatch.StartNew();
            await LoadAllDataAsync();
            stopwatch.Stop();
            Console.WriteLine($"Alle Daten geladen in {stopwatch.Elapsed.TotalSeconds:F2} Sekunden");
            Console.WriteLine("Drücken Sie eine beliebige Taste zum Beenden...");
            Console.ReadKey();
        }

        static async Task LoadAllDataAsync()
        {
            Task<string> userTask = GetUserDataAsync();
            Task<int> ageTask = GetUserAgeAsync();
            Task<List<string>> productTask = GetProductListAsync();
            Task<double> orderTask = GetOrderTotalAsync();
            Task<string> errorTask = GetDataWithErrorAsync();

            await Task.WhenAll(userTask, ageTask, productTask, orderTask, errorTask);

            string user = userTask.Result;
            int age = ageTask.Result;
            List<string> products = productTask.Result;
            double total = orderTask.Result;
            string error = errorTask.Result;

            try
            {
                string errorResult = await errorTask;
                Console.WriteLine(errorResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler bei Datenabruf: {ex.Message}");
            }

            Console.WriteLine($"Benutzerdaten: {user}");
            Console.WriteLine($"Alter: {age}");
            Console.WriteLine($"Produktliste: {string.Join(", ", products)}");
            Console.WriteLine($"Bestellsumme: {total:F2} €");
        }

        static async Task<string> GetUserDataAsync()
        {
            await Task.Delay(2000);
            return "Max Mustermann";
        }

        static async Task<int> GetUserAgeAsync()
        {
            await Task.Delay(1000);
            return 42;
        }

        static async Task<List<string>> GetProductListAsync()
        {
            await Task.Delay(3000);
            return new List<string> { "ProduktA", "ProduktB", "ProduktC" };
        }

        static async Task<double> GetOrderTotalAsync()
        {
            await Task.Delay(1500);
            return 123.45;
        }

        static async Task<string> GetDataWithErrorAsync()
        {
            await Task.Delay(1000);
            Random rnd = new Random();
            if (rnd.Next(2) == 0)
            {
                throw new InvalidOperationException("Datenquelle nicht erreichbar!");
            }
            return "Fehlerfreie Daten abgerufen";
        }
    }
}
