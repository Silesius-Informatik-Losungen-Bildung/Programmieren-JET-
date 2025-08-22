namespace StreamsDemo;
internal class FileStreamBeispiel
{
    internal static void Bsp()
    {
        string pfad = "ausgabe.txt";

        // Schreiben
        using (var fileStream = new FileStream(pfad, FileMode.Create))
        using (var streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.WriteLine("Dies ist eine Datei.");
        }

        // Lesen
        using (var fileStream = new FileStream(pfad, FileMode.Open))
        using (var streamReader = new StreamReader(fileStream))
        {
            Console.WriteLine("Dateiinhalt: " + streamReader.ReadToEnd());
        }
    }
}