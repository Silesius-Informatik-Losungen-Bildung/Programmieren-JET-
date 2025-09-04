using ChartServerseitigDemo.Data;
using Microsoft.AspNetCore.Mvc;
using ScottPlot;

namespace ChartServerseitigDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UmsatzDbContext _dbContext;

        public HomeController(UmsatzDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChartImage()
        {
            var daten = _dbContext.Umsaetze.ToList();
            var plot = new Plot();
            plot.Axes.Margins(bottom: 0);
            plot.Title("Umsatz je Monat");
            plot.YLabel("EUR");
            plot.XLabel("Monat");

            double[] dataX = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            double[] dataY = daten.Select(u => (double)u.Betrag).ToArray();
            plot.Add.Scatter(dataX, dataY);

            Image img = plot.GetImage(width: 600, height: 400);
            return File(img.GetImageBytes(), "image/png");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
