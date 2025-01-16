using SeriaDeserial.Models;
using System.Text.Json.Serialization;

namespace SeriaDeserial.Interfaces
{
    public interface IPerson
    {
        [JsonPropertyName("GebDatum")]
        public DateOnly GeburtsDatum { get; set; }

        [JsonIgnore]
        public byte Gewicht { get; set; }

        [JsonPropertyOrder(-5)]
        public string Name { get; set; }
        
        public Haarfarbe Haarfarbe { get; set; }

        //[JsonPropertyName("Wohnadresse")]
        public Adresse Adresse { get; set; }
        
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte? Schuhgroesse { get; set; }
        
        public bool Lebend { get; set; }
    }
}