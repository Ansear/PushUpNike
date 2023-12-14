using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class RoleConfiguration : IEntityTypeConfiguration<Role>

{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("roles");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("rol_id");
        builder.Property(e => e.NombreRol)
            .HasMaxLength(50)
            .HasColumnName("nombre_rol");
    }
}