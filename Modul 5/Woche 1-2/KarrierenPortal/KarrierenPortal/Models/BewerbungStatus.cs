using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class BewerbungStatus
{
    public int BewerbungStatusId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<Bewerbung> Bewerbungs { get; set; } = new List<Bewerbung>();
}
