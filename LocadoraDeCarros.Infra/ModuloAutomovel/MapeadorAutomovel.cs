using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloAutomovel;

public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
{
    public void Configure(EntityTypeBuilder<Automovel> builder)
    {
        builder.ToTable("TBAutomovel");

        builder.Property(v => v.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(v => v.Foto)
            .IsRequired()
            .HasColumnType("varchar(250)");
        
        builder.Property(v => v.Marca)
            .HasColumnType("varchar(150)");
        
        builder.Property(v => v.Modelo)
            .IsRequired()
            .HasColumnType("varchar(150)");
        
        builder.Property(v => v.Cor)
            .IsRequired()
            .HasColumnType("varchar(150)");
        
        builder.Property(v => v.TipoCombustivel)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(v => v.CapacidadeCombustivel)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(v => v.Ano)
            .IsRequired()
            .HasColumnType("varchar(150)");

        builder.HasOne(v => v.Grupo)
            .WithMany()
            .HasForeignKey(g => g.GrupoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(c => c.UsuarioId)
            .IsRequired()
            .HasColumnType("int")
            .HasColumnName("UsuarioId");
        
        builder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey(g => g.UsuarioId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}