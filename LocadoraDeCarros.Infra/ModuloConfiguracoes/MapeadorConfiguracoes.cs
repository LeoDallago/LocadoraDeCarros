using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeCarros.Infra.ModuloConfiguracoes;

public class MapeadorConfiguracoes : IEntityTypeConfiguration<Configuracoes>
{
    public void Configure(EntityTypeBuilder<Configuracoes> builder)
    {
        builder.ToTable("TBConfiguracoes");

        builder.Property(c => c.Id);
        
        builder.Property(c => c.Gasolina)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(c => c.Gas)
            .HasColumnType("decimal(18,2)");

        builder.Property(c => c.Diesel)
            .HasColumnType("decimal(18,2)");
        
        builder.Property(c => c.Alcool)
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
        
        builder.HasData(RegistrosPadrao());
       
    }

    private object[] RegistrosPadrao()
    {
        return
        [
            new
            {
                Id = 1,
                Gasolina = 1.0m,
                Gas = 1.0m,
                Diesel = 1.0m,
                Alcool = 1.0m,
                UsuarioId = 1,
            }
        ];
    }
}