namespace Programmier_Grundkonzepte_2_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Switch.Klassisch();
            Switch.MitEnum();
            Switch.MitWhen();
            Switch.MitExpressions();
            Switch.MitTupeln();
            Switch.Uebung1();

            Schleifen.For();
            Schleifen.While();
            Schleifen.DoWhile();
            Schleifen.UnednlichMitFor();
            Schleifen.UnednlichMitWhile();
            Schleifen.MitBreakBeenden();
            Schleifen.MitContinue();
            Schleifen.MitGoTo();
            Schleifen.Rekursiv();

            Enums.EnumParsenVonString();
            Enums.EnumTryParsenVonString();
            Enums.EnumParsenUndInStringUmwandeln();
            Enums.EnumParsenVonZahl();
        }
    }
}

