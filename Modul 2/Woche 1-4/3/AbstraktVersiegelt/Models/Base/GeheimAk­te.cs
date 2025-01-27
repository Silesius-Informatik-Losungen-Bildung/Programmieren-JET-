namespace AbstraktVersiegeltPolymorph.Models.Base
{
    internal sealed class GeheimAk­te
    {
        internal string Titel { get; set; }
        internal DateTime Erstellungsdatum { get; set; }
        internal string Geheimhaltungsstufe { get; set; }
        internal string Inhalt { get; set; }
        internal bool IstVerschluesselt { get; set; }
    }
}
