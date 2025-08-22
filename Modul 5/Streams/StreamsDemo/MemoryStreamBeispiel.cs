namespace StreamsDemo;
using System.Text;

internal class MemoryStreamBeispiel
{
    internal static void Bsp()
    {
        
        // Schreiben
        using var stream = new MemoryStream();
        using var writer = new StreamWriter(stream, Encoding.UTF8);

        writer.Write("Hallo Welt!");
        writer.Flush(); // Inhalt in den Stream schreiben


        // Lesen
        stream.Position = 0; // Zurück an den Anfang, um Alles lesen zu können

        using var reader = new StreamReader(stream, Encoding.UTF8);
        var result = reader.ReadToEnd();

        Console.WriteLine("Gelesen aus MemoryStream: " + result);
    }
}