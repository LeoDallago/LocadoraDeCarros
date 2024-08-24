using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.ModuloAutomovel;
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
        base.OnModelCreating(modelBuilder);
    }
}