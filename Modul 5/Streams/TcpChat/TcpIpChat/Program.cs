using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static async Task Main()
    {

        int portServer = 0;
        int portClient = 0;
        string vebindeMitHost = string.Empty;

        Console.WriteLine("Server starten (j/n)");
        bool serverJa = Console.ReadLine() == "j";
        if (serverJa)
        {
            Console.WriteLine("Port Server:");
            portServer = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Client starten (j/n)");
        bool clientJa = Console.ReadLine() == "j";
        if (clientJa)
        {
            Console.WriteLine("Port Client:");
            portClient = int.Parse(Console.ReadLine());

            Console.WriteLine("Wohin verbinden (Hostname oder IP)?");
            vebindeMitHost = Console.ReadLine();
        }

        // Server im Hintergrund starten
        if (serverJa)
            _ = Task.Run(() => StartServer(portServer)); // <-- kein await hier (wegen Endlosschleife)!

        await Task.Delay(500); // kleine Pause, damit Server starten kann

        if (clientJa)
            // Client starten
            await StartClient(vebindeMitHost, portClient);

    }

    static void StartServer(int port)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine("[Server] gestartet auf Port " + port);

        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("[Server] Client verbunden");

            Task.Run(() =>
            {
                using (client)
                using (NetworkStream stream = client.GetStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string nachricht;
                    while ((nachricht = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"[Server] empfängt: {nachricht}");
                    }
                }

                Console.WriteLine("[Server] Client getrennt");
            });
        }
    }

    static async Task StartClient(string host, int port)
    {
        TcpClient client = new TcpClient();

        int versuch = 0;
        while (true)
        {
            try
            {
                versuch++;
                Console.WriteLine($"[Client] Verbindungsversuch {versuch} zu {host}:{port} ...");
                await client.ConnectAsync(host, port);
                Console.WriteLine("[Client] Verbunden mit Server.");
                break; // erfolgreich, Schleife beenden
            }
            catch (SocketException)
            {
                Console.WriteLine("[Client] Server nicht erreichbar. Neuer Versuch in 3 Sekunden...");
                await Task.Delay(3000); // 3 Sekunden warten
            }
        }

        using (client)
        using (NetworkStream stream = client.GetStream())
        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
        using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
        {
            // Empfangen im Hintergrund
            _ = Task.Run(async () =>
            {
                string? zeile;
                while ((zeile = await reader.ReadLineAsync()) != null)
                    Console.WriteLine(zeile);
            });

            Console.WriteLine("[Client] Schreiben Sie ....('exit' zum Beenden):");

            while (true)
            {
                string? text = Console.ReadLine();
                if (text?.ToLower() == "exit")
                    break;

                await writer.WriteLineAsync(text);
            }
        }

        Console.WriteLine("[Client] Verbindung beendet.");
    }

}
