namespace AbstraktVersiegeltPolymorph.Models.Base
{
    public abstract class ElektroGeraet
    {
        public ElektroGeraet(string marke, string modell, int leistungInWatt)
        {
            Marke = marke;
            Modell = modell;
            LeistungInWatt = leistungInWatt;
        }

        public string Marke { get; set; }
        public string Modell { get; set; }
        public int LeistungInWatt { get; set; }

        public abstract string MessageBeimHochfahren();
        public abstract void FunktionAusfuehren();

        public virtual void MessageBeimHerunterfahren()
        {
            Console.WriteLine($"Gerät  {Marke} {Modell} wird heruntergefahren");
        }
    }
}
