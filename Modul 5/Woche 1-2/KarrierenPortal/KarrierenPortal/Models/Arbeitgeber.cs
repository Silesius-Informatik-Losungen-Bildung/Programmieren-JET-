using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Arbeitgeber
{
    public int ArbeitgeberId { get; set; }

    public string Name { get; set; } = null!;

    public string Beschreibung { get; set; } = null!;

    public int BetriebsGroesseId { get; set; }

    public string Plz { get; set; } = null!;

    public string Ort { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string LandCode { get; set; } = null!;

    public int BrancheId { get; set; }

    public string Email { get; set; } = null!;

    public string Telefonnummer { get; set; } = null!;

    public string? Ansprechpartner { get; set; }

    public string? Webseite { get; set; }

    public bool Aktiv { get; set; }

    public DateTime ErstelltAm { get; set; }

    public virtual ICollection<ArbeitgeberBenefit> ArbeitgeberBenefits { get; set; } = new List<ArbeitgeberBenefit>();

    public virtual BetriebsGroesse BetriebsGroesse { get; set; } = null!;

    public virtual Branche Branche { get; set; } = null!;

    public virtual ICollection<JobAngebot> JobAngebots { get; set; } = new List<JobAngebot>();

    public virtual Land LandCodeNavigation { get; set; } = null!;
}
