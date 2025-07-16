using System.Text.Json.Serialization;

namespace SerialDeserial
{
    public class Person
    {
        public DateOnly GeburtsDatum { get; set; }
        public byte Gewicht { get; set; }
        public string Name { get; set; } = null!;

        [JsonPropertyName("Haarfarbe")]
        public Haarfarbe Haarfarbe { get; set; }
        
        [JsonPropertyName("WohnAdresse")]
        public Adresse Adresse { get; set; } = null!;
        public byte? Schuhgroesse { get; set; }
    }
}
