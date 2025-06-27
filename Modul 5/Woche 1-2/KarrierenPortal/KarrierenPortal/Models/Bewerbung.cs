using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Bewerbung
{
    public int BewerbungId { get; set; }

    public int JobAngebotId { get; set; }

    public int BewerberId { get; set; }

    public string Schreiben { get; set; } = null!;

    public int BewerbungStatusId { get; set; }

    public DateTime ErstelltAm { get; set; }

    public virtual Bewerber BewerbungNavigation { get; set; } = null!;

    public virtual BewerbungStatus BewerbungStatus { get; set; } = null!;

    public virtual JobAngebot JobAngebot { get; set; } = null!;
}
