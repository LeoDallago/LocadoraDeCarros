using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeCarros.Infra.Compartilhado;

public class LocadoraDeCarrosDbContext : DbContext
{
    public DbSet<GrupoAutomoveis> grupoAutomoveis { get; set; }


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
        base.OnModelCreating(modelBuilder);
    }
}