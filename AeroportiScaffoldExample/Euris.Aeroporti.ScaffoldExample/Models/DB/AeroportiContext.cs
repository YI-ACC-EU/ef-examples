using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Euris.Aeroporti.ScaffoldExample.Models.DB.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB;

public partial class AeroportiContext : DbContext
{
    public AeroportiContext()
    {
    }

    public AeroportiContext(DbContextOptions<AeroportiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Plains> Plains { get; set; }

    public virtual DbSet<Aeroporto> Airports { get; set; }

    public virtual DbSet<Volo> Flights { get; set; }

    public virtual DbSet<Pilot> Pilots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer("Data Source=127.0.0.1;Initial Catalog=AeroportiTest; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlainsConfiguration());
        modelBuilder.ApplyConfiguration(new PilotConfiguration());

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.ToTable("Aeroporto");
            entity.Property(e => e.Citta).HasMaxLength(50);
            entity.HasKey(e => e.Citta).HasName("PK__Aeroport__878CD512E0D2AF38");
            entity.Property(e => e.Nazione).HasMaxLength(50);
        });

        modelBuilder.Entity<Volo>(entity =>
        {
            entity.HasKey(e => e.IdVolo).HasName("PK__Volo__550D6D6DF0B59EAD");
            entity.ToTable("Volo");
            entity.Property(e => e.IdVolo).HasMaxLength(10);
            entity.Property(e => e.CittaArr).HasMaxLength(50);
            entity.Property(e => e.CittaPart).HasMaxLength(50);
            entity.Property(e => e.GiornoSett).HasMaxLength(20);
            entity.Property(e => e.TipoAereo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.CittaArrNavigation).WithMany(p => p.VoloCittaArrNavigations)
                .HasForeignKey(d => d.CittaArr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volo__CittaArr__2E1BDC42");

            entity.HasOne(d => d.CittaPartNavigation).WithMany(p => p.VoloCittaPartNavigations)
                .HasForeignKey(d => d.CittaPart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volo__CittaPart__2D27B809");

            entity.HasOne(d => d.TipoPlainsNavigation).WithMany(p => p.Flights)
                .HasForeignKey(d => d.TipoAereo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Volo__TipoAereo__2F10007B");

            entity
                .HasMany(x => x.PilotsNavigation)
                .WithMany(x => x.Flights)
                .UsingEntity(

                    "PilotaVolo", 
                    l =>l.HasOne(typeof(Pilot))
                                .WithMany()
                                .HasForeignKey("FK_PilotaVolo_Pilota")
                                .HasPrincipalKey(nameof(Pilot.Id))
                    ,
                    r => r.HasOne(typeof(Volo))
                        .WithMany()
                        .HasForeignKey("FK_PilotaVolo_Volo")
                        .HasPrincipalKey(nameof(Volo.IdVolo)));

        });
     
        
        OnModelCreatingPartial(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        //configurationBuilder
        //    .Properties<string>()
        //    .HaveMaxLength(254);

        base.ConfigureConventions(configurationBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
