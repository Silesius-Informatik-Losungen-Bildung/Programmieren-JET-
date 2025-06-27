using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class GehaltsSpanne
{
    public int GehaltsSpanneId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<JobAngebot> JobAngebots { get; set; } = new List<JobAngebot>();
}
