namespace Buecherverwaltung.Interfaces
{
    public interface IBuch
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Autor { get; set; }
    }
}
