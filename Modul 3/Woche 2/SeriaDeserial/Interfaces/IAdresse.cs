namespace SeriaDeserial.Interfaces
{
    public interface IAdresse
    {
        public string StrasseUndHausNr { get; set; }
        public string Plz { get; set; }
        public string Ort { get; set; }
        public string? BundesLand { get; set; }
    }
}
