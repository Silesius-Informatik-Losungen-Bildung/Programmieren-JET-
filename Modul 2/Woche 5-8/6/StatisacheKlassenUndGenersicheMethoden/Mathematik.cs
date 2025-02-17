namespace StatisacheKlassenUndGenersicheMethoden
{
    public class Mathematik
    {
        // Instanzvariable
        private double _zahl1;
        private double _zahl2;

        // Öffentlicher Konstruktor
        public Mathematik(double zahl1, double zahl2)
        {
            _zahl1 = zahl1;
            _zahl2 = zahl2;
        }

        // Eine nicht-statische Methode, die eine Instanz benötigt
        public double Addiere()
        {
            return _zahl1 + _zahl2;
        }

        // Eine nicht-statische Methode, die eine Instanz benötigt
        public double Subtrahiere()
        {
            return _zahl1 + _zahl2;
        }

        // Eine statische Methode, die ohne Instanz aufgerufen werden kann
        public static double Addiere(double zahl1, double zahl2)
        {
            return zahl1 + zahl2;
        }

        // Eine statische Methode, die ohne Instanz aufgerufen werden kann
        public static double Subtrahiere(double zahl1, double zahl2)
        {
            return zahl1 - zahl2;
        }

    }
}
