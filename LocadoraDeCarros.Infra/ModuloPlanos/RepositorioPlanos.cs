using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloPlanos;

public class RepositorioPlanos : RepositorioBase<Planos>, IRepositorioPlanos
{
    public RepositorioPlanos(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Planos> ObterRegistros()
    {
        return _dbContext.Planos;
    }

    public List<Planos> Filtrar(Func<Planos, bool> predicate)
    {
        return _dbContext.Planos
            .Where(predicate)
            .ToList();
    }
}