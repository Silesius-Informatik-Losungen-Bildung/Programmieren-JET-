namespace RecordsDemoApp
{
    internal record PersonRecord: MenschRecord
    {
        public PersonRecord(string name, int alter): base(alter)
        {
            Name = name;
        }
        public string Name { get; init; }
    }
}
