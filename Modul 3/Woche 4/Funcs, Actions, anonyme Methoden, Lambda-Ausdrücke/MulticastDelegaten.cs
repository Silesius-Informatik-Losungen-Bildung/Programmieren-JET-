public static class MulticastDelegaten
{
    delegate void MultiDelegate(string a);

    public static void Bsp1()
    {
        // Instanzieren und erstes Ziel hinzufügen
        var multiDelegate = new MultiDelegate(schreibe);
        // Zweites Ziel hinzufügen
        multiDelegate += loescheA;
        // Aufruf des Delegates
        multiDelegate("Programmieren macht glücklich");


        // So geht's entfernen:
        multiDelegate -= schreibe;

        static void schreibe(string str1)
        {
            Console.WriteLine(str1);
        }

        static void loescheA(string str1)
        {
            Console.WriteLine(str1.Replace("a",""));
        }
    }

}
