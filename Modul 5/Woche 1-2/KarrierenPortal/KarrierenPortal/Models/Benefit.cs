using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Benefit
{
    public int BenefitId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<ArbeitgeberBenefit> ArbeitgeberBenefits { get; set; } = new List<ArbeitgeberBenefit>();
}
