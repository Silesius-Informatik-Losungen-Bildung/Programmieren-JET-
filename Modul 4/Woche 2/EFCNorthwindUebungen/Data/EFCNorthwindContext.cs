using EFCNorthwindUebungen.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCNorthwindUebungen.Data
{
    public class EFCNorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer($"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=EFCNorthwind;Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;TrustServerCertificate=true");
        }
    }

}
