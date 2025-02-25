namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BibliotheksKatalog<Buch> katalog = new BibliotheksKatalog<Buch>();
            Buch buch1 = new Buch("C# lernen", "Max Mustermann");
            katalog.Hinzufügen(buch1);
            katalog.Anzeigen();
            buch1.Ausleihen();
            buch1.Zurückgeben();
        }
    }
}
