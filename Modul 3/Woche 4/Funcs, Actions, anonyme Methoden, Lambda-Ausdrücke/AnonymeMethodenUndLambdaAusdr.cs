public static class AnonymeMethodenUndLambdaAusdr
{
    delegate int OperationDelegate(int x, int y);
    delegate void VoidDelegate(int j);
    delegate string StringDelegate(int j);

    public static void Bsp1MitAusgeschriebenerAnonymerMethode()
    {
        OperationDelegate multiplyDelegate = delegate (int x, int y)
        {
            return x * y;
        };

        var result = multiplyDelegate(7, 3);
        Console.WriteLine("Ergebnis Addition: " + result);
    }

    // Lambda
    public static void Bsp2WieBsp1AberMitLambdaAusdruck()
    {
        OperationDelegate multiplyDelegate = (int x, int y) => x * y;
        var result = multiplyDelegate(7, 3);

        Console.WriteLine("Ergebnis Multiplikation: " + result);
    }

    public static void Bsp3MitVoid()
    {
        VoidDelegate voidDelegate = (int j) => Console.WriteLine(j.ToString() + " Hallo");
        voidDelegate(23);
    }

    public static void Bsp4MitString()
    {
        StringDelegate strDel = (int x) => $"Alles Guten zum {x}. Geburtstag";
        Console.WriteLine(strDel(23));
    }

}









