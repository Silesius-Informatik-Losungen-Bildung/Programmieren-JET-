using Microsoft.EntityFrameworkCore;

namespace EFC
{
    internal class SandboxContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;Initial Catalog=Sandbox;Integrated Security=True;Encrypt=False");
    }
}
