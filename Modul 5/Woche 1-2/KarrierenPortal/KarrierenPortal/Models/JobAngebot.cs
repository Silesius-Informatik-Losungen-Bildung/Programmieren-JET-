using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class JobAngebot
{
    public int JobAngebotId { get; set; }

    public int ArbeitgeberId { get; set; }

    public string Titel { get; set; } = null!;

    public string Beschreibung { get; set; } = null!;

    public int? GehaltsSpanneId { get; set; }

    public int? ArbeitszeitmodellId { get; set; }

    public int? ArbeitsortId { get; set; }

    public DateOnly? Bewerbungsfrist { get; set; }

    public bool Aktiv { get; set; }

    public string ErstalltAm { get; set; } = null!;

    public virtual Arbeitgeber Arbeitgeber { get; set; } = null!;

    public virtual Arbeitsort? Arbeitsort { get; set; }

    public virtual Arbeitszeitmodell? Arbeitszeitmodell { get; set; }

    public virtual ICollection<Bewerbung> Bewerbungs { get; set; } = new List<Bewerbung>();

    public virtual GehaltsSpanne? GehaltsSpanne { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
