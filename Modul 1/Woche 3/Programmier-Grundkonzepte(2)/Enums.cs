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
        public static void EnumParsenVonString()
        {
            Console.WriteLine("Geben Sie einen Satus ein.");
            string antwort = Console.ReadLine();
            Status statusGeparst = (Status)Enum.Parse(typeof(Status), antwort);

            Console.WriteLine(GetStatus(statusGeparst));
        }

        public static void EnumTryParsenVonString()
        {

            Console.WriteLine("Geben Sie einen Satus ein.");
            string antwort = Console.ReadLine();
            object parsingResult;

            bool warParsenErfolgreich = Enum.TryParse(typeof(Status), antwort, true, out parsingResult);

            if (warParsenErfolgreich)
            {
                Status statusGeparst = (Status)parsingResult;
                Console.WriteLine(GetStatus(statusGeparst));
            }
            else
            {
                Console.WriteLine("Falsche Status-Eingabe");
            }
        }

        public static void EnumParsenUndInStringUmwandeln()
        {
            Console.WriteLine("Geben Sie einen Satus ein.");
            string antwort = Console.ReadLine();
            Status statusGeparst = (Status)Enum.Parse(typeof(Status), antwort);

            Console.WriteLine(GetStatusFromEnum(statusGeparst));
        }

        public static void EnumParsenVonZahl()
        {
            Console.WriteLine("Geben Sie einen Satus als Zahl ein.");
            int antwort = int.Parse(Console.ReadLine());
            Status status = (Status)antwort;
            Console.WriteLine(GetStatusFromEnum(status));
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

        private static string GetStatusFromEnum(Status status)
        {
            return "Auftrag wurde " + status.ToString();
        }
    }
}

