using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

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

        if (!_cache.TryGetValue(cacheKey, out string? cachedTime))
        {
            cachedTime = DateTime.Now.ToString("HH:mm:ss");
            var options = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30));
            _cache.Set(cacheKey, cachedTime, options);
        }

        ViewBag.CachedTime = cachedTime;
        return View();
    }
}
