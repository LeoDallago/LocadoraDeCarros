using LocadoraDeCarros.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloCondutor;

public class MapeadorCondutor : IEntityTypeConfiguration<Condutor>
{
    public void Configure(EntityTypeBuilder<Condutor> builder)
    {
        builder.ToTable("TBCondutor");

        builder.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        builder.Property(c => c.Email)
            .HasColumnType("varchar(100)");
        
        builder.Property(c => c.Telefone)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(c => c.CPF)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(c => c.CNH)
            .IsRequired()
            .HasColumnType("varchar(50)");
        
        builder.Property(c => c.Validade)
            .IsRequired()
            .HasColumnType("datetime2");

        builder.HasOne(c => c.Cliente)
            .WithMany()
            .HasForeignKey(c => c.ClienteId)
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