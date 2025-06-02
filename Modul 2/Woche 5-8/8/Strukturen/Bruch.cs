namespace Strukturen
{
    
    /// <summary>
    /// Stellt Bruch-Funktionalität als Readonly-Struktur zur Verfügung
    /// </summary>
    readonly struct Bruch
    {
        /// <summary>
        /// Zähler für den Bruch
        /// </summary>
        public int Zähler { get; }

        /// <summary>
        /// Nenner für den Bruch
        /// </summary>
        public int Nenner { get; }


        /// <summary>
        /// Konstruktor, in dem als 0 übergebener Nenenr mit 1 ersetzt wird, um eine Null-Division-Exception zu verhindern
        /// </summary>
        /// <param name="zähler"></param>
        /// <param name="nenner"></param>
        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner == 0 ? 1 : nenner;
        }

        /// <summary>
        /// Dividiert Zähler durch Nenner
        /// </summary>
        /// <returns>Das Ergebnis einer Division</returns>
        public double AlsDezimalwert() => (double)Zähler / Nenner;
    }
}
