using LocadoraDeCarros.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloFuncionario;

public class MapeadorFuncionario : IEntityTypeConfiguration<Funcionario>
{
    public void Configure(EntityTypeBuilder<Funcionario> builder)
    {
        builder.ToTable("TBFuncionario");

        builder.Property(f => f.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.Property(f => f.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");
        
        builder.Property(f => f.Admissao)
            .IsRequired()
            .HasColumnType("datetime2");
        
        builder.Property(f => f.Salario)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
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