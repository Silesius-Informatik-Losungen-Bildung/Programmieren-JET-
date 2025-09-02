namespace RecordsDemoApp
{
    internal class PersonenClass
    {
        public PersonenClass(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }
        public string Name { get; init; }
        public int Alter { get; init; }
    }
}
