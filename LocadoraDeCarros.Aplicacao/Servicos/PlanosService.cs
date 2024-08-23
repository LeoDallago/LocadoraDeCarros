using FluentResults;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;

namespace LocadoraDeCarros.Aplicacao;

public class PlanosService
{
    private readonly IRepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;
    private readonly IRepositorioPlanos _repositorioPlanos;

    public PlanosService(IRepositorioGrupoAutomoveis repositorioGrupoAutomoveis, IRepositorioPlanos repositorioPlanos)
    {
        _repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        _repositorioPlanos = repositorioPlanos;
    }

    public Result<Planos> Inserir(Planos plano, int grupoId)
    {
       var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

       if (grupoSelecionado is null)
       {
           return Result.Fail("Grupo nao encontrado");
       }
       
       plano.Grupo = grupoSelecionado;
       
       _repositorioPlanos.Inserir(plano);
       
       return Result.Ok(plano);
    }

    public Result<Planos> Editar(int planoId, Planos plano, int grupoId)
    {
        var planoSelecionado = _repositorioPlanos.SelecionarPorId(planoId);
        
        if (planoSelecionado is null)
        {
            return Result.Fail("Plano nao encontrado");
        }
        
        var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(grupoId);

        if (grupoSelecionado is null)
        {
            return Result.Fail("Grupo nao encontrado");
        }
        
        planoSelecionado.Plano = plano.Plano;
        planoSelecionado.PrecoDiaria = plano.PrecoDiaria;
        planoSelecionado.PrecoKm = plano.PrecoKm;
        planoSelecionado.KmDisponivel = plano.KmDisponivel;
        planoSelecionado.KmExtrapolado = plano.KmExtrapolado;
        planoSelecionado.GrupoId = grupoSelecionado.Id;
        planoSelecionado.Grupo = grupoSelecionado;
        
        _repositorioPlanos.Editar(planoSelecionado);
        
        return Result.Ok(planoSelecionado);
    }

    public Result<Planos> Excluir(int planoId)
    {
        var planoSelecionado = _repositorioPlanos.SelecionarPorId(planoId);
        
          
        if (planoSelecionado is null)
        {
            return Result.Fail("Plano nao encontrado");
        }
        
        _repositorioPlanos.Excluir(planoSelecionado);

        return Result.Ok();
    }

    public Result<Planos> SelecionarPorId(int planoId)
    {
        var planoSelecionado = _repositorioPlanos.SelecionarPorId(planoId);
        
        if (planoSelecionado is null)
        {
            return Result.Fail("Plano nao encontrado");
        }
        
        return Result.Ok(planoSelecionado);
    }

    public Result<List<Planos>> SelecionarTodos()
    {
        var planos = _repositorioPlanos.SelecionarTodos();
        
        return Result.Ok(planos);
    }
}