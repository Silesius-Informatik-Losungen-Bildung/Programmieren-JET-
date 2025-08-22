namespace StreamsDemo;
using System.Text;

internal class Uebungen
{
    // Schreiben Sie einen beliebigen Text in einen MemoryStream und lesen Sie ihn direkt danach wieder aus.
    internal static void Uebung1()
    {
        string text = "Hallo MemoryStream mit StreamWriter und StreamReader!";

        using (MemoryStream memoryStream = new MemoryStream())
        {
            // Schreiben in den Stream
            using (StreamWriter writer = new StreamWriter(memoryStream))
            {
                writer.Write(text);
                writer.Flush(); // Wichtig: Daten in den Stream schreiben


                // Position auf den Anfang setzen, damit gelesen werden kann
                memoryStream.Position = 0;

                // Lesen aus dem Stream
                using (StreamReader reader = new StreamReader(memoryStream))
                {
                    string gelesenerText = reader.ReadToEnd();
                    Console.WriteLine("Gelesener Text: " + gelesenerText);
                }
            }
        }
    }

    //Schreiben Sie die Zeilen eines Arrays (string[]) in eine Datei mit FileStream.
    // Lesen Sie die Datei zeilenweise ein und geben Sie jede Zeile mit Zeilennummer aus.
    internal static void Uebung2()
    {
        string[] zeilen = {
            "Erste Zeile",
            "Zweite Zeile",
            "Dritte Zeile"
        };

        string dateipfad = "ausgabe.txt";

        // Schreiben in Datei mit FileStream
        using (FileStream fileStream = new FileStream(dateipfad, FileMode.Create, FileAccess.Write))
        using (StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8))
        {
            foreach (string zeile in zeilen)
            {
                writer.WriteLine(zeile);
            }
        }

        // Lesen aus Datei zeilenweise
        using (FileStream fileStream = new FileStream(dateipfad, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
        {
            int zeilennummer = 1;
            string? zeile;
            while ((zeile = reader.ReadLine()) != null)
            {
                Console.WriteLine($"{zeilennummer}: {zeile}");
                zeilennummer++;
            }
        }
    }

    // Schreiben Sie 3 verschiedene Datentypen (z. B. int, double, string) in eine .bin-Datei.
    // Lesen Sie diese korrekt wieder aus und geben Sie sie aus.
    internal static void Uebung3()
    {
        string dateipfad = "daten.bin";

        // Daten, die geschrieben werden sollen
        int zahl = 42;
        double gleitkommazahl = 3.14159;
        string text = "Hallo Binärwelt!";

        // Schreiben in die .bin-Datei
        using (FileStream fs = new FileStream(dateipfad, FileMode.Create, FileAccess.Write))
        using (BinaryWriter writer = new BinaryWriter(fs, Encoding.UTF8))
        {
            writer.Write(zahl);
            writer.Write(gleitkommazahl);
            writer.Write(text);
        }

        // Auslesen aus der .bin-Datei
        using (FileStream fs = new FileStream(dateipfad, FileMode.Open, FileAccess.Read))
        using (BinaryReader reader = new BinaryReader(fs, Encoding.UTF8))
        {
            int geleseneZahl = reader.ReadInt32();
            double geleseneGleitkommazahl = reader.ReadDouble();
            string gelesenerText = reader.ReadString();

            // Ausgabe
            Console.WriteLine($"Int:    {geleseneZahl}");
            Console.WriteLine($"Double: {geleseneGleitkommazahl}");
            Console.WriteLine($"String: {gelesenerText}");
        }
    }
}

