namespace VererbungUndInterfaces
{
    internal class Rucksack: IProdukt
    {
        public byte VolumeInLiter { get; set; }
        public byte AnzahlFaecher { get; set; }
        public decimal Preis { get; set; }
        public bool IstWeihnachtsprodukt { get; set; }
        public bool IstLagernd { get; set; }
    }
}
