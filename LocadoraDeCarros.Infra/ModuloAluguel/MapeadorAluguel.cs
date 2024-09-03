using LocadoraDeCarros.Dominio.ModuloAluguel;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloAluguel;

public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.ToTable("TBAluguel");

        builder.Property(a => a.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        
        builder.HasOne(a => a.Condutor)
            .WithMany()
            .HasForeignKey(a => a.CondutorId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Automovel)
            .WithMany()
            .HasForeignKey(a => a.AutomovelId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.KmRodados)
            .HasColumnType("decimal(10,2)");

        builder.Property(a => a.DataSaida)
            .IsRequired()
            .HasColumnType("datetime2");
        
        builder.Property(a => a.DataRetorno)
            .IsRequired()
            .HasColumnType("datetime2");
        
        builder.HasOne(a => a.Plano)
            .WithMany()
            .HasForeignKey(a => a.PlanoId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(a => a.Taxa)
            .WithMany()
            .HasForeignKey(a => a.TaxaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(a => a.Concluido)
            .IsRequired()
            .HasColumnType("BIT");
        
        builder.Property(a => a.ValorTotal)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
        builder.HasOne(g => g.Usuario)
            .WithMany()
            .HasForeignKey("UsuarioId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}