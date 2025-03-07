
using System.Text.Json.Serialization;

namespace Tools
{
    public class Woerterbuch
    {
        [JsonPropertyName("Wörterbuch")]
        public IEnumerable<WortEintrag>? Eintraege { get; set; }

        public class WortEintrag
        {
            public required string Englisch { get; set; }

            public required string Deutsch { get; set; }
        }
    }
}
