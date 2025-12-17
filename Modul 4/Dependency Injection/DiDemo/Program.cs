using DiDemo.Models.Interfaces;
using DiDemo.Models;

namespace DiDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ------------------------------------------------------
            // Hier wird das MVC-Framework im DI-Container registriert.
            // AddControllersWithViews() sorgt dafür, dass Controller
            // und Views verwendbar sind.
            // ------------------------------------------------------
            builder.Services.AddControllersWithViews();

            // ------------------------------------------------------
            // Registrierung unseres eigenen Dienstes.
            // IHalloDienst = Interface
            // HalloDienst  = Implementierung
            //
            // AddScoped bedeutet:
            // Für jede HTTP-Anfrage wird genau eine Instanz erstellt.
            // ------------------------------------------------------
            builder.Services.AddScoped<IHalloDienst, HalloDienst>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
