namespace Programmier_Grundkonzepte_2_
{
    public static class Schleifen
    {

        public static void For()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Durchlauf {i}");
            }

        }

        public static void While()
        {
            int zahl;
            do
            {
                Console.Write("Gib eine Zahl ein (0 zum Beenden): ");
                zahl = Convert.ToInt32(Console.ReadLine());
            } while (zahl != 0);

        }

        public static void DoWhile()
        {
            int geheimzahl = 7;
            int eingabe;

            do
            {
                Console.Write("Rate die Zahl: ");
                eingabe = Convert.ToInt32(Console.ReadLine());
            } while (eingabe != geheimzahl);

            Console.WriteLine("Richtig geraten!");
        }

        public static void UnednlichMitFor()
        {
            for (; ; )
            {
                Console.WriteLine("Unendliche for-Schleife!");
            }

        }

        public static void UnednlichMitWhile()
        {
            while (true)
            {
                Console.WriteLine("Diese Schleife läuft unendlich!");
            }
        }

        public static void MitBreakBeenden()
        {
            int n = 1;

            while (true)
            {
                if (n == 5)
                {
                    Console.WriteLine("5 gefunden! Beende die Schleife.");
                    break;
                }
                Console.WriteLine(n);
                n++;
            }

        }


        public static void MitContinue()
        {
            for (int i = 1; i <= 5; i++)
            {
                if (i == 3)
                    continue;  // Überspringt die 3

                Console.WriteLine(i);
            }

        }

        public static void MitGoTo()
        {
            int x = 0;

            start:
            Console.WriteLine(x);
            x++;
            if (x < 5)
                goto start;  // Springt zurück zu "start"

        }

    }
}
