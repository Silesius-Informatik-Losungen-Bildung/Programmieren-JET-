using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Branche
{
    public int BrancheId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<Arbeitgeber> Arbeitgebers { get; set; } = new List<Arbeitgeber>();
}
