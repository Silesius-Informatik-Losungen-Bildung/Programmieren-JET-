using System.Text.Json;
using System.Text.Json.Serialization;

namespace WetterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Bitte geben Sie eine Stadt ein: ");
            string stadt = Console.ReadLine();

            string apiKey = "344811d19e757efd1d8862693642f8dd";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={stadt}&appid={apiKey}&units=metric&lang=de";

            using HttpClient client = new();

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                var wetter = JsonSerializer.Deserialize<WeatherResponse>(json);

                Console.WriteLine($"\nAktuelles Wetter in {wetter.Name}:");
                Console.WriteLine($"  Beschreibung: {wetter.Weather[0].Description}");
                Console.WriteLine($"  Temperatur:   {wetter.Main.Temp} °C");
                Console.WriteLine($"  Luftfeuchte:  {wetter.Main.Humidity} %");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
            }
        }


        public class WeatherResponse
        {
            [JsonPropertyName("coord")]
            public Coord Coord { get; set; }

            [JsonPropertyName("weather")]
            public List<Weather> Weather { get; set; }

            [JsonPropertyName("base")]
            public string Base { get; set; }

            [JsonPropertyName("main")]
            public Common Main { get; set; }

            [JsonPropertyName("visibility")]
            public int Visibility { get; set; }

            [JsonPropertyName("wind")]
            public Wind Wind { get; set; }

            [JsonPropertyName("clouds")]
            public Clouds Clouds { get; set; }

            [JsonPropertyName("dt")]
            public long Dt { get; set; }

            [JsonPropertyName("sys")]
            public Sys Sys { get; set; }

            [JsonPropertyName("timezone")]
            public int Timezone { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("cod")]
            public int Cod { get; set; }
        }

        public class Coord
        {
            [JsonPropertyName("lon")]
            public double Lon { get; set; }

            [JsonPropertyName("lat")]
            public double Lat { get; set; }
        }

        public class Weather
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("main")]
            public string Main { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }

            [JsonPropertyName("icon")]
            public string Icon { get; set; }
        }

        public class Common
        {
            [JsonPropertyName("temp")]
            public double Temp { get; set; }

            [JsonPropertyName("feels_like")]
            public double FeelsLike { get; set; }

            [JsonPropertyName("temp_min")]
            public double TempMin { get; set; }

            [JsonPropertyName("temp_max")]
            public double TempMax { get; set; }

            [JsonPropertyName("pressure")]
            public int Pressure { get; set; }

            [JsonPropertyName("humidity")]
            public int Humidity { get; set; }

            [JsonPropertyName("sea_level")]
            public int SeaLevel { get; set; }

            [JsonPropertyName("grnd_level")]
            public int GroundLevel { get; set; }
        }

        public class Wind
        {
            [JsonPropertyName("speed")]
            public double Speed { get; set; }

            [JsonPropertyName("deg")]
            public int Deg { get; set; }

            [JsonPropertyName("gust")]
            public double Gust { get; set; }
        }

        public class Clouds
        {
            [JsonPropertyName("all")]
            public int All { get; set; }
        }

        public class Sys
        {
            [JsonPropertyName("type")]
            public int Type { get; set; }

            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("country")]
            public string Country { get; set; }

            [JsonPropertyName("sunrise")]
            public long Sunrise { get; set; }

            [JsonPropertyName("sunset")]
            public long Sunset { get; set; }
        }

    }
}
