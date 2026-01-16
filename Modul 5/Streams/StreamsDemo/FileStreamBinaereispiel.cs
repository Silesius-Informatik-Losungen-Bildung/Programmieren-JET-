namespace StreamsDemo;
internal class FileStreamBinaer
{
    internal static void Bsp()
    {
        string pfad = "daten.bin";

        // Schreiben
        using (var fileStream = new FileStream(pfad, FileMode.Create))
        using (var binaryWriter = new BinaryWriter(fileStream))
        {
            binaryWriter.Write(42);
            binaryWriter.Write(3.14);
            binaryWriter.Write(true);
            binaryWriter.Write("Hallo Welt");
        }

        // Lesen
        using (var fileStream = new FileStream(pfad, FileMode.Open))
        using (var binaryReader = new BinaryReader(fileStream))
        {
            int zahl = binaryReader.ReadInt32();
            double d = binaryReader.ReadDouble();
            bool b = binaryReader.ReadBoolean();
            string text = binaryReader.ReadString();

            Console.WriteLine($"Gelesen: {zahl}, {d}, {text}");
        }
    }
}