using AbstraktVersiegeltPolymorph.Models.Base;

namespace AbstraktVersiegeltPolymorph.Models
{
    public class Kuehlschrank : ElektroGeraet
    {
        public Kuehlschrank(string marke, string modell, int leistungInWatt, int kuehlvolumen)
            : base(marke, modell, leistungInWatt)
        {
            this.Kuehlvolumen = kuehlvolumen;
        }

        public int Kuehlvolumen { get; set; }
        public double MomentaneTemperatur { get; private set; }

        public override void FunktionAusfuehren()
        {
            Console.WriteLine($"{nameof(Kuehlschrank)} kühlt");
        }

        public override string MessageBeimHochfahren()
        {
            return $"Willkommen bei Deinem {nameof(Kuehlschrank)} {base.Marke} {base.Modell} mit dem {nameof(Kuehlvolumen)} von {Kuehlvolumen} Liter!";
        }

        public override void MessageBeimHerunterfahren()
        {
            base.MessageBeimHerunterfahren();
            Console.WriteLine(nameof(this.MomentaneTemperatur) + " erhöht sich." );
        }

        private void MessTemp()
        {
            // ....
            MomentaneTemperatur = 3.5d;
        }

    }
}
