public class BibliotheksKatalog<T> where T : Medium
{
    private List<T> katalog = new List<T>();

    public void Hinzufügen(T medium)
    {
        katalog.Add(medium);
    }

    public void Anzeigen()
    {
        foreach (var medium in katalog)
        {
            medium.Anzeigen();
        }
    }
}