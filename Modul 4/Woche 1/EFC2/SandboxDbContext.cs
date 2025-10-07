using Microsoft.EntityFrameworkCore;

namespace EFC2
{
    public class SandboxDbContext: DbContext
    {
       public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;Initial Catalog=Sandbox;Integrated Security=True;Encrypt=False";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
