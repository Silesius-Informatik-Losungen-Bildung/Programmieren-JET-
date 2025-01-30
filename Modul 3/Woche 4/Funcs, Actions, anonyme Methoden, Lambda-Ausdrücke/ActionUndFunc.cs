public static class ActionUndFunc
{
    public static void Bsp1FuncMitRueckgabeWert()
    {
        Func<int, int, int> multiply = (x, y) => x * y;
        Console.WriteLine("Ergebnis der Multiplikation: " + multiply(3, 4));
    }

    public static void Bsp2ActionSprichKeinRueckgabeWert()
    {
        Action<int> druckeNachricht = (j) => Console.WriteLine(j.ToString() + " Hallo");
        druckeNachricht(1);
    }

}

