using LocadoraDeCarros.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloCliente;

public class MapeadorCliente : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("TBCliente");

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
            .HasColumnType("varchar(20)");

        builder.Property(c => c.Estado)
            .HasColumnType("varchar(20)");
        
        builder.Property(c => c.Cidade)
            .HasColumnType("varchar(200)");
        
        builder.Property(c => c.Bairro)
            .HasColumnType("varchar(200)");
        
        builder.Property(c => c.Rua)
            .HasColumnType("varchar(200)");
        
        builder.Property(c => c.Numero)
            .HasColumnType("varchar(20)");
        
        builder.Property(c => c.TipoCliente)
            .IsRequired()
            .HasColumnType("varchar(100)");
        
        builder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey("UsuarioId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}