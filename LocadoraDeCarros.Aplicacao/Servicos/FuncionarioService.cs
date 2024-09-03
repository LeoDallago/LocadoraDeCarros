using FluentResults;
using LocadoraDeCarros.Dominio.ModuloFuncionario;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class FuncionarioService
{
    private readonly IRepositorioFuncionario _repositorioFuncionario;

    public FuncionarioService(IRepositorioFuncionario repositorioFuncionario)
    {
        _repositorioFuncionario = repositorioFuncionario;
    }

    public Result<Funcionario> Inserir(Funcionario funcionario)
    {
        _repositorioFuncionario.Inserir(funcionario);
        
        return Result.Ok(funcionario);
    }

    public Result<Funcionario> Editar(Funcionario funcionarioEditado, int funcionarioId)
    {
        var funcionarioSelecionado = _repositorioFuncionario.SelecionarPorId(funcionarioId);
        
        if (funcionarioSelecionado is null)
        {
            return Result.Fail("Funcionario nao encontrado!");
        }
        
        funcionarioSelecionado.Nome = funcionarioEditado.Nome;
        funcionarioSelecionado.Admissao = funcionarioEditado.Admissao;
        funcionarioSelecionado.Salario = funcionarioEditado.Salario;
        
        _repositorioFuncionario.Editar(funcionarioSelecionado);
        
        return Result.Ok(funcionarioSelecionado);
    }

    public Result Excluir(int funcionarioId)
    {
        var funcionarioSelecionado = _repositorioFuncionario.SelecionarPorId(funcionarioId);
        
        if (funcionarioSelecionado is null)
        {
            return Result.Fail("Funcionario nao encontrado!");
        }
        
        _repositorioFuncionario.Excluir(funcionarioSelecionado);
        
        return Result.Ok();
    }

    public Result<Funcionario> SelecionarPorId(int funcionarioId)
    {
        var funcionarioSelecionado = _repositorioFuncionario.SelecionarPorId(funcionarioId);
        
        if (funcionarioSelecionado is null)
        {
            return Result.Fail("Funcionario nao encontrado!");
        }
        
        return Result.Ok(funcionarioSelecionado);
    }

    public Result<List<Funcionario>> SelecionarTodos()
    {
        var funcionarios = _repositorioFuncionario.SelecionarTodos();
        
        return Result.Ok(funcionarios);
    }
}