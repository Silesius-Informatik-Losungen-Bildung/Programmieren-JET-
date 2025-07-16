namespace SerialDeserial
{
    public class Adresse
    {
        public string StrasseUndHausNr { get; set; } = null!;
        public string Plz { get; set; } = null!;
        public string Ort { get; set; } = null!;
        public string? BundesLand { get; set; }
    }
}
