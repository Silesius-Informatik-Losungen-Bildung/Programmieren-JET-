namespace GenerischeKlassen
{
    public class Produkt
    {
        public string Name { get; set; }
        public double Preis { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Preis} €)";
        }
    }
}
