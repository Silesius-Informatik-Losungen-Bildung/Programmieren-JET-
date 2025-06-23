
namespace ObOrPr
{
    public abstract class Fahrzeug
    {
        public Fahrzeug(string markeModell, int bauJahr, bool istZweispurig)
        {
            MarkeModell = markeModell;
            Baujahr = bauJahr;
        }

        // Eigenschaften / Properties
        public string MarkeModell { get; init; }
        public Farbe Farbe { get; set; }
        public double Gewicht { get; set; }
        public double Geschwindigkeit { get; set; }
        public int Baujahr { get; init; }

        public bool IstZweispurig { get; protected set; }

        public void Fahren()
        {
            Console.WriteLine("Fahrzeug fährt");
        }
        ~Fahrzeug()
        {

        }
    }
}
