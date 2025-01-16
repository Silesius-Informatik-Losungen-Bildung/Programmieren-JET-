namespace Serialisierung
{
    [Flags, JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Haarfarbe
    {
        Schwarz,
        Braun,
        Blond,
        Rot,
        Grau
    }
}
