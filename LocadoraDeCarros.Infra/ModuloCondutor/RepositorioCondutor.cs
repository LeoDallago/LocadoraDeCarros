using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloCondutor;

public class RepositorioCondutor : RepositorioBase<Condutor>,IRepositorioCondutor
{
    public RepositorioCondutor(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Condutor> ObterRegistros()
    {
        return _dbContext.Condutor;
    }

    public List<Condutor> Filtrar(Func<Condutor, bool> predicate)
    {
        return _dbContext.Condutor.
            Where(predicate).
            ToList();
    }
}