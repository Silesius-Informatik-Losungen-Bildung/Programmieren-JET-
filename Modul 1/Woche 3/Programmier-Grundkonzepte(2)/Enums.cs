namespace Programmier_Grundkonzepte_2_
{
    enum Status
    {
        Offen,
        InBearbeitung,
        Abgeschlossen,
        Storniert
    }

    public class Enums
    {
        public static void EnumBeispiel1()
        {

            Console.WriteLine("Geben Sie einen Satus ein.");
            Console.WriteLine(GetStatus((Status)Enum.Parse(typeof(Status), Console.ReadLine())));
        }

        public static void EnumBeispiel2()
        {

            Console.WriteLine("Geben Sie einen Satus ein.");
            if (Enum.TryParse(typeof(Status), Console.ReadLine(), true, out object? status))
            {
                Console.WriteLine(GetStatus((Status)status));
            }
            else
            {
                Console.WriteLine("Falsche Status-Eingabe");
            }
        }

        private static string GetStatus(Status status)
        {
            switch (status)
            {
                case Status.Offen:
                    return "Auftrag wurde erfasst.";
                case Status.InBearbeitung:
                    return "Auftrag ist in Bearbeitung.";
                case Status.Abgeschlossen:
                    return "Auftrag ist abgeschlossen.";
                case Status.Storniert:
                    return "Auftrag wurde storniert.";
                default:
                    return string.Empty;
            }

        }
    }
}
