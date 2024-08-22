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


    public Result<Automovel> Inserir(string marca, string modelo, string cor, string tipoCombustivel,
        string capacidadeCombustivel, string ano, int grupoId)
    {
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        var automovel = new Automovel(marca,
            modelo,
            cor,
            tipoCombustivel,
            capacidadeCombustivel,
            ano,
            grupoSelecionado);
        
        _repositorioAutomovel.Inserir(automovel);
        
        return Result.Ok(automovel);
    }
    
    public Result<Automovel> Editar(int automovelId,string marca, string modelo, string cor, string tipoCombustivel,
        string capacidadeCombustivel, string ano, int grupoId)
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
        
        automovelSelecionado.Marca = marca;
        automovelSelecionado.Modelo = modelo;
        automovelSelecionado.Cor = cor;
        automovelSelecionado.TipoCombustivel = tipoCombustivel;
        automovelSelecionado.CapacidadeCombustivel = capacidadeCombustivel;
        automovelSelecionado.Ano = ano;
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

    public Result<List<GrupoAutomoveis>> SelecionarTodos()
    {
        var automoveis = _repositorioGrupoAutomoveis.SelecionarTodos();
        
        return Result.Ok(automoveis);
    }
}