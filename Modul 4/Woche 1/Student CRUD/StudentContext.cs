using Microsoft.EntityFrameworkCore;

namespace Student_CRUD
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;


        public StudentContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Sandbox;Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;TrustServerCertificate=true");
    }
}
