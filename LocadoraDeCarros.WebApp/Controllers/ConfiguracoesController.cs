using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloConfiguracoes;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class ConfiguracoesController : WebControllerBase
{
    private readonly ConfiguracoesService _configuracoesService;
    private readonly IMapper _mapper;

    public ConfiguracoesController(ConfiguracoesService configuracoesService, IMapper mapper)
    {
        _configuracoesService = configuracoesService;
        _mapper = mapper;
    }

    public IActionResult EditarConfiguracao(int id)
    {
        var config = _configuracoesService.SelecionarPorId(id);

        var configVm = _mapper.Map<ConfiguracoesViewModel>(config.Value);
        
        return View(configVm);
    }

    [HttpPost]
    public IActionResult EditarConfiguracao(ConfiguracoesViewModel configuracoesViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(configuracoesViewModel);
        }
        
        var editarConfigVm = _mapper.Map<Configuracoes>(configuracoesViewModel);
        
        _configuracoesService.Editar(editarConfigVm);

        return RedirectToPage("/");
    }
}