using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using FluentResults;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class GrupoAutomoveisService
{
    private readonly IRepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;

    public GrupoAutomoveisService(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis)
    {
        _repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
    }

    public Result<GrupoAutomoveis> Inserir(GrupoAutomoveis grupoAutomoveis)
    {
        
        _repositorioGrupoAutomoveis.Inserir(grupoAutomoveis);
        
        return Result.Ok(grupoAutomoveis);
    }

    public Result<GrupoAutomoveis> Editar(int grupoAutomoveisId, string grupoEditado)
    {
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);

        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        grupoSelecionado.Grupo = grupoEditado;
        
        _repositorioGrupoAutomoveis.Editar(grupoSelecionado);
        
        return Result.Ok(grupoSelecionado);
    }

    public Result Excluir(int grupoAutomoveisId)
    {
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);
        
        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        _repositorioGrupoAutomoveis.Excluir(grupoSelecionado);
        
        return Result.Ok();
    }

    public Result<GrupoAutomoveis> SelecionarPorId(int grupoAutomoveisId)
    {
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoAutomoveisId);
        
        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado!");
        }
        
        return Result.Ok(grupoSelecionado);
    }

    public Result<List<GrupoAutomoveis>> SelecionarTodos()
    {
        var grupos = _repositorioGrupoAutomoveis.SelecionarTodos();
        
        return Result.Ok(grupos);
    }
}