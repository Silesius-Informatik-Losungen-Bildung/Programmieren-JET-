public sealed class Buch : Medium, IAusleihbar
{
    public Buch(string titel, string autor) : base(titel, autor) { }

    public override void Anzeigen()
    {
        Console.WriteLine($"Buch: \"{Titel}\" von {Autor} (ISBN: {ISBN})");
    }

    public void Ausleihen()
    {
        Console.WriteLine($"Das Buch \"{Titel}\" wurde ausgeliehen.");
    }

    public void Zurückgeben()
    {
        Console.WriteLine($"Das Buch \"{Titel}\" wurde zurückgegeben.");
    }
}