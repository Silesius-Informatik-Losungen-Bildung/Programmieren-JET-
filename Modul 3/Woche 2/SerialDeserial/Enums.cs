
using System.Text.Json.Serialization;

namespace SerialDeserial
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
