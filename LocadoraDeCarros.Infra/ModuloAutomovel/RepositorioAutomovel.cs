using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloAutomovel;

public class RepositorioAutomovel : RepositorioBase<Automovel>,IRepositorioAutomovel
{
    public RepositorioAutomovel(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Automovel> ObterRegistros()
    {
        return _dbContext.Automovel;
    }

    public List<Automovel> Filtrar(Func<Automovel, bool> predicate)
    {
        return _dbContext.Automovel
            .Where(predicate)
            .ToList();
    }
    
    public override Automovel? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(c => c.Grupo)
            .FirstOrDefault(c => c.Id == id);
    }

    public override List<Automovel> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(c => c.Grupo)
            .ToList();
    }
}