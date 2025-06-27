using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string Beschreibung { get; set; } = null!;

    public virtual ICollection<Bewerber> Bewerbers { get; set; } = new List<Bewerber>();

    public virtual ICollection<JobAngebot> JobAngebots { get; set; } = new List<JobAngebot>();
}
