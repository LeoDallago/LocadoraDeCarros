using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeCarros.Infra.ModuloCliente;

public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
{
    public RepositorioCliente(LocadoraDeCarrosDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Cliente> ObterRegistros()
    {
        return _dbContext.Cliente;
    }

    public List<Cliente> Filtrar(Func<Cliente, bool> predicate)
    {
        return _dbContext.Cliente
            .Where(predicate)
            .ToList();
    }
}