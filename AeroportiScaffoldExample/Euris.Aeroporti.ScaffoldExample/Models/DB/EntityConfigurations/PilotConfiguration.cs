using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB.EntityConfigurations;
public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
{
    public void Configure(EntityTypeBuilder<Pilot> entity)
    {
        entity.ToTable("Piloti")
            .HasKey(e => e.Id).HasName("PK_PilotId");
        entity.Property(e => e.Id)
            .HasColumnName("Id")
            .HasMaxLength(8)
            .IsRequired();
        entity.Property(x => x.Name)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();
        entity.Property(x => x.Surname)
            .HasColumnName("Cognome")
            .HasMaxLength(50)
            .IsRequired();
        entity.Property(x => x.DateOfBirth)
            .HasColumnName("DataDiNascita");

        entity.HasData(
            new List<Pilot>()
            {
                new Pilot()
                {
                    Id = "P1",
                    Name = "Mario",
                    Surname = "Rossi"
                }
            }
            );
    }
}