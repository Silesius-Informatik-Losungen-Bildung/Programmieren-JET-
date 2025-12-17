namespace DiDemo.Models.Interfaces
{
    // ---------------------------------------------------------
    // Ein Interface beschreibt einen Vertrag:
    // Es legt fest, welche Methoden ein Dienst bereitstellt.
    // ---------------------------------------------------------
    public interface IHalloDienst
    {
        // Diese Methode liefert einen Begrüßungstext zurück.
        string ErzeugeBegruessung(string name);
    }
}
