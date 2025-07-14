using AbstraktVersiegeltPolymorph.Models.Base;

namespace AbstraktVersiegeltPolymorph.Models
{
    internal abstract class TragbaresElektroGeraet: ElektroGeraet
    {
        protected TragbaresElektroGeraet(string marke, string modell, int leistungInWatt) : base(marke, modell, leistungInWatt)
        {
            base.Marke = marke;
            base.Modell = modell;
            base.LeistungInWatt = leistungInWatt;
        }

        internal bool HatNetzanschluss { get; set; }
        internal bool HatAkku { get; set; }
    }
}
