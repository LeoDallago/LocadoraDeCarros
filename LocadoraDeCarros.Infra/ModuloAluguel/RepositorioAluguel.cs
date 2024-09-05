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
    
    public override Aluguel? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(c => c.Automovel)
            .Include(c => c.Condutor)
            .Include(c => c.Taxa)
            .Include(c => c.Plano)
            .FirstOrDefault(c => c.Id == id);
    }

    public override List<Aluguel> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(c => c.Automovel)
            .Include(c => c.Condutor)
            .Include(c => c.Taxa)
            .Include(c => c.Plano)
            .ToList();
    }
}