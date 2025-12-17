using DiDemo.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiDemo.Controllers
{
    public class HomeController : Controller
    {
        // ----------------------------------------------
        // Der Controller benötigt den Dienst.
        // Die Variable speichert die Instanz,
        // die der DI-Container bereitstellt.
        // ----------------------------------------------
        private readonly IHalloDienst _halloDienst;

        // -----------------------------------------------------------
        // Konstruktorinjektion:
        // ASP.NET Core sucht automatisch nach einem registrierten
        // Service, der IHalloDienst implementiert.
        // Dann übergibt es diesen hier in den Konstruktor.
        // -----------------------------------------------------------
        public HomeController(IHalloDienst halloDienst)
        {
            _halloDienst = halloDienst;
        }

        public IActionResult Index()
        {
            // --------------------------------------------------------
            // Der injizierte Dienst wird verwendet,
            // um eine Begrüßungsnachricht zu erzeugen.
            // --------------------------------------------------------
            var nachricht = _halloDienst.ErzeugeBegruessung("Max Mustermann");

            // --------------------------------------------------------
            // Die Nachricht wird an die View weitergegeben.
            // Das Modell der View ist also ein einfacher String.
            // --------------------------------------------------------
            return View(model: nachricht);
        }
    }
}
