using System;
using System.Collections.Generic;

namespace KarrierenPortal.Models;

public partial class Bewerber
{
    public int BewerberId { get; set; }

    public string Vorname { get; set; } = null!;

    public string Nachname { get; set; } = null!;

    public string Plz { get; set; } = null!;

    public string Ort { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string LandCode { get; set; } = null!;

    public DateOnly Geburtsdatum { get; set; }

    public string Email { get; set; } = null!;

    public string Telefonnummer { get; set; } = null!;

    public string? Webseite { get; set; }

    public bool Aktiv { get; set; }

    public string ErstelltAm { get; set; } = null!;

    public virtual ICollection<Benachrichtigung> Benachrichtigungs { get; set; } = new List<Benachrichtigung>();

    public virtual Bewerbung? Bewerbung { get; set; }

    public virtual Land LandCodeNavigation { get; set; } = null!;

    public virtual Lebenslauf? Lebenslauf { get; set; }

    public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
