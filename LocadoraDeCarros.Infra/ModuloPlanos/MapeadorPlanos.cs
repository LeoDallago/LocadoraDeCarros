using LocadoraDeCarros.Dominio.ModuloPlanos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloPlanos;

public class MapeadorPlanos : IEntityTypeConfiguration<Planos>
{
    public void Configure(EntityTypeBuilder<Planos> builder)
    {
        builder.ToTable("TBPlanos");

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(p => p.Plano)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(p => p.PrecoDiaria)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(p => p.PrecoKm)
            .HasColumnType("varchar(100)");
        
        builder.Property(p => p.KmDisponivel)
            .HasColumnType("varchar(100)");

        builder.Property(p => p.KmExtrapolado)
            .HasColumnType("varchar(100)");

        builder.HasOne(p => p.Grupo)
            .WithMany()
            .HasForeignKey(p => p.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}