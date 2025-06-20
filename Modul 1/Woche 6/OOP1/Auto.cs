namespace Test
{
    public class Auto
    {
        private string _markeModell;
        private int _kmStand;
        private string _fahrgestellnummer;

        public Auto(string markeModell, int kmStand, string fahrgestellnummer)
        {
            _markeModell = markeModell;
            _kmStand = kmStand;
            _fahrgestellnummer = fahrgestellnummer;
        }

        //public Auto(int kmStand)
        //{
        //    _kmStand = kmStand;
        //}


        // Leerer Konstruktor

        //public Auto()
        //{

        //}


        // Property mit Zugriff auf privates Field
        public Auto(string markeModell, int kmStand)
        {
            _markeModell = markeModell;
            _kmStand = kmStand;
            Id = Guid.NewGuid().ToString();
        }

        // Property mit init(Einmalige Initialisierung)
        public string Id { get; init; }

        
        // Kurzschreibweise für Getter
        public string Fahrgestellnummer => _fahrgestellnummer;

        
        // Property mit Standard-Wert
        public byte TuereAnzahl { get; set; } = 5;

        // Property mit Setter und Getter
        public string MarkeModell
        {
            get { return _markeModell; }
            set { _markeModell = value; }
        }

        // Auto-Implemented Property
        public string Farbe { get; set; }

        // Public Variable
        public int BauJahr;

        // Public Variable
        public int KmStand;
       
        // Nur-Getter (berechneter Getter)
        public bool IsGebrauchtWagen
        {
            get {
                return (_kmStand > 10);
            }
        }

        // Nur-Setter
        public bool IsMeinAuto
        {
            set
            {
                IsMeinAuto = value;
            }
        }

        // Methode (Verhalten)
        public void Fahren()
        {
            // Logik, um Auto in Bewegung zu setzen...
            Console.WriteLine("Auto fährt");
        }

        // Methode (Verhalten)
        public void Huppen()
        {
            Console.Beep(600, 1000);
            Console.Beep(600, 1000);
        }

        // Methode (Verhalten)
        public void Bremsen()
        {
            // Logik, um Auto zu bremsen...
        }

        // Destruktor für Extra-Bedarf (z.B. Ressourcen-Bereiniugung
        ~Auto()
        {
            
        }
    }
}
