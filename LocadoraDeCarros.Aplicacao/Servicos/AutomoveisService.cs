using FluentResults;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class AutomoveisService
{
    private readonly IRepositorioAutomovel _repositorioAutomovel;
    private readonly IRepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;

    public AutomoveisService(IRepositorioAutomovel repositorioAutomovel, IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
    {
        _repositorioAutomovel = repositorioAutomovel;
        _repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
    }


    public Result<Automovel> Inserir(Automovel automovel, int grupoId)
    {
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        automovel.Grupo = grupoSelecionado;
        
        _repositorioAutomovel.Inserir(automovel);
        
        return Result.Ok(automovel);
    }
    
    public Result<Automovel> Editar(int automovelId,Automovel automovel, int grupoId)
    {
        var automovelSelecionado = _repositorioAutomovel.SelecionarPorId(automovelId);
        
        if (automovelSelecionado is null)
        {
            return Result.Fail("Automovel nao encontrado!");
        }
        
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        automovelSelecionado.Marca = automovel.Marca;
        automovelSelecionado.Modelo = automovel.Modelo;
        automovelSelecionado.Cor = automovel.Cor;
        automovelSelecionado.TipoCombustivel = automovel.TipoCombustivel;
        automovelSelecionado.CapacidadeCombustivel = automovel.CapacidadeCombustivel;
        automovelSelecionado.Ano = automovel.Ano;
        automovelSelecionado.Grupo = grupoSelecionado;
        
        _repositorioAutomovel.Editar(automovelSelecionado);
        
        return Result.Ok(automovelSelecionado);
    }

    public Result<Automovel> Excluir(int automovelId)
    {
        var automovelSelecionado = _repositorioAutomovel.SelecionarPorId(automovelId);
        
        if (automovelSelecionado is null)
        {
            return Result.Fail("Automovel nao encontrado!");
        }
        
        _repositorioAutomovel.Excluir(automovelSelecionado);

        return Result.Ok();
    }


    public Result<Automovel> SelecionarPorId(int automovelId)
    {
        var automovelSelecionado = _repositorioAutomovel.SelecionarPorId(automovelId);

        if (automovelSelecionado is null)
        {
            return Result.Fail("Automovel nao encontrado!");
        }
        
        return Result.Ok(automovelSelecionado);
    }

    public Result<List<Automovel>> SelecionarTodos()
    {
        var automoveis = _repositorioAutomovel.SelecionarTodos();
        
        return Result.Ok(automoveis);
    }
}