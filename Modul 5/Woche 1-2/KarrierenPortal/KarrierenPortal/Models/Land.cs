using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Land
{
    public string LandCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Arbeitgeber> Arbeitgebers { get; set; } = new List<Arbeitgeber>();

    public virtual ICollection<Bewerber> Bewerbers { get; set; } = new List<Bewerber>();
}
