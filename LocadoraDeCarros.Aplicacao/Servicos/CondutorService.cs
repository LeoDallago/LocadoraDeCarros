using FluentResults;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class CondutorService
{
    private readonly IRepositorioCondutor repositorioCondutor;
    private readonly IRepositorioCliente repositorioCliente;

    public CondutorService(IRepositorioCondutor repositorioCondutor, IRepositorioCliente repositorioCliente)
    {
        this.repositorioCondutor = repositorioCondutor;
        this.repositorioCliente = repositorioCliente;
    }


    public Result<Condutor> Inserir(Condutor condutor, int clienteId)
    {
        var clienteSelecionado = repositorioCliente.SelecionarPorId(clienteId);

        if (clienteSelecionado is null)
        {
            return Result.Fail("Cliente nao encontrado!");
        }
        
        condutor.Cliente = clienteSelecionado;
        
        repositorioCondutor.Inserir(condutor);
        
        return Result.Ok(condutor);
    }

    public Result<Condutor> Editar(int condutorId, Condutor condutor, int clienteId)
    {
        var clienteSelecionado = repositorioCliente.SelecionarPorId(clienteId);

        if (clienteSelecionado is null)
        {
            return Result.Fail("Cliente nao encontrado!");
        }
        
        var condutorSelecionado = repositorioCondutor.SelecionarPorId(condutorId);

        if (condutorSelecionado is null)
        {
            return Result.Fail("Condutor nao encontrado!");
        }
        
        condutorSelecionado.Nome = condutor.Nome;
        condutorSelecionado.Email = condutor.Email;
        condutorSelecionado.Telefone = condutor.Telefone;
        condutorSelecionado.CPF = condutor.CPF;
        condutorSelecionado.CNH = condutor.CNH;
        condutorSelecionado.Validade = condutor.Validade;
        condutorSelecionado.Cliente = clienteSelecionado;
        
        repositorioCondutor.Editar(condutorSelecionado);
        
        return Result.Ok(condutorSelecionado);
    }

    public Result<Condutor> Excluir(int id)
    {
        var condutor = repositorioCondutor.SelecionarPorId(id);

        if (condutor is null)
        {
            return Result.Fail("Condutor nao encontrado!");
        }
        
        repositorioCondutor.Excluir(condutor);
        
        return Result.Ok();
    }

    public Result<Condutor> SelecionarPorId(int id)
    {
        var condutor = repositorioCondutor.SelecionarPorId(id);
        
        if (condutor is null)
        {
            return Result.Fail("Condutor nao encontrado!");
        }
        
        return Result.Ok(condutor);
    }

    public Result<List<Condutor>> SelecionarTodos()
    {
        var condutores = repositorioCondutor.SelecionarTodos();
        
        return Result.Ok(condutores);
    }
}