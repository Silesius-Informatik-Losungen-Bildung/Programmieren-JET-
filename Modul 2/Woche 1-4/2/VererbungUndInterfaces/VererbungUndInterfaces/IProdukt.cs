
namespace VererbungUndInterfaces
{
    internal interface IProdukt
    {
        public decimal Preis { get; set; }
        public bool IstWeihnachtsprodukt { get; set; }
        public bool IstLagernd { get; set; }
    }
}
