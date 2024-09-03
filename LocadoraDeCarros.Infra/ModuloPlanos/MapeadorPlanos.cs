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
            .HasColumnType("decimal(10,2)");
        
        builder.Property(p => p.PrecoKm)
            .HasColumnType("decimal(5,2)");
        
        builder.Property(p => p.KmDisponivel)
            .HasColumnType("decimal(10,2)");

        builder.Property(p => p.KmLivre)
            .HasColumnType("decimal(10,2)");

        builder.HasOne(p => p.Grupo)
            .WithMany()
            .HasForeignKey(p => p.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey("UsuarioId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}