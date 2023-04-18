using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> entity)
    {
        entity.HasKey(e => e.AirportCode).HasName("PK_Airport");

        entity.ToTable("Airport");

        entity.Property(e => e.AirportCode)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.AirportName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.ContactNo).HasColumnType("numeric(18, 0)");
        entity.Property(e => e.CountryCode)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength();

        entity.HasOne(d => d.Country).WithMany(p => p.Airports)
            .HasForeignKey(d => d.CountryCode)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CountryCode");

        entity.HasMany(d => d.FlightArriveFrom)
            .WithOne(x => x.ArriveFrom)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_A_FlightsArriveFrom");

        entity.HasMany(d => d.FlightDepartTo)
            .WithOne(x => x.DepartTo)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_F_FlightDepartTo");
    }
}