using Buecherverwaltung.Logic;


var buchLogic = new BuchLogic();
if (!buchLogic.HatBibliothek)
{
    Console.WriteLine("Sie haben noch keine Bibliothek.\nMöchten Sie eine Bibliothek anlegen ( ja / nein )?");

    if (Console.ReadLine() == "ja")
    {
        buchLogic.BibliothekSpeichern();
        Console.WriteLine("Ihre Bibliothek wurde erfolgreich angelegt");
    }
}

buchLogic.BibliothekAnzeigen();

Console.WriteLine("Möchten Sie neue Bücher anlegen (1), löschen (2) oder abbrechen (3)?");
var antwort = Console.ReadLine();

do
{
    if (antwort == "1")
    {
        buchLogic.BuchSpeichern();
        buchLogic.BibliothekAnzeigen();

    }
    else if (antwort == "2")
    {
        BuecherLoeschen();
        buchLogic.BibliothekAnzeigen();
    }

    Console.WriteLine("Möchten Sie neue Bücher anlegen (1), löschen (2) oder abbrechen (3)?");
    antwort = Console.ReadLine();
}
while (antwort == "1" || antwort == "2");



void BuecherLoeschen()
{
    var antwort = "";
    do
    {
        if (!buchLogic.BibliothekHatBuecher)
        {
            Console.WriteLine("Es gibt nix, was Sie löschen könnten.");
            return;
        }

        Console.WriteLine("Geben Sie die Id des zu löschenden Buches ein!");
        var buchId = int.Parse(Console.ReadLine());
        buchLogic.BuchLoseschen(buchId);
        Console.WriteLine("Möchten Sie ein weiteres Buch löschen ( ja / nein )?");
        antwort = Console.ReadLine();
    }
    while (antwort == "ja");

}
