using FluentResults;
using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class AluguelService
{
    private readonly IRepositorioAluguel _repositorioAluguel;
    private readonly IRepositorioCondutor _repositorioCondutor;
    private readonly IRepositorioAutomovel _repositorioAutomovel;
    private readonly IRepositorioPlanos _repositorioPlanos;
    private readonly IRepositorioTaxa _repositorioTaxa;

    public AluguelService(
        IRepositorioAluguel repositorioAluguel,
        IRepositorioCondutor repositorioCondutor,
        IRepositorioAutomovel repositorioAutomovel,
        IRepositorioPlanos repositorioPlanos,
        IRepositorioTaxa repositorioTaxa
        )
    {
        _repositorioAluguel = repositorioAluguel;
        _repositorioCondutor = repositorioCondutor;
        _repositorioAutomovel = repositorioAutomovel;
        _repositorioPlanos = repositorioPlanos;
        _repositorioTaxa = repositorioTaxa;
    }

    public Result<Aluguel> Inserir(Aluguel aluguel, int condutorId, int automovelId, int planoId, int taxaId)
    {
        var condutor = _repositorioCondutor.SelecionarPorId(condutorId);
        var automovel = _repositorioAutomovel.SelecionarPorId(automovelId);
        var plano = _repositorioPlanos.SelecionarPorId(planoId);
        var taxa = _repositorioTaxa.SelecionarPorId(taxaId);
        
        aluguel.Condutor  = condutor;
        aluguel.Automovel = automovel;
        aluguel.Plano = plano;
        aluguel.Taxa = taxa;
        
        _repositorioAluguel.Inserir(aluguel);
        
        return Result.Ok(aluguel);
    }

    public Result<Aluguel> Editar(
        int aluguelId,
        Aluguel aluguelEditado,
        int condutorId, 
        int automovelId,
        int planoId,
        int taxaId
        )
    {
        var aluguelSelecionado = _repositorioAluguel.SelecionarPorId(aluguelId);
        var condutor = _repositorioCondutor.SelecionarPorId(condutorId);
        var automovel = _repositorioAutomovel.SelecionarPorId(automovelId);
        var plano = _repositorioPlanos.SelecionarPorId(planoId);
        var taxa = _repositorioTaxa.SelecionarPorId(taxaId);
        
        aluguelSelecionado.Condutor = condutor;
        aluguelSelecionado.Automovel = automovel;
        aluguelSelecionado.DataSaida = aluguelEditado.DataSaida;
        aluguelSelecionado.DataRetorno = aluguelEditado.DataRetorno;
        aluguelSelecionado.Plano = plano;
        aluguelSelecionado.Taxa = taxa;
        aluguelSelecionado.Concluido = aluguelEditado.Concluido;
        aluguelSelecionado.ValorTotal = aluguelEditado.ValorTotal;
        
        _repositorioAluguel.Editar(aluguelSelecionado);
        
        return Result.Ok(aluguelSelecionado);
    }

    public Result<Aluguel> Excluir(int aluguelId)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(aluguelId);
        
        if (aluguel is null)
        {
            return Result.Fail("Aluguel nao encontrado!");
        }else if (aluguel.Concluido == false)
        {
            return Result.Fail("Aluguel não finalizado!");
        }
        
        _repositorioAluguel.Excluir(aluguel);
        
        return Result.Ok();
    }

    public Result<Aluguel> SelecionarPorId(int aluguelId)
    {
        var aluguel = _repositorioAluguel.SelecionarPorId(aluguelId);
        
        if (aluguel is null)
        {
            return Result.Fail("Aluguel nao encontrado!");
        }
        
        return Result.Ok(aluguel);
    }

    public Result<List<Aluguel>> SelecionarTodos()
    {
        var alugueis = _repositorioAluguel.SelecionarTodos();
        
        return Result.Ok(alugueis);
    }
}