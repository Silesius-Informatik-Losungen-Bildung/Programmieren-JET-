class Program
{
    static void Main(string[] args)
    {

        // vOn klassichem Aufruf zu Action
        VereinfachungStufen.Bsp1KlassischOnheDelegate();
        VereinfachungStufen.BspMitDelegate();
        VereinfachungStufen.MitAnonymFunct();
        VereinfachungStufen.MitLambda();
        VereinfachungStufen.MitFunc();
        VereinfachungStufen.MitAction();


        MulticastDelegaten.Bsp1();


        // Weitere Beispiele

        Delegaten.Bsp0KlassischAlsoOhneDelageats();
        Delegaten.Bsp1Wiesp0AberSchonMitDelegeatesUndAusfuerlich();
        Delegaten.Bsp2KuerzereSchreibweise();
        Delegaten.Bsp2KuerzereSchreibweise();
        Delegaten.Bsp3MitGenerischenDelegaten();

        ActionUndFunc.Bsp1FuncMitRueckgabeWert();
        ActionUndFunc.Bsp2ActionSprichKeinRueckgabeWert();

        AnonymeMethodenUndLambdaAusdr.Bsp1MitAusgeschriebenerAnonymerMethode();
        AnonymeMethodenUndLambdaAusdr.Bsp2WieBsp1AberMitLambdaAusdruck();
        AnonymeMethodenUndLambdaAusdr.Bsp3MitVoid();
        AnonymeMethodenUndLambdaAusdr.Bsp4MitString();


        BuchFilter.Query();
    }
}