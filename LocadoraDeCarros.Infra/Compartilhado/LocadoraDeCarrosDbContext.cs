using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.ModuloAluguel;
using LocadoraDeCarros.Infra.ModuloAutomovel;
using LocadoraDeCarros.Infra.ModuloCliente;
using LocadoraDeCarros.Infra.ModuloCondutor;
using LocadoraDeCarros.Infra.ModuloConfiguracoes;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.ModuloPlanos;
using LocadoraDeCarros.Infra.ModuloTaxa;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeCarros.Infra.Compartilhado;

public class LocadoraDeCarrosDbContext : DbContext
{
    public DbSet<GrupoAutomoveis> grupoAutomoveis { get; set; }

    public DbSet<Automovel> Automovel { get; set; }
    
    public DbSet<Planos> Planos { get; set; }
    
    public DbSet<Taxa> Taxa { get; set; }
    
    public DbSet<Cliente> Cliente { get; set; }
    
    public DbSet<Condutor> Condutor { get; set; }
    
    public DbSet<Configuracoes> Configuracoes { get; set; }
    
    public DbSet<Aluguel> Aluguel { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = config
            .GetConnectionString("SqlServer");

        optionsBuilder.UseSqlServer(connectionString);

        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging();

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MapeadorGrupoAutomoveis());
        modelBuilder.ApplyConfiguration(new MapeadorAutomovel());
        modelBuilder.ApplyConfiguration(new MapeadorPlanos());
        modelBuilder.ApplyConfiguration(new MapeadorTaxa());
        modelBuilder.ApplyConfiguration(new MapeadorCliente());
        modelBuilder.ApplyConfiguration(new MapeadorCondutor());
        modelBuilder.ApplyConfiguration(new MapeadorConfiguracoes());
        modelBuilder.ApplyConfiguration(new MapeadorAluguel());
        base.OnModelCreating(modelBuilder);
    }
}