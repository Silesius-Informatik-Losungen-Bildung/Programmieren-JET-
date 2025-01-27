using AbstraktVersiegeltPolymorph.Models.Base;

namespace AbstraktVersiegeltPolymorph.Models
{
    internal class Smartphone : TragbaresElektroGeraet
    {
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
