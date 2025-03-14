namespace TiereVerwaltung
{
    internal class Program
    {
        static void Main()
        {
            Hund[] hunde =
            {
                new Hund("Bello", 5, 20, "Labrador", true),
                new Hund("Rocky", 7, 25, "Schäferhund", true)
            };

            Katze[] katzen =
            {
                new Katze("Minka", 2, 2, true),
                new Katze("Sissy", 3, 4, true)
            };

            Console.Write("Welche Tiere möchten Sie ausgeben (Hunde oder Katzen)?:");
            string eingabe = Console.ReadLine();

            switch (eingabe)
            {
                case "Hunde":
                    for (int i = 0; i < hunde.Length; i++)
                    {
                        hunde[i].ZeigeInfo();
                    }
                    break;
                case "Katzen":
                    for (int i = 0; i < katzen.Length; i++)
                    {
                        katzen[i].ZeigeInfo();
                    }
                    break;
                default:
                    Console.WriteLine("Keine gültige Eingabe.");
                    break;
            }
        }
    }
}
