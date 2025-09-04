using ChartClienseitigDemo.Data;
using ChartClienseitigDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChartClienseitigDemo.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UmsatzApiController : ControllerBase
    {
        private readonly UmsatzDbContext _dbContext;

        public UmsatzApiController(UmsatzDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Umsatz> daten = _dbContext.Umsaetze.ToList();

            var ergebnis = new List<object>();
            foreach (var eintrag in daten)
            {
                ergebnis.Add(new { monat = eintrag.Monat, betrag = eintrag.Betrag });
            }

            return Ok(ergebnis);
        }
    }
}
