using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;
public class PlaneDetailConfiguration : IEntityTypeConfiguration<PlaneDetail>
{
    public void Configure(EntityTypeBuilder<PlaneDetail> entity)
    {
        entity.HasKey(e => e.PlaneId).HasName("PK_PD_PlaneId");

        entity.ToTable("PlaneDetail");

        entity.HasIndex(e => e.RegistrationNo, "UK_RegNO").IsUnique();

        entity.Property(e => e.PlaneId).HasColumnName("PlaneID");
        entity.Property(e => e.ModelNumber)
            .HasMaxLength(10)
            .IsUnicode(false);
        entity.Property(e => e.RegistrationNo)
            .HasMaxLength(10)
            .IsUnicode(false);

        entity.HasOne(d => d.PlaneModel).WithMany(p => p.PlaneDetails)
            .HasForeignKey(d => d.ModelNumber)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ModelN");

        entity.HasData(
            new () { PlaneId = 1, ModelNumber = "A390", RegistrationNo = "AU-1989", BuiltYear = 1989, EcoCapacity = 50, FirstClassCapacity = 50},
            new () { PlaneId = 2, ModelNumber = "A380", RegistrationNo = "AU-2000", BuiltYear = 2000, EcoCapacity = 200, FirstClassCapacity = 100},
            new () { PlaneId = 3, ModelNumber = "A300", RegistrationNo = "AU-1970", BuiltYear = 1970, EcoCapacity = 350, FirstClassCapacity = 200},
            new () { PlaneId = 4, ModelNumber = "A340", RegistrationNo = "AU-1880", BuiltYear = 1880, EcoCapacity = 420, FirstClassCapacity = 310},
            new () { PlaneId = 5, ModelNumber = "A390", RegistrationNo = "AU-1990", BuiltYear = 1990, EcoCapacity = 230, FirstClassCapacity = 110},
            new () { PlaneId = 6, ModelNumber = "737", RegistrationNo = "BO-2001", BuiltYear = 2001, EcoCapacity = 120, FirstClassCapacity = 40},
            new () { PlaneId = 7, ModelNumber = "777", RegistrationNo = "BO-1990", BuiltYear = 1990, EcoCapacity = 450, FirstClassCapacity = 155},
            new () { PlaneId = 8, ModelNumber = "779", RegistrationNo = "BO-2002", BuiltYear = 2002, EcoCapacity = 244, FirstClassCapacity = 121},
            new () { PlaneId = 9, ModelNumber = "787", RegistrationNo = "BO-2005", BuiltYear = 2005, EcoCapacity = 340, FirstClassCapacity = 195},
            new () { PlaneId = 10, ModelNumber = "787", RegistrationNo = "BO-2005-1", BuiltYear = 2005, EcoCapacity = 140, FirstClassCapacity = 95}
        );
    }
}