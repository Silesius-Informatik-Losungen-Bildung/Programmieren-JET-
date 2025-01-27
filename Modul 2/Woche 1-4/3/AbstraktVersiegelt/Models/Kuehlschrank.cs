using AbstraktVersiegeltPolymorph.Models.Base;

namespace AbstraktVersiegeltPolymorph.Models
{
    internal class Kuehlschrank : ElektroGeraet
    {
        internal int Kuehlvolumen { get; set; }

        public override void FunktionAusfuehren()
        {
            Console.WriteLine($"{nameof(Kuehlschrank)} kühlt");
        }

        public override string MessageBeimHochfahren()
        {
            return $"Willkommen bei Deinem {nameof(Kuehlschrank)}, mit dem {nameof(Kuehlvolumen)} von {Kuehlvolumen} Liter!";
        }
    }
}
