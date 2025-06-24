namespace ObOrPr
{
    public sealed class Auto : Fahrzeug
    {
        private int _ps;

        public Auto(string markeModell, int bauJahr) : base(markeModell, bauJahr, true)
        {
            if (bauJahr <= 1885)
                throw new Exception("Ungültiges Baujahr");

            _ps = 100;
        }

        public int Ps
        {
            get { return _ps; }
            private set { _ps = value; }
        }

        public int Reifen { get; set; }
        public int Sizplätze { get; set; }
        public decimal Anbotspreis { get; set; }
        public string Antriebsart { get; set; }

        public void Huppen()
        {
            Console.Beep(600, 1000);
            Console.Beep(600, 1000);
        }


    }
}
