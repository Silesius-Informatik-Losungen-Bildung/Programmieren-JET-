namespace ObOrPr
{
    public sealed class Auto : Fahrzeug
    {
        public Auto(string markeModell, int bauJahr) : base(markeModell, bauJahr, true)
        {
            if (bauJahr <= 1885)
                throw new Exception("Ungültiges Baujahr");
        }

        public int Ps { get; set; }
        public int Reifen { get; set; }
        public int Sizplätze { get; set; }
        public decimal Anbotspreis { get; set; }
        public string Antriebsart { get; set; }
    }
}
