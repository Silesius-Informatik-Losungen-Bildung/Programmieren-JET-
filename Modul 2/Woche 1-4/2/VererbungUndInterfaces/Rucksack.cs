namespace VererbungUndInterfaces
{
    public class Rucksack: IProdukt
    {
        public int VolumenLiter { get; set; }
        public string Material { get; set; }
        public int AnzahlFaecher { get; set; }
        public int ProduktId { get; set; }
        public bool IstWeihnachtsProdukt { get; set; }
        public double Preis { get; set; }
        public DateTime? VerfuegbarAb { get; set; }
        public DateTime? VerfuegbarBis { get; set; }
    }
}
