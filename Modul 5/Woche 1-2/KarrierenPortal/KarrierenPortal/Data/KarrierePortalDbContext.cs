using System;
using System.Collections.Generic;
using KarrierenPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace KarrierenPortal.Data;

public partial class KarrierePortalDbContext : DbContext
{
    public KarrierePortalDbContext()
    {
    }

    public KarrierePortalDbContext(DbContextOptions<KarrierePortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arbeitgeber> Arbeitgebers { get; set; }

    public virtual DbSet<ArbeitgeberBenefit> ArbeitgeberBenefits { get; set; }

    public virtual DbSet<Arbeitsort> Arbeitsorts { get; set; }

    public virtual DbSet<Arbeitszeitmodell> Arbeitszeitmodells { get; set; }

    public virtual DbSet<Benachrichtigung> Benachrichtigungs { get; set; }

    public virtual DbSet<Benefit> Benefits { get; set; }

    public virtual DbSet<BetriebsGroesse> BetriebsGroesses { get; set; }

    public virtual DbSet<Bewerber> Bewerbers { get; set; }

    public virtual DbSet<Bewerbung> Bewerbungs { get; set; }

    public virtual DbSet<BewerbungStatus> BewerbungStatuses { get; set; }

    public virtual DbSet<Branche> Branches { get; set; }

    public virtual DbSet<GehaltsSpanne> GehaltsSpannes { get; set; }

    public virtual DbSet<JobAngebot> JobAngebots { get; set; }

    public virtual DbSet<Land> Lands { get; set; }

    public virtual DbSet<Lebenslauf> Lebenslaufs { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=KarrierePortalDB;Data Source=DESKTOP-KCGE85K\\SQLEXPRESS;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arbeitgeber>(entity =>
        {
            entity.ToTable("Arbeitgeber");

            entity.Property(e => e.Adresse).HasMaxLength(25);
            entity.Property(e => e.Ansprechpartner).HasMaxLength(25);
            entity.Property(e => e.Beschreibung).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("EMail");
            entity.Property(e => e.ErstelltAm).HasColumnType("datetime");
            entity.Property(e => e.LandCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Ort).HasMaxLength(25);
            entity.Property(e => e.Plz).HasMaxLength(5);
            entity.Property(e => e.Telefonnummer).HasMaxLength(25);
            entity.Property(e => e.Webseite).HasMaxLength(25);

            entity.HasOne(d => d.BetriebsGroesse).WithMany(p => p.Arbeitgebers)
                .HasForeignKey(d => d.BetriebsGroesseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Arbeitgeber_BetriebsGroesse");

            entity.HasOne(d => d.Branche).WithMany(p => p.Arbeitgebers)
                .HasForeignKey(d => d.BrancheId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Arbeitgeber_Branche");

            entity.HasOne(d => d.LandCodeNavigation).WithMany(p => p.Arbeitgebers)
                .HasForeignKey(d => d.LandCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Arbeitgeber_Land");
        });

        modelBuilder.Entity<ArbeitgeberBenefit>(entity =>
        {
            entity.HasKey(e => new { e.ArbeitgeberId, e.BenefitId });

            entity.ToTable("ArbeitgeberBenefit");

            entity.HasOne(d => d.Arbeitgeber)
                .WithMany(p => p.ArbeitgeberBenefits)
                .HasForeignKey(d => d.ArbeitgeberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArbeitgeberBenefit_Arbeitgeber");

            entity.HasOne(d => d.BenefitNavigation)
                .WithMany(p => p.ArbeitgeberBenefits)
                .HasForeignKey(d => d.BenefitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArbeitgeberBenefit_Benefit");
        });

        modelBuilder.Entity<Arbeitsort>(entity =>
        {
            entity.ToTable("Arbeitsort");

            entity.Property(e => e.Beschreibung).HasMaxLength(20);
        });

        modelBuilder.Entity<Arbeitszeitmodell>(entity =>
        {
            entity.ToTable("Arbeitszeitmodell");

            entity.Property(e => e.Beschreibung).HasMaxLength(20);
        });

        modelBuilder.Entity<Benachrichtigung>(entity =>
        {
            entity.ToTable("Benachrichtigung");

            entity.Property(e => e.ErstelltAm).HasColumnType("datetime");
            entity.Property(e => e.Text).HasMaxLength(200);

            entity.HasOne(d => d.Bewerber).WithMany(p => p.Benachrichtigungs)
                .HasForeignKey(d => d.BewerberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Benachrichtigung_Bewerber");
        });

        modelBuilder.Entity<Benefit>(entity =>
        {
            entity.ToTable("Benefit");

            entity.Property(e => e.Beschreibung).HasMaxLength(50);
        });

        modelBuilder.Entity<BetriebsGroesse>(entity =>
        {
            entity.ToTable("BetriebsGroesse");

            entity.Property(e => e.Beschreibung).HasMaxLength(25);
        });

        modelBuilder.Entity<Bewerber>(entity =>
        {
            entity.ToTable("Bewerber");

            entity.Property(e => e.Adresse).HasMaxLength(25);
            entity.Property(e => e.Email).HasMaxLength(25);
            entity.Property(e => e.ErstelltAm)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.LandCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nachname).HasMaxLength(25);
            entity.Property(e => e.Ort).HasMaxLength(25);
            entity.Property(e => e.Plz)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Telefonnummer).HasMaxLength(25);
            entity.Property(e => e.Vorname).HasMaxLength(25);
            entity.Property(e => e.Webseite).HasMaxLength(25);

            entity.HasOne(d => d.LandCodeNavigation).WithMany(p => p.Bewerbers)
                .HasForeignKey(d => d.LandCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bewerber_Land");

            entity.HasMany(d => d.Skills).WithMany(p => p.Bewerbers)
                .UsingEntity<Dictionary<string, object>>(
                    "BewerberSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BewerberSkill_Skill"),
                    l => l.HasOne<Bewerber>().WithMany()
                        .HasForeignKey("BewerberId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_BewerberSkill_Bewerber"),
                    j =>
                    {
                        j.HasKey("BewerberId", "SkillId").HasName("PK_Table_1");
                        j.ToTable("BewerberSkill");
                    });
        });

        modelBuilder.Entity<Bewerbung>(entity =>
        {
            entity.ToTable("Bewerbung");

            entity.HasIndex(e => new { e.JobAngebotId, e.BewerbungId }, "UC_JobAngebot_Bewerbung").IsUnique();

            entity.Property(e => e.BewerbungId).ValueGeneratedOnAdd();
            entity.Property(e => e.ErstelltAm).HasColumnType("datetime");

            entity.HasOne(d => d.BewerbungNavigation).WithOne(p => p.Bewerbung)
                .HasForeignKey<Bewerbung>(d => d.BewerbungId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bewerbung_Bewerber1");

            entity.HasOne(d => d.BewerbungStatus).WithMany(p => p.Bewerbungs)
                .HasForeignKey(d => d.BewerbungStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bewerbung_Bewerber");

            entity.HasOne(d => d.JobAngebot).WithMany(p => p.Bewerbungs)
                .HasForeignKey(d => d.JobAngebotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bewerbung_JobAngebot");
        });

        modelBuilder.Entity<BewerbungStatus>(entity =>
        {
            entity.ToTable("BewerbungStatus");

            entity.Property(e => e.Beschreibung).HasMaxLength(20);
        });

        modelBuilder.Entity<Branche>(entity =>
        {
            entity.ToTable("Branche");

            entity.Property(e => e.Beschreibung).HasMaxLength(25);
        });

        modelBuilder.Entity<GehaltsSpanne>(entity =>
        {
            entity.ToTable("GehaltsSpanne");

            entity.Property(e => e.Beschreibung).HasMaxLength(25);
        });

        modelBuilder.Entity<JobAngebot>(entity =>
        {
            entity.ToTable("JobAngebot");

            entity.Property(e => e.ErstalltAm)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Titel).HasMaxLength(40);

            entity.HasOne(d => d.Arbeitgeber).WithMany(p => p.JobAngebots)
                .HasForeignKey(d => d.ArbeitgeberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_JobAngebot_Arbeitgeber");

            entity.HasOne(d => d.Arbeitsort).WithMany(p => p.JobAngebots)
                .HasForeignKey(d => d.ArbeitsortId)
                .HasConstraintName("FK_JobAngebot_Arbeitsort");

            entity.HasOne(d => d.Arbeitszeitmodell).WithMany(p => p.JobAngebots)
                .HasForeignKey(d => d.ArbeitszeitmodellId)
                .HasConstraintName("FK_JobAngebot_Arbeitszeitmodell");

            entity.HasOne(d => d.GehaltsSpanne).WithMany(p => p.JobAngebots)
                .HasForeignKey(d => d.GehaltsSpanneId)
                .HasConstraintName("FK_JobAngebot_GehaltsSpanne");

            entity.HasMany(d => d.Skills).WithMany(p => p.JobAngebots)
                .UsingEntity<Dictionary<string, object>>(
                    "JobAngebotSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_JobAngebotSkill_Skill"),
                    l => l.HasOne<JobAngebot>().WithMany()
                        .HasForeignKey("JobAngebotId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_JobAngebotSkill_JobAngebot"),
                    j =>
                    {
                        j.HasKey("JobAngebotId", "SkillId").HasName("PK_Table_1x");
                        j.ToTable("JobAngebotSkill");
                    });
        });

        modelBuilder.Entity<Land>(entity =>
        {
            entity.HasKey(e => e.LandCode).HasName("PK_Land_1");

            entity.ToTable("Land");

            entity.Property(e => e.LandCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(25);
        });

        modelBuilder.Entity<Lebenslauf>(entity =>
        {
            entity.HasKey(e => e.LebenslaufId).HasName("PK_BewerberDokument");

            entity.ToTable("Lebenslauf");

            entity.HasIndex(e => e.BewerberId, "IX_Lebenslauf").IsUnique();

            entity.HasOne(d => d.Bewerber).WithOne(p => p.Lebenslauf)
                .HasForeignKey<Lebenslauf>(d => d.BewerberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lebenslauf_Bewerber");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.ToTable("Skill");

            entity.Property(e => e.Beschreibung).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
