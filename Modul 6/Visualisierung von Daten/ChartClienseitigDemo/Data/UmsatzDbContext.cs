using ChartClienseitigDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ChartClienseitigDemo.Data
{
    public class UmsatzDbContext : DbContext
    {
        public UmsatzDbContext(DbContextOptions<UmsatzDbContext> options) : base(options) { }
        public DbSet<Umsatz> Umsaetze {  get; set; }
    }
}
