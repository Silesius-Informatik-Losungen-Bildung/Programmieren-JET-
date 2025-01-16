using Buecherverwaltung.Interfaces;

namespace Buecherverwaltung.Models
{
    public class Buch: IBuch
    {
        public int Id { get; set; }
        public string Titel { get; set; } = null!;
        public string Autor { get; set; } = null!;
    }
}
