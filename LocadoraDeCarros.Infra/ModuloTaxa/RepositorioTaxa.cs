using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloTaxa;

public class RepositorioTaxa : RepositorioBase<Taxa>,IRepositorioTaxa
{
    public RepositorioTaxa(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Taxa> ObterRegistros()
    {
        return _dbContext.Taxa;
    }

    public List<Taxa> Filtrar(Func<Taxa, bool> predicate)
    {
        return _dbContext.Taxa
            .Where(predicate)
            .ToList();
    }
}