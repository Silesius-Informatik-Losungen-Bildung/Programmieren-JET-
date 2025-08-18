namespace VererbungUndInterfaces
{
    internal class Tanne : Baum, IProdukt
    {
        public uint AnzahlZapfen { get; set; }
        public decimal Preis { get; set; }
        public bool IstWeihnachtsprodukt { get; set; }
        public bool IstLagernd { get; set; }
    }
}
