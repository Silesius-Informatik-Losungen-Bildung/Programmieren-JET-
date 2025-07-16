using System.Text.Json;
using System.Text.Json.Serialization;

namespace SerialDeserial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Methode1();
            Methode2();
        }

        private static void Methode2()
        {
            const string filename = "jsonString1.txt";

            var person1 = new Person
            {
                Name = "Max Mustermann",
                GeburtsDatum = new DateOnly(1985, 1, 1),
                Gewicht = 80,
                Haarfarbe = Haarfarbe.Grau,
                Schuhgroesse = null,
                Adresse = new Adresse
                {
                    Ort = "Wien",
                    Plz = "1140",
                    StrasseUndHausNr = "Fenzlgasse 1",
                    BundesLand = null
                }
            };

            var jsonSerializerOptions1 = new JsonSerializerOptions
            {
                WriteIndented = true,
                // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // Serialisierung = Umwandlung von Object zu lesbaren Text (z.B. JSON)
            string jsonString1 = JsonSerializer.Serialize(person1, jsonSerializerOptions1);
            File.WriteAllText(filename, jsonString1);

            var jsonSerializerOptions2 = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            };


            // Deserialisierung = Umwandlung von lesbaren Text (z.B. JSON) zu Object 
            var jsonString2 = File.ReadAllText(filename);
            Person? person2 = JsonSerializer.Deserialize<Person>(jsonString2, jsonSerializerOptions2);

            if (person2 == null)
                return;

            Console.WriteLine(person2.Name);
            Console.WriteLine(person2.Haarfarbe);
            Console.WriteLine(person2.Gewicht);
            Console.WriteLine(person2.GeburtsDatum);
            Console.WriteLine(person2.Schuhgroesse);
            Console.WriteLine(person2.Adresse.Plz);
            Console.WriteLine(person2.Adresse.Ort);
            Console.WriteLine(person2.Adresse.StrasseUndHausNr);
            Console.WriteLine(person2.Adresse.BundesLand);
        }

        private static void Methode1()
        {
            var person1 = new Person
            {
                Name = "Max Mustermann",
                GeburtsDatum = new DateOnly(1985, 1, 1),
                Gewicht = 80,
                Haarfarbe = Haarfarbe.Grau,
                Schuhgroesse = null,
                Adresse = new Adresse
                {
                    Ort = "Wien",
                    Plz = "1140",
                    StrasseUndHausNr = "Fenzlgasse 1",
                    BundesLand = null
                }
            };

            var jsonSerializerOptions1 = new JsonSerializerOptions
            {
                WriteIndented = true,
                // DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            // Serialisierung = Umwandlung von Object zu lesbaren Text (z.B. JSON)
            string jsonString1 = JsonSerializer.Serialize(person1, jsonSerializerOptions1);
            Console.WriteLine(jsonString1);

            // Deserialisierung = Umwandlung von lesbaren Text (z.B. JSON) zu Object 

            string jsonString2 = @"{
                  ""GeburtsDatum"": ""1985-01-01"",
                  ""Gewicht"": 80,
                  ""Name"": ""Max Mustermann"",
                  ""Haarfarbe"": ""Rot"",
                  ""WohnAdresse"": {
                    ""StrasseUndHausNr"": ""Fenzlgasse 1"",
                    ""Plz"": ""1140"",
                    ""Ort"": ""Wien"",
                    ""BundesLand"": null
                  },
                  ""Schuhgroesse"": null
                }";

            var jsonSerializerOptions2 = new JsonSerializerOptions
            {
                //PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
            };


            Person? person2 = JsonSerializer.Deserialize<Person>(jsonString2, jsonSerializerOptions2);

            if (person2 == null)
                return;

            Console.WriteLine(person2.Name);
            Console.WriteLine(person2.Haarfarbe);
            Console.WriteLine(person2.Gewicht);
            Console.WriteLine(person2.GeburtsDatum);
            Console.WriteLine(person2.Schuhgroesse);
            Console.WriteLine(person2.Adresse.Plz);
            Console.WriteLine(person2.Adresse.Ort);
            Console.WriteLine(person2.Adresse.StrasseUndHausNr);
            Console.WriteLine(person2.Adresse.BundesLand);
        }
    }
}
