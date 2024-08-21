using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class GrupoAutomoveisController : WebControllerBase
{
    private readonly GrupoAutomoveisService _grupoAutomoveisService;
    private readonly IMapper _mapper;

    public GrupoAutomoveisController(GrupoAutomoveisService grupoAutomoveisService, IMapper mapper)
    {
        _grupoAutomoveisService = grupoAutomoveisService;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = _grupoAutomoveisService.SelecionarTodos();
        
        var listaGrupos = resultado.Value;

        var listarGruposVm = _mapper.Map<IEnumerable<ListarGrupoAutomoveisViewModel>>(listaGrupos);


        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();

        return View(listarGruposVm);
    }

    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirGrupoAutomoveisViewModel grupoAutomoveisViewModel)
    {
        if (!ModelState.IsValid) 
            return View(grupoAutomoveisViewModel);
        
        var novoGrupo = _mapper.Map<GrupoAutomoveis>(grupoAutomoveisViewModel);
        
        var resultado = _grupoAutomoveisService.Inserir(novoGrupo.Grupo);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro {novoGrupo.Grupo} foi INSERIDO com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var grupo = _grupoAutomoveisService.SelecionarPorId(id);
        
        if (grupo.IsFailed)
        {
            ApresentarMensagemFalha(grupo.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        var detalhesGrupoVm = _mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo.Value);
        
        return View(detalhesGrupoVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel grupoAutomoveisViewModel)
    {
        var grupo = _grupoAutomoveisService.Excluir(grupoAutomoveisViewModel.Id);
        
        if (grupo.IsFailed)
        {
            ApresentarMensagemFalha(grupo);
            
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }


    public IActionResult Editar(int id)
    {
        var grupo = _grupoAutomoveisService.SelecionarPorId(id);

        if (grupo.IsFailed)
        {
            ApresentarMensagemFalha(grupo.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        var editarGrupoVm = _mapper.Map<EditarGrupoAutomoveisViewModel>(grupo.Value);
        
        ApresentarMensagemSucesso($"O registro {editarGrupoVm.Grupo} foi EDITADO com sucesso!");
        
        return View(editarGrupoVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarGrupoAutomoveisViewModel grupoAutomoveisViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(grupoAutomoveisViewModel);
        }

        var editarGrupoVm = _mapper.Map<GrupoAutomoveis>(grupoAutomoveisViewModel);

       var resultado = _grupoAutomoveisService.Editar(editarGrupoVm.Id, editarGrupoVm.Grupo);

       if (resultado.IsFailed)
       {
           ApresentarMensagemFalha(resultado.ToResult());
           
           return RedirectToAction(nameof(Listar));
       }
        
        return RedirectToAction(nameof(Listar));
    }
}