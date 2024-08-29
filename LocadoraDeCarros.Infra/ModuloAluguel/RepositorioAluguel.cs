using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloAluguel;

public class RepositorioAluguel : RepositorioBase<Aluguel>,IRepositorioAluguel
{
    public RepositorioAluguel(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Aluguel> ObterRegistros()
    {
        return _dbContext.Aluguel;
    }

    public List<Aluguel> Filtrar(Func<Aluguel, bool> predicate)
    {
        return _dbContext.Aluguel
            .Where(predicate)
            .ToList();
    }
}