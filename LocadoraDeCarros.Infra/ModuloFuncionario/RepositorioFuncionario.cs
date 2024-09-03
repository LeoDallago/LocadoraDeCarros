using LocadoraDeCarros.Dominio.ModuloFuncionario;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloFuncionario;

public class RepositorioFuncionario : RepositorioBase<Funcionario>,IRepositorioFuncionario
{
    public RepositorioFuncionario(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Funcionario> ObterRegistros()
    {
        return _dbContext.Funcionario;
    }

    public List<Funcionario> Filtrar(Func<Funcionario, bool> predicate)
    {
        return _dbContext.Funcionario
            .Where(predicate)
            .ToList();
    }
}