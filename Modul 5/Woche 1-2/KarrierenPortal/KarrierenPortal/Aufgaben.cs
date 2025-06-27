using KarrierenPortal.Data;
using Microsoft.EntityFrameworkCore;

namespace KarrierenPortal
{
    public class Aufgaben
    {
        public static void Alles()
        {
            using KarrierePortalDbContext context = new KarrierePortalDbContext();

            // 1. Nur Arbeitgeber mit Benefits anzeigen (Arbeitgeber und Benefits sind anzuzeigen)
            var arbeitgeber = context.Arbeitgebers
                .Include(a => a.ArbeitgeberBenefits)
                    .ThenInclude(e => e.BenefitNavigation)
                .Where(w => w.ArbeitgeberBenefits.Any())
                .ToList();

            foreach (var a in arbeitgeber)
            {
                Console.Write(a.Name + ": ");
                foreach (var b in a.ArbeitgeberBenefits)
                {
                    Console.Write(", " + b.BenefitNavigation.Beschreibung);
                }
                Console.WriteLine();
            }

            // 2. Bewerber mit C#
            var bewerberMitCSharp = context.Bewerbers
                .Include(a => a.Skills)
                .Where(b => b.Skills.Any(s => s.Beschreibung.IndexOf("C#") > -1))
                .ToList();
            Console.WriteLine("2. Bewerber mit Skill 'C#':");
            foreach (var b in bewerberMitCSharp)
                Console.WriteLine($"{b.Vorname} {b.Nachname}");

            // 3. Bewerbungen im aktuellen Monat
            var jetzt = DateTime.Now;
            var aktuelleBewerbungen = context.Bewerbungs
                .Where(b => b.ErstelltAm.Month == jetzt.Month && b.ErstelltAm.Year == jetzt.Year)
                .ToList();
            Console.WriteLine("3. Aktuelle Bewerbungen:");
            foreach (var b in aktuelleBewerbungen)
                Console.WriteLine($"Bewerbung ID: {b.BewerbungId}, Datum: {b.ErstelltAm}");

            // 4. Durchschnittliche Jobangebote pro Arbeitgeber
            var avgCount = context.JobAngebots
                .GroupBy(j => j.ArbeitgeberId)
                .Select(g => g.Count())
                .ToList()
                .Average();
            Console.WriteLine($"4. Durchschnitt Jobangebote pro Arbeitgeber: {avgCount:F2}");

            // 5. Jobangebote mit baldiger Frist
            var deadline = DateTime.Today.AddDays(7);
            var baldAblaufendeAngebote = context.JobAngebots
                .Where(j => j.Bewerbungsfrist != null && j.Bewerbungsfrist <= DateOnly.FromDateTime(deadline) && j.Aktiv)
                .ToList();
            Console.WriteLine("5. Bald ablaufende Jobangebote:");
            foreach (var j in baldAblaufendeAngebote)
                Console.WriteLine($"{j.Titel} endet am {j.Bewerbungsfrist}");


            // 6. Arbeitgeber ohne aktive Jobangebote
            var arbeitgeberOhneAngebote = context.Arbeitgebers
                .Where(a => !a.JobAngebots.Any(j => j.Aktiv))
                .ToList();
            Console.WriteLine("6. Arbeitgeber ohne aktive Angebote:");
            foreach (var a in arbeitgeberOhneAngebote)
                Console.WriteLine(a.Name);

            // 7. Top 3 Städte mit Jobangeboten
            var topOrte = context.JobAngebots
               .Where(j => j.Arbeitgeber != null)
               .Select(j => j.Arbeitgeber.Ort)
               .GroupBy(ort => ort)
               .Select(g => new { Ort = g.Key, Anzahl = g.Count() })
               .OrderByDescending(g => g.Anzahl)
               .Take(3)
               .ToList();
            Console.WriteLine("7. Top 3 Orte mit Jobangeboten:");
            foreach (var ort in topOrte)
                Console.WriteLine($"{ort.Ort}: {ort.Anzahl}");
        }
    }
}
