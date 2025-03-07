namespace Calculator
{
    public static class Calculator
    {
        public static int Add(int zahl1, int zahl2)
        {
            return zahl1 + zahl2;
        }

        public static int Divide(int zahl1, int zahl2)
        {
            if (zahl2 == 0)
                throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
            return zahl1 / zahl2;
        }
    }
}
