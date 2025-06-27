using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Lebenslauf
{
    public int LebenslaufId { get; set; }

    public int BewerberId { get; set; }

    public byte[] Dokument { get; set; } = null!;

    public virtual Bewerber Bewerber { get; set; } = null!;
}
