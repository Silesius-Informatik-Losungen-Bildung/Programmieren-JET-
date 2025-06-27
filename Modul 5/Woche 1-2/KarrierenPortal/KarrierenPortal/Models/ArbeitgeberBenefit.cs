using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class ArbeitgeberBenefit
{
    public int ArbeitgeberId { get; set; }

    public int BenefitId { get; set; }

    public virtual Arbeitgeber Arbeitgeber { get; set; } = null!;

    public virtual Benefit BenefitNavigation { get; set; } = null!;
}
