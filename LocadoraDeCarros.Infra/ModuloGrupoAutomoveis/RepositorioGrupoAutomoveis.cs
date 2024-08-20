using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;

public class RepositorioGrupoAutomoveis : RepositorioBase<GrupoAutomoveis>, IRepositorioGrupoAutomoveis
{
    public RepositorioGrupoAutomoveis(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<GrupoAutomoveis> ObterRegistros()
    {
        return _dbContext.grupoAutomoveis;
    }

    public List<GrupoAutomoveis> Filtrar(Func<GrupoAutomoveis, bool> predicate)
    {
        return _dbContext.grupoAutomoveis
            .Where(predicate)
            .ToList();
    }
}