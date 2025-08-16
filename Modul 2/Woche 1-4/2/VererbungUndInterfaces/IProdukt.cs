namespace VererbungUndInterfaces
{
    public interface IProdukt
    {
        public int ProduktId { get; set; }
        bool IstWeihnachtsProdukt { get; set; }
        double Preis { get; set; }
        public DateTime? VerfuegbarAb { get; set; }
        public DateTime? VerfuegbarBis { get; set; }
    }
}
