using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;
public class PilotConfiguration : IEntityTypeConfiguration<Pilot>
{
    public void Configure(EntityTypeBuilder<Pilot> entity)
    {
        entity.HasKey(e => e.PilotId).HasName("PK_P_PilotId");

        entity.ToTable("Pilot");

        entity.Property(e => e.PilotId).HasColumnName("PilotID");
        entity.Property(e => e.Dob)
            .HasColumnType("date")
            .HasColumnName("DOB");
        entity.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsUnicode(false);

        entity.HasMany(d => d.PlaneModels).WithMany(p => p.Pilots)
            .UsingEntity<Dictionary<string, object>>(
                "PlanePilot",
                r => r.HasOne<PlaneModel>().WithMany()
                    .HasForeignKey("PlaneModel")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_PlaneModel"),
                l => l.HasOne<Pilot>().WithMany()
                    .HasForeignKey("PilotId")
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_PilotID"),
                j =>
                {
                    j.HasKey("PilotId", "PlaneModel").HasName("PK_PlanePilot");
                    j.ToTable("PlanePilot");
                    j.IndexerProperty<int>("PilotId").HasColumnName("PilotID");
                    j.IndexerProperty<string>("PlaneModel")
                        .HasMaxLength(10)
                        .IsUnicode(false);
                });
    }
}