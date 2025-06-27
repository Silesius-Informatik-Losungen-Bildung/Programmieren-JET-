using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Benachrichtigung
{
    public int BenachrichtigungId { get; set; }

    public int BewerberId { get; set; }

    public string Text { get; set; } = null!;

    public DateTime ErstelltAm { get; set; }

    public virtual Bewerber Bewerber { get; set; } = null!;
}
