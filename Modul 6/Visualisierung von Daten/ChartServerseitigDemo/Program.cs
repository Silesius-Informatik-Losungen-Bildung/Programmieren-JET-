using ChartServerseitigDemo.Data;
using Microsoft.EntityFrameworkCore;
using ChartServerseitigDemo.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// DbContext registrieren (InMemory)
builder.Services.AddDbContext<UmsatzDbContext>(options =>
    options.UseInMemoryDatabase("UmsatzDb"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Demo-Daten sicherstellen
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UmsatzDbContext>();
    if (db.Umsaetze.Any()) return;
    var currentInfo = new CultureInfo("de-at");
    var daten = new[] {
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(1), Betrag = 12000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(2), Betrag = 15000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(3), Betrag = 9000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(4), Betrag = 18000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(5), Betrag = 21000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(6), Betrag = 17500 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(7), Betrag = 16000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(8), Betrag = 19500 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(9), Betrag = 22000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(10), Betrag = 14000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(11), Betrag = 25000 },
                new Umsatz { Monat = currentInfo.DateTimeFormat.GetAbbreviatedMonthName(12), Betrag = 12500 },
            };

    db.Umsaetze.AddRange(daten);
    db.SaveChanges();
}

app.Run();
