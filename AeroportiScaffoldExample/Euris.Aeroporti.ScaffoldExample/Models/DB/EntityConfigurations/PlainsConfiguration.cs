using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Euris.Aeroporti.ScaffoldExample.Models.DB.EntityConfigurations;

public class PlainsConfiguration : IEntityTypeConfiguration<Plains>
{
    public void Configure(EntityTypeBuilder<Plains> entity)
    {
        entity.ToTable("Aereo");
        entity.HasKey(e => e.PlainType).HasName("PK__Aereo__7ADE5096CDA08E91");
        entity.Property(e => e.PlainType)
            .HasColumnName("TipoAereo")
            .HasMaxLength(20)
            .IsUnicode(false);
        entity
            .Property(x => x.GoodsQuantity)
            .HasColumnName("QtaMerci");
        entity
            .Property(x => x.PassengersNumber)
            .HasColumnName("NumPasseggeri");
    }
}