using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace MemoryCacheDemoApp.Controllers;

public class HomeController : Controller
{
    private readonly IMemoryCache _cache;

    public HomeController(IMemoryCache cache)
    {
        _cache = cache;
    }

    public IActionResult Index()
    {
        const string cacheKey = "current_time";

        // Prüft, ob unter dem angegebenen cacheKey bereits ein Eintrag im Cache existiert.
        // Falls kein Eintrag vorhanden ist, gibt TryGetValue false zurück
        // und cachedTime bleibt zunächst null.
        if (!_cache.TryGetValue(cacheKey, out string? cachedTime))
        {
            // Falls kein Cache-Eintrag existiert:
            // Aktuelle Uhrzeit wird als String (HH:mm:ss) erzeugt
            cachedTime = DateTime.Now.ToString("HH:mm:ss");

            // Erzeugt Cache-Optionen mit Sliding Expiration:
         

            // Erstellt ein neues Objekt zur Konfiguration eines Cache-Eintrags.
            // In diesem Objekt werden unter anderem Ablaufregeln (Expiration) festgelegt.
            var options = new MemoryCacheEntryOptions();


            // Der Cache-Eintrag läuft nach 30 Sekunden ab,
            // WENN innerhalb dieser Zeit kein erneuter Zugriff erfolgt.
            // Jeder Zugriff setzt den 30-Sekunden-Timer zurück.
            options.SetSlidingExpiration(TimeSpan.FromSeconds(30));


            //// Setzt eine Absolute Expiration relativ zum aktuellen Zeitpunkt:
            //// Der Cache-Eintrag ist exakt 30 Sekunden gültig und wird danach automatisch entfernt.
            //// Zugriffe auf den Cache-Eintrag verlängern diese Zeit NICHT.
            //options.SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

            // Speichert die Uhrzeit im Cache unter dem cacheKey
            // zusammen mit den definierten Cache-Optionen
            _cache.Set(cacheKey, cachedTime, options);
        }


        ViewBag.CachedTime = cachedTime;
        return View();
    }
}
