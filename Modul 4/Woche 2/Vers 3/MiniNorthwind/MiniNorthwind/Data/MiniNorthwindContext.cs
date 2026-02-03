using Microsoft.EntityFrameworkCore;
using MiniNorthwind.Models;

namespace MiniNorthwind.Data;

public partial class MiniNorthwindContext : DbContext
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Supplier> Suppliers { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=MiniNorthwind;Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;TrustServerCertificate=true");
    }
}
