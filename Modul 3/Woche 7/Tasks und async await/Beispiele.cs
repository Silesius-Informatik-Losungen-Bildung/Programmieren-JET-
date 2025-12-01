using System.Diagnostics;

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

        public static async Task EinfachesTaskBeispielAsync()
        {
            // Gibt sofort eine Ausgabe im Hauptthread aus
            Console.WriteLine("Synchrome Zeile 1...");

            // Startet einen neuen Task im ThreadPool
            // Der Lambda-Ausdruck ist async, daher kann darin await verwendet werden
            await Task.Run(async () =>
            {
                // Wird im Hintergrund-Thread ausgeführt
                Console.WriteLine("Task startet...");

                // Asynchrone, nicht blockierende Pause von 5 Sekunden
                // Der Thread bleibt in dieser Zeit frei für andere Aufgaben
                await Task.Delay(5000);

                // Wird nach Ablauf der Wartezeit ausgeführt
                Console.WriteLine("Task beendet.");
            });

            // Diese Zeile wird erst ausgeführt, nachdem der Task beendet wurde
            Console.WriteLine("Synchrome Zeile 2...");
        }

        public static Task<int> BerechneAsync()
        {
            var task = Task.Run(() =>
            {
                Thread.Sleep(2000); // Simuliert eine Berechnung
                return 42; // Gibt ein Ergebnis zurück
            });
            return task;
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
            // Startet drei asynchrone Tasks gleichzeitig
            Task task1 = WarteAsync("Task 1", 2000);
            Task task2 = WarteAsync("Task 2", 4000);
            Task task3 = WarteAsync("Task 3", 1000);

            // Wartet asynchron, bis ALLE drei Tasks abgeschlossen sind
            // Der aufrufende Thread wird dabei NICHT blockiert
            await Task.WhenAll(task1, task2, task3);

            // Wird erst ausgegeben, wenn t1, t2 und t3 beendet sind
            Console.WriteLine("Alle Tasks beendet.");


            // Asynchrone Methode, die einen Task zurückliefert
            static async Task WarteAsync(string name, int millisekunden)
            {
                // Ausgabe zum Start des Tasks
                Console.WriteLine($"{name} startet");

                // Asynchrone Wartezeit (nicht blockierend)
                // Der Thread bleibt frei für andere Aufgaben
                await Task.Delay(millisekunden);

                // Ausgabe nach Ablauf der Wartezeit
                Console.WriteLine($"{name} beendet");
            }
        }

        public static void MachAlles()
        {
            // Schritt 1: Sync im Haupt-Thread (blockierend)
            GebeMessageAus();

            // Schritt 2: Sync im Haupt-Thread (blockierend)
            var istOk = Schreibe5000DatensätzeInDb();

            // Schritt 3: Sync im Haupt-Thread
            Console.WriteLine(istOk);

            // Schritt 4: Sync im Haupt-Thread (blockierend)
            var temperatur = HoleTemperaturVonWetterDienst();

            // Schritt 5: Sync im Haupt-Thread (blockierend)
            Console.WriteLine(temperatur);

            // Schritt 6: Sync im Haupt-Thread (blockierend)
            SageAufwiederschaun();


            // Die Methoden
            bool Schreibe5000DatensätzeInDb()
            {
                Console.WriteLine("Schreibe 5.000 Datensätze in Db und blockiere den Thread...");
                Thread.Sleep(2000);
                return true;
            }

            void GebeMessageAus()
            {
                Console.WriteLine("Willkommen hier");
            }

            double HoleTemperaturVonWetterDienst()
            {
                Console.WriteLine("Hole Lufttemperatur und blockiere den Thread...");
                Thread.Sleep(2000);
                return 15.5;
            }

            void SageAufwiederschaun()
            {
                Console.WriteLine("Aufwiederschaun");
            }
        }


        public static async Task MachAllesAsync()
        {
            // Shcritt 1: Sync blockierend im Haupt-Thread
            GebeMessageAus();

            // Schritt 2: Ayync in neuem Thread / =blockiert nicht den Haupt-Thread
            var istOk = await Schreibe5000DatensätzeInDbAsync();

            // Schritt 3: Sync blockierend im Haupt-Thread
            Console.WriteLine(istOk);

            // Schritt 4: Async in neuem Thread / =blockiert nicht den Haupt-Thread
            var temperatur = await HoleTemperaturVonWetterDienstAsync();

            // Shcritt 5: Sync blockierend im Haupt-Thread
            Console.WriteLine(temperatur);

            // Schritt 6: Sync blockierend im Haupt-Thread
            SageAufwiederschaun();


            // Die Methoden
            async Task<bool> Schreibe5000DatensätzeInDbAsync()
            {
                Console.WriteLine("Schreibe 5.0000 Datensätze in Db und blockiere niemanden....");
                await Task.Delay(2000);
                return true;
            }

            void GebeMessageAus()
            {
                Console.WriteLine("Willkommen hier");
            }

            async Task<double> HoleTemperaturVonWetterDienstAsync()
            {
                Console.WriteLine("Hole Lufttemperatur und blockiere niemanden....");
                await Task.Delay(2000);
                return 15.5;
            }

            void SageAufwiederschaun()
            {
                Console.WriteLine("Aufwiederschaun");
            }
        }

        public static async Task FrühstückParallelAsync()
        {
            Console.WriteLine("Frühstücksvorbereitung gestartet...");

            // Starten der Aufgaben "gleichzeitig"
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
        public static async Task BildDownLoaderParallelAsync()
        {
            List<string> urls = new List<string>
                    {
                        "https://upload.wikimedia.org/wikipedia/commons/5/52/Bee_on_Echinacea.jpg",
                        "https://upload.wikimedia.org/wikipedia/commons/d/df/Eiche_auf_der_Pfaueninsel.jpg",
                        "https://upload.wikimedia.org/wikipedia/commons/2/20/Odenthal_Ortszentrum_Pfarrhaus.jpg",
                        "https://wallpapercave.com/wp/wp3250252.jpg"

                    };
            Console.WriteLine("Starte Webanfragen...");

            // Stoppuhr starten
            var mainStopwatch = Stopwatch.StartNew();

            var tasks = new List<Task<long>>();
            foreach (var url in urls)
            {
                // Tasks (= Aufrufe von Download-Methode) in Liste hinzufügen
                tasks.Add(Download(url));
            }
            // Warten auf alle Anfragen und Messzeit als Rückgabe zurück bekommen
            long[] antwortzeiten = await Task.WhenAll(tasks);

            mainStopwatch.Stop();

            for (int i = 0; i < urls.Count; i++)
                Console.WriteLine($"Antwortzeit für {GetBildname(urls[i])}: {antwortzeiten[i]} ms");

            Console.WriteLine($"Alle Anfragen abgeschlossen in {mainStopwatch.ElapsedMilliseconds} ms");

            static async Task<long> Download(string url)
            {
                // instanziere einen virtullen "Browser", der sich mit using selbst aus dem Speicher entferrnt
                using var httpClient = new HttpClient();
                // Header UserAgent hinzufügen, um menschlichen User zu emulieren
                httpClient.DefaultRequestHeaders
                    .UserAgent
                    .ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36");

                var stopwatch = Stopwatch.StartNew();
                // Binäre Datei ist in C# als Byte-Array abbildbar
                byte[] bild = await httpClient.GetByteArrayAsync(url);
                stopwatch.Stop();

                var gesamtZeit = stopwatch.ElapsedMilliseconds;

                // Blockiere den Haupt-Thrad nicht und schreibe die Datei in separatem Task
                await File.WriteAllBytesAsync(GetBildname(url), bild);

                return gesamtZeit;
            }

            static string GetBildname(string url) => url.Split('/').Last();
        }
    }
}
