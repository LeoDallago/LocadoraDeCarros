using AutoMapper;
using LocadoraDeCarros.Aplicacao;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers.Compartilhado;

public class PlanosController : WebControllerBase
{
    private readonly PlanosService _repositorioPlanos;
    private readonly GrupoAutomoveisService _repositorioGruposAutomoveis;
    private readonly IMapper _mapper;

    public PlanosController(PlanosService repositorioPlanos, GrupoAutomoveisService repositorioGruposAutomoveis, IMapper mapper)
    {
        _repositorioPlanos = repositorioPlanos;
        _repositorioGruposAutomoveis = repositorioGruposAutomoveis;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var plano = _repositorioPlanos.SelecionarTodos();

        var listarPlanosVm = _mapper.Map<IEnumerable<ListarPlanoViewModel>>(plano.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarPlanosVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarInformacoes(new InserirPlanoViewModel()));
    }

    [HttpPost]
    public IActionResult Inserir(InserirPlanoViewModel inserirPlanoViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inserirPlanoViewModel);
        }
        
        var novoPlano = _mapper.Map<Planos>(inserirPlanoViewModel);

        int grupoID = inserirPlanoViewModel.GrupoId;
        
        _repositorioPlanos.Inserir(novoPlano, grupoID);
        
        ApresentarMensagemSucesso($"O {novoPlano.Plano} INSERIDO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _repositorioPlanos.SelecionarPorId(id);
        
        var editarPlanoViewModel = _mapper.Map<EditarPlanoViewModel>(resultado.Value);
        
        return View(CarregarInformacoes(editarPlanoViewModel));
    }

    [HttpPost]
    public IActionResult Editar(EditarPlanoViewModel editarPlanoViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editarPlanoViewModel);
        }
        
        var editarPlanoVm = _mapper.Map<Planos>(editarPlanoViewModel);

        var resultado = _repositorioPlanos.Editar(editarPlanoViewModel.Id, editarPlanoVm, editarPlanoVm.GrupoId);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
           
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O {editarPlanoViewModel.Plano} foi EDITADO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _repositorioPlanos.SelecionarPorId(id);

        var excluirPlanoVm = _mapper.Map<DetalhesPlanoViewModel>(resultado.Value);
        
        return View(excluirPlanoVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesPlanoViewModel detalhesPlanoViewModel)
    {
        var resultado = _repositorioPlanos.Excluir(detalhesPlanoViewModel.Id);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _repositorioPlanos.SelecionarPorId(id);

        var detalhesPlanoVm = _mapper.Map<DetalhesPlanoViewModel>(resultado.Value);

        return View(detalhesPlanoVm);
    }
    
    #region Metodos

    private InserirPlanoViewModel? CarregarInformacoes(InserirPlanoViewModel inserirPlanoViewModel)
    {
        var resultadosGrupos = _repositorioGruposAutomoveis.SelecionarTodos();

        var grupos = resultadosGrupos.Value;
        
        inserirPlanoViewModel.Grupos = grupos.Select(g =>
            new SelectListItem(g.Grupo.ToString(),g.Id.ToString()));
        
        return inserirPlanoViewModel;
    }
    
    private EditarPlanoViewModel? CarregarInformacoes(EditarPlanoViewModel editarPlanoViewModel)
    {
        var resultadosGrupos = _repositorioGruposAutomoveis.SelecionarTodos();

        var grupos = resultadosGrupos.Value;
        
        editarPlanoViewModel.Grupos = grupos.Select(g =>
            new SelectListItem(g.Grupo.ToString(),g.Id.ToString()));
        
        return editarPlanoViewModel;
    }

    #endregion
}