using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;
public class PlaneModelConfiguration : IEntityTypeConfiguration<PlaneModel>
{
    public void Configure(EntityTypeBuilder<PlaneModel> entity)
    {
        entity.HasKey(e => e.ModelNumber).HasName("PK_PM_ModelN");
        entity.ToTable("PlaneModel");
        entity.Property(e => e.ModelNumber)
            .HasMaxLength(10)
            .IsUnicode(false);
        entity.Property(e => e.ManufacturerName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.HasData(
            new () { ModelNumber = "737", ManufacturerName = "Boeing", CruiseSpeed = 780, PlaneRange = 5600}, 
            new () { ModelNumber = "777", ManufacturerName = "Boeing", CruiseSpeed = 892, PlaneRange = 10000}, 
            new () { ModelNumber = "779", ManufacturerName = "Boeing", CruiseSpeed = 922, PlaneRange = 17000}, 
            new () { ModelNumber = "787", ManufacturerName = "Boeing", CruiseSpeed = 903, PlaneRange = 15000}, 
            new () { ModelNumber = "A300", ManufacturerName = "Airbus", CruiseSpeed = 871, PlaneRange = 13450}, 
            new () { ModelNumber = "A340", ManufacturerName = "Airbus", CruiseSpeed = 881, PlaneRange = 12400}, 
            new () { ModelNumber = "A380", ManufacturerName = "Airbus", CruiseSpeed = 900, PlaneRange = 15700}, 
            new () { ModelNumber = "A390", ManufacturerName = "Airbus", CruiseSpeed = 1081, PlaneRange = 17400}
            );
    }
}