using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class GrupoAutomoveisController : Controller
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
        
        _grupoAutomoveisService.Inserir(novoGrupo.Grupo);

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var grupo = _grupoAutomoveisService.SelecionarPorId(id);
        
        var detalhesGrupoVm = _mapper.Map<DetalhesGrupoAutomoveisViewModel>(grupo.Value);
        
        return View(detalhesGrupoVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesGrupoAutomoveisViewModel grupoAutomoveisViewModel)
    {
        var grupo = _grupoAutomoveisService.Excluir(grupoAutomoveisViewModel.Id);
        
        return RedirectToAction(nameof(Listar));
    }


    public IActionResult Editar(int id)
    {
        var grupo = _grupoAutomoveisService.SelecionarPorId(id);
        
        var editarGrupoVm = _mapper.Map<EditarGrupoAutomoveisViewModel>(grupo.Value);
        
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

        _grupoAutomoveisService.Editar(editarGrupoVm.Id, editarGrupoVm.Grupo);
        
        return RedirectToAction(nameof(Listar));
    }
}