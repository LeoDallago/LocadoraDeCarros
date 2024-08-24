using FluentResults;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.ModuloTaxa;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class TaxaService
{
    private readonly RepositorioTaxa _repositorioTaxa;

    public TaxaService(RepositorioTaxa repositorioTaxa)
    {
        _repositorioTaxa = repositorioTaxa;
    }

    public Result<Taxa> Inserir(Taxa taxa)
    {
        _repositorioTaxa.Inserir(taxa);

        return Result.Ok(taxa);
    }

    public Result<Taxa> Editar(int taxaId, Taxa taxa)
    {
        var taxaSelecionada = _repositorioTaxa.SelecionarPorId(taxaId);
        
        if (taxaSelecionada is null)
        {
            return Result.Fail("Taxa ou Serviço não encontrado(a)!");
        }
        
        taxaSelecionada.Nome = taxa.Nome;
        taxaSelecionada.Preco = taxa.Preco;
        taxaSelecionada.PlanoCobranca = taxa.PlanoCobranca;
        
        _repositorioTaxa.Editar(taxaSelecionada);
        
        return Result.Ok(taxaSelecionada);
    }

    public Result<Taxa> Excluir(int taxaId)
    {
        var taxaSelecionada = _repositorioTaxa.SelecionarPorId(taxaId);
        
        if (taxaSelecionada is null)
        {
            return Result.Fail("Taxa ou Serviço não encontrado(a)!");
        }
        
        _repositorioTaxa.Excluir(taxaSelecionada);
        
        return Result.Ok();
    }

    public Result<Taxa> SelecionarPorId(int taxaId)
    {
        var taxaSelecionada = _repositorioTaxa.SelecionarPorId(taxaId);
        
        if (taxaSelecionada is null)
        {
            return Result.Fail("Taxa ou Serviço não encontrado(a)!");
        }
        
        return Result.Ok(taxaSelecionada);
    }

    public Result<List<Taxa>> SelecionarTodos()
    {
        var taxas = _repositorioTaxa.SelecionarTodos();
        
        return Result.Ok(taxas);
    }
}