using FluentResults;
using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using Microsoft.Extensions.Configuration;

namespace LocadoraDeCarros.Aplicacao.Servicos;

public class ConfiguracoesService
{
    private readonly IRepositorioConfiguracoes _repositorioConfiguracoes;

    public ConfiguracoesService(IRepositorioConfiguracoes repositorioConfiguracoes)
    {
        _repositorioConfiguracoes = repositorioConfiguracoes;
    }

    public Result<Configuracoes> Editar(Configuracoes configuracao)
    {
        var config = _repositorioConfiguracoes.SelecionarPorId(configuracao.Id);
        
        config.Gasolina = configuracao.Gasolina;
        config.Gas = configuracao.Gas;
        config.Diesel = configuracao.Diesel;
        config.Alcool = configuracao.Alcool;
        
        _repositorioConfiguracoes.Editar(config);
        
        return Result.Ok(config);
    }

    public Result<Configuracoes> SelecionarPorId(int id)
    {
        var config = _repositorioConfiguracoes.SelecionarPorId(id);
        
        return Result.Ok(config);
    }
}