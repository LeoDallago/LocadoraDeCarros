using LocadoraDeCarros.Dominio.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloTaxa;

public class MapeadorTaxa : IEntityTypeConfiguration<Taxa>
{
    public void Configure(EntityTypeBuilder<Taxa> builder)
    {
        builder.ToTable("TBTaxa");

        builder.Property(t => t.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(t => t.Nome)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.Property(t => t.Preco)
            .IsRequired()
            .HasColumnType("decimal(10,2)");
        
        builder.Property(t => t.PlanoCobranca)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
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