using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class TransaccionConfiguration : IEntityTypeConfiguration<Transaccione>

{
    public void Configure(EntityTypeBuilder<Transaccione> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("transacciones");

        builder.HasIndex(e => e.UsuarioId, "usuario_id");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("transaccion_id");
        builder.Property(e => e.FechaTransaccion)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("timestamp")
            .HasColumnName("fecha_transaccion");
        builder.Property(e => e.Total)
            .HasPrecision(10, 2)
            .HasColumnName("total");
        builder.Property(e => e.UsuarioId).HasColumnName("usuario_id");

        builder.HasOne(d => d.Usuario).WithMany(p => p.Transacciones)
            .HasForeignKey(d => d.UsuarioId)
            .HasConstraintName("transacciones_ibfk_1");
    }
}