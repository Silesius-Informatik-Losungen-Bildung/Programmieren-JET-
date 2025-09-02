namespace RecordsDemoApp
{
    internal record MenschRecord
    {
        public MenschRecord(int alter)
        {
            Alter = alter;
        }
        public int Alter { get; init; }
    }
}
