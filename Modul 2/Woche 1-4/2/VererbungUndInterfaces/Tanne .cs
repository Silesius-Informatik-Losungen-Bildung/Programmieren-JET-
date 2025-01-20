namespace VererbungUndInterfaces
{
    public class Tanne : Baum, IProdukt
    {
        public int AnzahlZapfen { get; set; }
        public bool IstWeihnachtsProdukt { get; set; } = true;
        public double Preis { get; set; }
    }
}
