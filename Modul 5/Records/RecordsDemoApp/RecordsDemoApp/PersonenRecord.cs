namespace RecordsDemoApp
{
    internal record PersonenRecord: MenschRecord
    {
        public PersonenRecord(string name, int alter): base(alter)
        {
            Name = name;
        }
        public string Name { get; init; }
    }
}
