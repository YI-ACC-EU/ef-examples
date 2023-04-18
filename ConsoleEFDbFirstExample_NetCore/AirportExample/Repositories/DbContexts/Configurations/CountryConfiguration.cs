using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> entity)
    {
        entity.HasKey(e => e.CountryCode).HasName("PK_Country");

        entity.ToTable("Country");

        entity.HasIndex(e => e.CountryName, "UK_CountryName").IsUnique();

        entity.Property(e => e.CountryCode)
            .HasMaxLength(3)
            .IsUnicode(false)
            .IsFixedLength();
        entity.Property(e => e.CountryName)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasData(
            new() { CountryCode = "AUS", CountryName = "Australia" }, 
            new() { CountryCode = "AUT", CountryName = "Austria" }, 
            new() { CountryCode = "BEL", CountryName = "Belgium" }, 
            new() { CountryCode = "BRA", CountryName = "Brazil" }, 
            new() { CountryCode = "CAN", CountryName = "Canada" }, 
            new() { CountryCode = "CHN", CountryName = "China" }, 
            new() { CountryCode = "ENG", CountryName = "England" }, 
            new() { CountryCode = "GER", CountryName = "Germany" }, 
            new() { CountryCode = "NPl", CountryName = "Nepal" }, 
            new() { CountryCode = "NZL", CountryName = "New Zealand" }, 
            new() { CountryCode = "POR", CountryName = "Portugal" }, 
            new() { CountryCode = "ESP", CountryName = "Spain" }, 
            new() { CountryCode = "SWE", CountryName = "Sweden" }, 
            new() { CountryCode = "UAE", CountryName = "United Arab Emirates" }, 
            new() { CountryCode = "USA", CountryName = "United States of America" });
    }
}