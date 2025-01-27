namespace AbstraktVersiegeltPolymorph.Models.Base
{
    internal abstract class ElektroGeraet
    {
        internal string Marke { get; set; }
        internal string Modell { get; set; }
        public int LeistungInWatt { get; set; }
        public abstract string MessageBeimHochfahren();
        public abstract void FunktionAusfuehren();
    }
}
