namespace TRS.Logic
{
    public static class Tools
    {
        private static int counter = 0;
        public static int GetNextUniqueInteger
        {
            get
            {
                return Interlocked.Increment(ref counter);
            }
        }
    }
}
