using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;

public class FlightConfiguration: IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> entity)
    {
        entity.HasKey(e => e.FlightNo).HasName("PK_FlightNo");
        entity.ToTable("Flight");

        entity.Property(e => e.FlightNo)
            .HasMaxLength(10)
            .IsUnicode(false);
        entity.Property(e => e.FlightArriveFromId)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.FlightDepartToId)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength();

        entity.HasOne(d => d.ArriveFrom).WithMany(x=>x.FlightArriveFrom)
            .HasForeignKey(d => d.FlightArriveFromId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_F_FlightArriveFrom");

        entity.HasOne(d => d.DepartTo).WithMany(x=>x.FlightDepartTo)
            .HasForeignKey(d => d.FlightDepartToId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_F_FlightDepartTo");
    }
}