using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class BetriebsGroesse
{
    public int BetriebsGroesseId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<Arbeitgeber> Arbeitgebers { get; set; } = new List<Arbeitgeber>();
}
