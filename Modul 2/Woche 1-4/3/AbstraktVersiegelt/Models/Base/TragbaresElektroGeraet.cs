using AbstraktVersiegeltPolymorph.Models.Base;

namespace AbstraktVersiegeltPolymorph.Models
{
    internal abstract class TragbaresElektroGeraet: ElektroGeraet
    {
        internal bool HatNetzanschluss { get; set; }
        internal bool HatAkku { get; set; }
    }
}
