using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;
public class FlightAttendantConfiguration : IEntityTypeConfiguration<FlightAttendant>
{
    public void Configure(EntityTypeBuilder<FlightAttendant> entity)
    {
        entity.HasKey(e => e.AttendantId).HasName("PK_FA_AttendantID");

        entity.ToTable("FlightAttendant");

        entity.Property(e => e.AttendantId).HasColumnName("AttendantID");
        entity.Property(e => e.Dob)
            .HasColumnType("date")
            .HasColumnName("DOB");
        entity.Property(e => e.FirstName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.HireDate).HasColumnType("date");
        entity.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsUnicode(false);
        entity.Property(e => e.MentorId).HasColumnName("MentorID");

        entity.HasOne(d => d.Mentor).WithMany(p => p.InverseMentor)
            .HasForeignKey(d => d.MentorId)
            .HasConstraintName("FK_MentorID");
    }
}