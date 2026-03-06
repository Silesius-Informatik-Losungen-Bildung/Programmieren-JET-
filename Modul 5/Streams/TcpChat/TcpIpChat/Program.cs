// Namespaces für Netzwerkkommunikation und Textverarbeitung
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    // Einstiegspunkt des Programms (async, damit await verwendet werden kann)
    static async Task Main()
    {
        // Port für Server
        int portServer = 0;

        // Port für Client
        int portClient = 0;

        // Hostname oder IP-Adresse, mit der sich der Client verbinden soll
        string vebindeMitHost = string.Empty;

        // Benutzer fragen, ob ein Server gestartet werden soll
        Console.WriteLine("Server starten (j/n)");

        // Wenn der Benutzer "j" eingibt, wird serverJa = true
        bool serverJa = Console.ReadLine() == "j";

        if (serverJa)
        {
            // Wenn ein Server gestartet werden soll, Port abfragen
            Console.WriteLine("Port Server:");
            portServer = int.Parse(Console.ReadLine());
        }

        // Benutzer fragen, ob ein Client gestartet werden soll
        Console.WriteLine("Client starten (j/n)");
        bool clientJa = Console.ReadLine() == "j";

        if (clientJa)
        {
            // Port für den Client abfragen
            Console.WriteLine("Port Client:");
            portClient = int.Parse(Console.ReadLine());

            // Hostname oder IP-Adresse des Servers abfragen
            Console.WriteLine("Wohin verbinden (Hostname oder IP)?");
            vebindeMitHost = Console.ReadLine();
        }

        // ----------------------------------------------------
        // SERVER STARTEN
        // ----------------------------------------------------

        // Wenn ein Server gestartet werden soll,
        // wird dieser in einem Hintergrund-Task gestartet.
        // Wichtig: Kein await, da der Server eine Endlosschleife enthält.
        if (serverJa)
            _ = Task.Run(() => StartServer(portServer));

        // Kleine Pause, damit der Server Zeit hat zu starten,
        // bevor sich ein Client verbindet
        await Task.Delay(500);

        // ----------------------------------------------------
        // CLIENT STARTEN
        // ----------------------------------------------------

        if (clientJa)
            // Client starten und auf Abschluss warten
            await StartClient(vebindeMitHost, portClient);
    }

    // ----------------------------------------------------
    // SERVER IMPLEMENTIERUNG
    // ----------------------------------------------------
    static void StartServer(int port)
    {
        // TcpListener lauscht auf eingehende TCP-Verbindungen
        // IPAddress.Any bedeutet: auf allen Netzwerkschnittstellen
        TcpListener listener = new TcpListener(IPAddress.Any, port);

        // Server starten
        listener.Start();

        Console.WriteLine("[Server] gestartet auf Port " + port);

        // Endlosschleife, damit der Server permanent auf neue Clients wartet
        while (true)
        {
            // Blockiert, bis sich ein Client verbindet
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("[Server] Client verbunden");

            // Jeder Client wird in einem eigenen Task verarbeitet,
            // damit mehrere Clients gleichzeitig verbunden sein können
            Task.Run(() =>
            {
                // using sorgt dafür, dass Ressourcen automatisch freigegeben werden
                using (client)

                // Netzwerkstream für die Kommunikation
                using (NetworkStream stream = client.GetStream())

                // Reader zum Lesen von Text aus dem Stream
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string nachricht;

                    // Nachrichten lesen, solange der Client sendet
                    while ((nachricht = reader.ReadLine()) != null)
                    {
                        // Empfangene Nachricht ausgeben
                        Console.WriteLine($"[Server] empfängt: {nachricht}");
                    }
                }

                // Wenn die Schleife endet, hat der Client die Verbindung beendet
                Console.WriteLine("[Server] Client getrennt");
            });
        }
    }

    // ----------------------------------------------------
    // CLIENT IMPLEMENTIERUNG
    // ----------------------------------------------------
    static async Task StartClient(string host, int port)
    {
        // TcpClient für die Verbindung zum Server
        TcpClient client = new TcpClient();

        // Zähler für Verbindungsversuche
        int versuch = 0;

        // Solange versuchen, bis Verbindung erfolgreich ist
        while (true)
        {
            try
            {
                versuch++;

                Console.WriteLine($"[Client] Verbindungsversuch {versuch} zu {host}:{port} ...");

                // Asynchrone Verbindung zum Server herstellen
                await client.ConnectAsync(host, port);

                Console.WriteLine("[Client] Verbunden mit Server.");

                // Verbindung erfolgreich → Schleife verlassen
                break;
            }
            catch (SocketException)
            {
                // Wenn Server nicht erreichbar ist, Fehlermeldung
                Console.WriteLine("[Client] Server nicht erreichbar. Neuer Versuch in 3 Sekunden...");

                // 3 Sekunden warten
                await Task.Delay(3000);
            }
        }

        // Ressourcen automatisch freigeben
        using (client)

        // Netzwerkstream
        using (NetworkStream stream = client.GetStream())

        // Reader zum Lesen von Nachrichten vom Server
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))

        // Writer zum Senden von Nachrichten
        using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
        {
            // ----------------------------------------------------
            // EMPFANGEN IM HINTERGRUND
            // ----------------------------------------------------

            // Hintergrund-Task, der permanent auf Nachrichten wartet
            _ = Task.Run(async () =>
            {
                string? zeile;

                // Solange Nachrichten vom Server kommen
                while ((zeile = await reader.ReadLineAsync()) != null)
                    Console.WriteLine(zeile);
            });

            Console.WriteLine("[Client] Schreiben Sie ....('exit' zum Beenden):");

            // ----------------------------------------------------
            // SENDESCHLEIFE
            // ----------------------------------------------------

            while (true)
            {
                // Eingabe des Benutzers
                string? text = Console.ReadLine();

                // Wenn "exit" eingegeben wird, Client beenden
                if (text?.ToLower() == "exit")
                    break;

                // Nachricht an Server senden
                await writer.WriteLineAsync(text);
            }
        }

        // Verbindung beendet
        Console.WriteLine("[Client] Verbindung beendet.");
    }
}