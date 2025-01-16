namespace Serialisierung
{
    public class Person
    {
        [JsonPropertyName("GebDatum")]
        public DateOnly GeburtsDatum { get; set; }

        [JsonIgnore]
        public byte Gewicht { get; set; }

        [JsonPropertyOrder(-5)]
        public required string Name { get; set; }

        public Haarfarbe Haarfarbe { get; set; }

        [JsonPropertyName("Wohnadresse")]
        public required Adresse Adresse { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public byte? Schuhgroesse { get; set; }
    }
}
