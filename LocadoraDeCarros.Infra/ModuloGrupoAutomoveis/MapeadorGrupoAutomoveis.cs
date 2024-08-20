using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;

public class MapeadorGrupoAutomoveis : IEntityTypeConfiguration<GrupoAutomoveis>
{
    public void Configure(EntityTypeBuilder<GrupoAutomoveis> builder)
    {
        builder.ToTable("TBGrupoAutomoveis");

        builder.Property(g => g.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(g => g.Grupo)
            .IsRequired()
            .HasColumnType("varchar(100)");
    }
}