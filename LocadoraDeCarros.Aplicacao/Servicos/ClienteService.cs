using FluentResults;
using LocadoraDeCarros.Dominio.ModuloCliente;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class ClienteService
{
    private readonly IRepositorioCliente _repositorioCliente;

    public ClienteService(IRepositorioCliente repositorioCliente)
    {
        _repositorioCliente = repositorioCliente;
    }

    public Result<Cliente> Inserir(Cliente cliente)
    {
        _repositorioCliente.Inserir(cliente);
        
        return Result.Ok(cliente);
    }

    public Result<Cliente> Editar(Cliente cliente, int clienteId)
    {
        var clienteSelecionado = _repositorioCliente.SelecionarPorId(clienteId);
        
        if (clienteSelecionado is null)
        {
            return Result.Fail("Cliente nao encontrado!");
        }
        
        clienteSelecionado.Nome = cliente.Nome;
        clienteSelecionado.Email = cliente.Email;
        clienteSelecionado.Telefone = cliente.Telefone;
        clienteSelecionado.Estado = cliente.Estado;
        clienteSelecionado.Cidade = cliente.Cidade;
        clienteSelecionado.Bairro = cliente.Bairro;
        clienteSelecionado.Rua = cliente.Rua;
        clienteSelecionado.Numero = cliente.Numero;
        clienteSelecionado.TipoCliente = cliente.TipoCliente;
        
        _repositorioCliente.Editar(clienteSelecionado);
        
        return Result.Ok(clienteSelecionado);
    }

    public Result<Cliente> Excluir(int clienteId)
    {
        var clienteSelecionado = _repositorioCliente.SelecionarPorId(clienteId);
        
        if (clienteSelecionado is null)
        {
            return Result.Fail("Cliente nao encontrado!");
        }
        
        _repositorioCliente.Excluir(clienteSelecionado);

        return Result.Ok();
    }

    public Result<Cliente> SelecionarPorId(int clienteId)
    {
        var clienteSelecionado = _repositorioCliente.SelecionarPorId(clienteId);
        
        if (clienteSelecionado is null)
        {
            return Result.Fail("Cliente nao encontrado!");
        }
        
        return Result.Ok(clienteSelecionado);
    }

    public Result<List<Cliente>> SelecionarTodos()
    {
        var clientes = _repositorioCliente.SelecionarTodos();
        
        return Result.Ok(clientes);
    }
}