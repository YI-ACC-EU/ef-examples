using AirportExample.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirportExample.Repositories.DbContexts.Configurations;
public class FlightInstanceConfiguration : IEntityTypeConfiguration<FlightInstance>
{
    public void Configure(EntityTypeBuilder<FlightInstance> entity)
    {
            entity.HasKey(e => e.InstanceId).HasName("InstanceId_pk");

            entity.ToTable("FlightInstance");

            entity.Property(e => e.InstanceId).HasColumnName("InstanceID");
            entity.Property(e => e.CoPilotAboardId).HasColumnName("CoPilotAboardID");
            entity.Property(e => e.DateTimeArrive).HasColumnType("datetime");
            entity.Property(e => e.DateTimeLeave).HasColumnType("datetime");
            entity.Property(e => e.FlightNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FsmAttendantId).HasColumnName("FSM_AttendantID");
            entity.Property(e => e.PilotAboardId).HasColumnName("PilotAboardID");
            entity.Property(e => e.PlaneId).HasColumnName("PlaneID");

            entity.HasOne(d => d.CoPilotAboard).WithMany(p => p.FlightInstanceCoPilotAboards)
                .HasForeignKey(d => d.CoPilotAboardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FI_CoPilotAboardId");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightInstances)
                .HasForeignKey(d => d.FlightNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FI_FlightNo");

            entity.HasOne(d => d.FsmAttendant).WithMany(p => p.FlightInstances)
                .HasForeignKey(d => d.FsmAttendantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FI_FSMAttendantID");

            entity.HasOne(d => d.PilotAboard).WithMany(p => p.FlightInstancePilotAboards)
                .HasForeignKey(d => d.PilotAboardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FI_PilotAboardId");

            entity.HasOne(d => d.Plane).WithMany(p => p.FlightInstances)
                .HasForeignKey(d => d.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FI_PlaneID");

            entity.HasMany(d => d.Attendants).WithMany(p => p.Instances)
                .UsingEntity<Dictionary<string, object>>(
                    "InstanceAttendant",
                    r => r.HasOne<FlightAttendant>().WithMany()
                        .HasForeignKey("AttendantId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IA_AttendantId"),
                    l => l.HasOne<FlightInstance>().WithMany()
                        .HasForeignKey("InstanceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_IA_InstanceId"),
                    j =>
                    {
                        j.HasKey("InstanceId", "AttendantId").HasName("PK_InstanceAttendantID");
                        j.ToTable("InstanceAttendant");
                        j.IndexerProperty<int>("InstanceId").HasColumnName("InstanceID");
                        j.IndexerProperty<int>("AttendantId").HasColumnName("AttendantID");
                    });
    }
}