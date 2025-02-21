using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Tasks_und_async_await
{
    public static class Beispiele
    {
        public static void LadeDatenSynchron()
        {
            Console.WriteLine("Start");
            Thread.Sleep(5000); // 5 Sekunden warten
            Console.WriteLine("Ende");
        }

        public static async Task LadeDatenASynchron()
        {
            Console.WriteLine("Daten werden asynchron geladen...");
            await Task.Delay(3000); // Simuliert eine asynchrone Operation
            Console.WriteLine("Daten wurden geladen.");
        }

        public static void EinfachesTaskBeispiel()
        {
            Task task = Task.Run(() =>
           {
               Console.WriteLine("Task startet...");
               Task.Delay(5000).Wait(); // simuliert 5 Sekunden Wartezeit
               Console.WriteLine("Task beendet.");
           });
            task.Wait();
        }

        public static Task<int> BerechneAsync()
        {
            Task<int> BerechneAsync()
            {
                return Task.Run(() =>
                {
                    Thread.Sleep(2000); // Simuliert eine Berechnung
                    return 42; // Gibt ein Ergebnis zurück
                });
            }
            return BerechneAsync();
        }




        public static async Task EinfachesTaskBeispielASync()
        {
            // Einfaches async/await-Beispiel
            Console.WriteLine("Start");
            await WarteAsync();
            Console.WriteLine("Ende");
            static async Task WarteAsync()
            {
                Console.WriteLine("Warten beginnt");
                await Task.Delay(3000); // Warten ohne Blockieren des Threads
                Console.WriteLine("Warten beendet");
            }
        }

        public static void MehrereAufgabenSync()
        {
            // Komplexeres Beispiel: Mehrere Tasks gleichzeitig SYNC
            WarteSync("Task 1", 2000);
            WarteSync("Task 2", 4000);
            WarteSync("Task 3", 1000);
            Console.WriteLine("Alle Tasks beendet.");

            static void WarteSync(string name, int millisekunden)
            {
                Console.WriteLine($"{name} startet");
                Thread.Sleep(millisekunden);
                Console.WriteLine($"{name} beendet");
            }
        }

        public static async Task MehrereTaksASync()
        {
            // Komplexeres Beispiel: Mehrere Tasks gleichzeitig ASYNC
            Task t1 = WarteAsync("Task 1", 2000);
            Task t2 = WarteAsync("Task 2", 4000);
            Task t3 = WarteAsync("Task 3", 1000);

            await Task.WhenAll(t1, t2, t3);
            Console.WriteLine("Alle Tasks beendet.");

            static async Task WarteAsync(string name, int millisekunden)
            {
                Console.WriteLine($"{name} startet");
                await Task.Delay(millisekunden);
                Console.WriteLine($"{name} beendet");
            }
        }

        public static async Task FrühstückAsync()
        {
            Console.WriteLine("Frühstücksvorbereitung gestartet...");

            // Starten der Aufgaben gleichzeitig
            Task kaffeeTask = KaffeeKochenAsync();
            Task eierTask = EierspeiseMachenAsync();
            Task toastTask = ToastToastenAsync();

            // Warten, bis alle Aufgaben abgeschlossen sind
            await Task.WhenAll(kaffeeTask, eierTask, toastTask);

            Console.WriteLine("Frühstück ist fertig!");


            static async Task KaffeeKochenAsync()
            {
                Console.WriteLine("Kaffee kochen gestartet...");
                await Task.Delay(5000); // simuliert 5 Sekunden Wartezeit
                Console.WriteLine("Kaffee ist fertig!");
            }

            static async Task EierspeiseMachenAsync()
            {
                Console.WriteLine("Eierspeise machen gestartet...");
                await Task.Delay(7000); // simuliert 7 Sekunden Wartezeit
                Console.WriteLine("Eierspeise ist fertig!");
            }

            static async Task ToastToastenAsync()
            {
                Console.WriteLine("Toast toasten gestartet...");
                await Task.Delay(3000); // simuliert 3 Sekunden Wartezeit
                Console.WriteLine("Toast ist fertig!");
            }
        }
        public static async Task BildDownLoader()
        {
            List<string> urls = new()
                    {
                        "https://upload.wikimedia.org/wikipedia/commons/5/52/Bee_on_Echinacea.jpg",
                        "https://upload.wikimedia.org/wikipedia/commons/d/df/Eiche_auf_der_Pfaueninsel.jpg",
                        "https://upload.wikimedia.org/wikipedia/commons/2/20/Odenthal_Ortszentrum_Pfarrhaus.jpg"
                    };

            Console.WriteLine("Starte Webanfragen...");
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Starte alle Anfragen gleichzeitig
            var tasks = new List<Task<long>>();

            for (int i = 0; i < urls.Count; i++)
            {
                string? url = urls[i];
                tasks.Add(MesseAntwortzeit(url, i));
            }

            // Warten auf alle Anfragen
            long[] antwortzeiten = await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine($"Alle Anfragen abgeschlossen in {stopwatch.ElapsedMilliseconds} ms\n");

            // Ergebnisse ausgeben
            for (int i = 0; i < urls.Count; i++)
            {
                Console.WriteLine($"Antwortzeit für {urls[i]}: {antwortzeiten[i]} ms");
            }

            static async Task<long> MesseAntwortzeit(string url, int i)
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");
                var stopwatch = Stopwatch.StartNew();

                try
                {
                    byte[] imageBytes = await httpClient.GetByteArrayAsync(url);
                    // Speichern des Bildes auf der Festplatte
                    await File.WriteAllBytesAsync("Bild_" + i + ".jpg", imageBytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler bei {url}: {ex.Message}");
                    return -1; // Fehlercode
                }

                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
