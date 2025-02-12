namespace ArraysUndZufallszahlen
{
    public static class Zufallszahlen
    {
        public static void BeispielMitRang()
        {
            Random rand = new Random();
            var zahl = rand.Next(1, 101);
            Console.WriteLine(zahl);
        }

        public static void BeispielOhneRang()
        {
            Random rand = new Random();
            var zahl = rand.Next();
            Console.WriteLine(zahl);
        }
    }
}
