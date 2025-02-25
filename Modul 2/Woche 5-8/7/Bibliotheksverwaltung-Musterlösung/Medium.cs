public abstract class Medium
{
    public string Titel { get; private set; }
    public string Autor { get; private set; }
    public string ISBN { get; private set; }

    public Medium(string titel, string autor)
    {
        Titel = titel;
        Autor = autor;
        ISBN = Utility.GenerateBarcode();
    }

    public abstract void Anzeigen();
}