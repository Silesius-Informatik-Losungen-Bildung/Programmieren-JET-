public static class Delegaten
{
    delegate int OperationDelegate(int x, int y);
    delegate bool CompareDelegate(int x, int y);
    delegate bool CompareDelegate<T>(T x, T y);


    public static void Bsp0KlassischAlsoOhneDelageats()
    {
        int a = 7;
        int b = 3;
        int resultAdd = Add(a, b);
        int resultMultiply = Multiply(a, b);

        Console.WriteLine("Ergebnis Addition: " + resultAdd);
        Console.WriteLine("Ergebnis Multiplikation: " + resultMultiply);

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Multiply(int x, int y)
        {
            return x * y;
        }
    }

    public static void Bsp1Wiesp0AberSchonMitDelegeatesUndAusfuerlich()
    {
        var addDelegate = new OperationDelegate(Add);
        var multiplyDelegate = new OperationDelegate(Multiply);

        int a = 7;
        int b = 3;
        int resultAdd = addDelegate(a, b);
        int resultMultiply = multiplyDelegate(a, b);

        Console.WriteLine("Ergebnis Addition: " + resultAdd);
        Console.WriteLine("Ergebnis Multiplikation: " + resultMultiply);

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Multiply(int x, int y)
        {
            return x * y;
        }
    }

    public static void Bsp2KuerzereSchreibweise()
    {
        CompareDelegate compMethod = VergleicheZahlen;
        var result = compMethod(1, 2);
        Console.WriteLine("Ergebnis des Vergleiches: " + result);

        static bool VergleicheZahlen(int x, int y)
        {
            if (y < x)
                return true;
            else return false;
        }
    }

    public static void Bsp3MitGenerischenDelegaten()
    {
        CompareDelegate<int> compMethod = VergleicheZahlen;
        var result = compMethod(1, 2);

        CompareDelegate<string> compMethod2 = VergleicheZahlen;
        result = compMethod2("apfel", "birne");
        
        Console.WriteLine("Ergebnis des Vergleiches: " + result);

        bool VergleicheZahlen<T>(T x, T y) where T : IComparable
        {
            if (y.CompareTo(x) < 0)
                return true;
            else return false;
        }
    }
}









