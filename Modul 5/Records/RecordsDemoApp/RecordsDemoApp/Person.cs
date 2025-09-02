namespace RecordsDemoApp
{
    public record Person
    {
        public Person(string vorname, string nachame)
        {
            Vorname = vorname;
            Nachname = nachame;
        }
        public string Vorname { get; init; }
        public string Nachname { get; init; }
    }
}
