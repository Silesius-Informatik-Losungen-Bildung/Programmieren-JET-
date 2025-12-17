using DiDemo.Models.Interfaces;

namespace DiDemo.Models
{
    // -------------------------------------------------------------
    // Konkrete Implementierung des Interfaces IHalloDienst.
    // Diese Klasse wird vom DI-Container automatisch erzeugt,
    // wenn ein Controller IHalloDienst anfordert.
    // -------------------------------------------------------------
    public class HalloDienst : IHalloDienst
    {
        public string ErzeugeBegruessung(string name)
        {
            // Beispielrückgabe — könnte später durch Logik ersetzt werden
            return $"Hallo {name}, dieser Text stammt aus dem per Dependency Injection bereitgestellten HalloDienst!";
        }
    }
}
