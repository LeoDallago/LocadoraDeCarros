using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloConfiguracoes;

public class RepositorioConfiguracoes : RepositorioBase<Configuracoes>,IRepositorioConfiguracoes
{
    public RepositorioConfiguracoes(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Configuracoes> ObterRegistros()
    {
        return _dbContext.Configuracoes;
    }

    public List<Configuracoes> Filtrar(Func<Configuracoes, bool> predicate)
    {
        return _dbContext.Configuracoes
            .Where(predicate)
            .ToList();
    }
}