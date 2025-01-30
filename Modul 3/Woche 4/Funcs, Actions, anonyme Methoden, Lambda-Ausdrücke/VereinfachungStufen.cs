public static class VereinfachungStufen
{
    
    delegate string StrDelegate(string str1, string str2);


    public static void Bsp1KlassischOnheDelegate()
    {
        var result1 = func1("Apfel", "Birne");
        Console.WriteLine(result1);

        var result2 = func2("Apfel", "Birne");
        Console.WriteLine(result2);
    }

    public static void BspMitDelegate()
    {

        // Instanzieren von StrDelegate mit Verweise auf Methode func1
        var strDelegate = new StrDelegate(func1);


        var result1 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result1);

        // Nun zeigt StrDelegate auf Methode func2
        strDelegate = func2;
        var result2 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result2);
    }

    public static void MitAnonymFunct()
    {
        var strDelegate = delegate (string str1, string str2)
        {
            return string.Concat(str1, str2); // Dies ist der Code aus der ehemaligen func1
        };

        Console.WriteLine(strDelegate("Apfel", "Birne"));

        strDelegate = delegate (string str1, string str2)
        {
            return str1.Replace(str1, str2); // Dies ist der Code aus der ehemaligen func2
        };
        Console.WriteLine(strDelegate("Apfel", "Birne"));
    }

    static string func1(string str1, string str2)
    {
        return string.Concat(str1, str2);
    }

    static string func2(string str1, string str2)
    {
        return str1.Replace(str1, str2);
    }


    public static void MitLambda()

    {
        var strDelegate = (string str1, string str2) => string.Concat(str1, str2);
        var result1 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result1);

        strDelegate = (string str1, string str2) => str1.Replace(str1, str2);
        var result2 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result2);
    }

    public static void MitFunc()
    {

        Func<string, string, string> strDelegate = (str1, str2) => string.Concat(str1, str2);
        var result1 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result1);

        strDelegate = (str1, str2) => str1.Replace(str1, str2);
        var result2 = strDelegate("Apfel", "Birne");
        Console.WriteLine(result2);
    }


    public static void MitAction()
    {
        Action<string, string> strDelegate = (str1, str2) => Console.WriteLine(string.Concat(str1, str2));
        strDelegate("Apfel", "Birne");

        Action<string, string> strDelegate2 = (str1, str2) => Console.WriteLine(str1.Replace(str1, str2));
        strDelegate2("Apfel", "Birne");
    }
}
