namespace AbstraktVersiegeltPolymorph.Models
{
    internal class Smartphone : TragbaresElektroGeraet
    {
        public Smartphone(string marke, string modell, int leistungInWatt) : base(marke, modell, leistungInWatt)
        {
            base.Marke = marke;
            base.Modell = modell;
            base.LeistungInWatt = leistungInWatt;
        }

        internal byte AnzahlKameras { get; set; }

        public override void FunktionAusfuehren()
        {
            Console.WriteLine($"{nameof(Smartphone)} ist empfangsbereit");
        }

        public override string MessageBeimHochfahren()
        {
            return $"Willkommen bei {Marke} {Modell}, deinem {nameof(Smartphone)} mit {AnzahlKameras} Kamera(s)!";
        }
    }
}
