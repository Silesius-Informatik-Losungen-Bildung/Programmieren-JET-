using SeriaDeserial.Interfaces;
using System.Text.Json.Serialization;

namespace SeriaDeserial.Models
{
    public class Person : IPerson
    {
        [JsonPropertyName("GebDatum")]
        public DateOnly GeburtsDatum { get; set; }
        public byte Gewicht { get; set; }
        public required string Name { get; set; }
        public Haarfarbe Haarfarbe { get; set; }
        public required Adresse Adresse { get; set; }
        public byte? Schuhgroesse { get; set; }
        public bool Lebend { get; set; }
    }
}
