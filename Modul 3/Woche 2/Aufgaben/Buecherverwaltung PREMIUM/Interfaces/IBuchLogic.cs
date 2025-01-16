namespace Buecherverwaltung.Interfaces
{
    public interface IBuchLogic
    {
        bool BibliothekHatBuecher { get; }
        bool HatBibliothek { get; }
        void BibliothekSpeichern();
        void BibliothekAnzeigen();
        void BuchLoseschen(int buchId);
    }
}
