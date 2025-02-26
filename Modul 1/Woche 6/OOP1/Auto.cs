namespace Test
{
    public class Auto
    {
        private string _markeModell;
        private int _kmStand;
        private string _fahrgestellnummer;

        public Auto(string markeModell)
        {
            _markeModell = markeModell;
        }

        public Auto(int dd)
        {
            _kmStand = dd;
        }


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
            // LOgik, Auto in Begung zu setze
            Console.WriteLine("Auto fährt");
        }

        // Methode (Verhalten)
        public void Huppen()
        {

        }

        // Methode (Verhalten)
        public void Bremsen()
        {

        }

        // Destruktor für den Notfall
        ~Auto()
        {
            
        }
    }
}
