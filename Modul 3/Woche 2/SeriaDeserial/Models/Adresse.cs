using SeriaDeserial.Interfaces;

namespace SeriaDeserial.Models
{
    public class Adresse: IAdresse
    {
        public required string StrasseUndHausNr { get; set; }

        public required string Plz { get; set; }

        public required string Ort { get; set; }

        public string? BundesLand { get; set; }

    }
}
