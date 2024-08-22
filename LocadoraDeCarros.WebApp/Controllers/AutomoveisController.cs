using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers;

public class AutomoveisController : WebControllerBase
{
    private readonly AutomoveisService _repositorioAutomovel;
    private readonly GrupoAutomoveisService _repositorioGrupoAutomoveis;
    private readonly IMapper _mapper;


    public AutomoveisController(AutomoveisService repositorioAutomovel, GrupoAutomoveisService repositorioGrupoAutomoveis, IMapper mapper)
    {
        _repositorioAutomovel = repositorioAutomovel;
        _repositorioGrupoAutomoveis = repositorioGrupoAutomoveis;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = _repositorioAutomovel.SelecionarTodos();

        var listarAutomoveis = resultado.Value;
        
        var listarVeiculosVm = _mapper.Map<IEnumerable<ListarAutomovelViewModel>>(listarAutomoveis);

        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarVeiculosVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarInformacoes(new InserirAutomovelViewModel()));
    }

    [HttpPost]
    public IActionResult Inserir(InserirAutomovelViewModel inserirAutomovelViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inserirAutomovelViewModel);
        }
        
        var novoAutomovel = _mapper.Map<Automovel>(inserirAutomovelViewModel);
        
        int grupoId = inserirAutomovelViewModel.GrupoId;
        
        var resultado  = _repositorioAutomovel.Inserir(novoAutomovel, grupoId);
        
        ApresentarMensagemSucesso($"Veiculo {novoAutomovel.Modelo} inserido com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _repositorioAutomovel.SelecionarPorId(id);
        
        var editarAutomovelViewModel = _mapper.Map<EditarAutomovelViewModel>(resultado.Value);
        
        return View(CarregarInformacoes(editarAutomovelViewModel));
    }

    [HttpPost]
    public IActionResult Editar(EditarAutomovelViewModel editarAutomovelViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editarAutomovelViewModel);
        }
        
        var editarAutomovelVm = _mapper.Map<Automovel>(editarAutomovelViewModel);
        
        var resultado = _repositorioAutomovel.Editar(editarAutomovelViewModel.Id, editarAutomovelVm,editarAutomovelVm.GrupoId);

        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
           
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"Veiculo {editarAutomovelViewModel.Modelo} inserido com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _repositorioAutomovel.SelecionarPorId(id);
        
        var excluirAutomovelVm = _mapper.Map<DetalhesAutomovelViewModel>(resultado.Value);
        
        return View(excluirAutomovelVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesAutomovelViewModel excluirAutomovelViewModel)
    {
        var resultado = _repositorioAutomovel.Excluir(excluirAutomovelViewModel.Id);
        
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
        var resultado = _repositorioAutomovel.SelecionarPorId(id);
        
        var detalhesVm = _mapper.Map<DetalhesAutomovelViewModel>(resultado.Value);
        
        return View(detalhesVm);
    }    
        
    #region Metodos

    private InserirAutomovelViewModel? CarregarInformacoes(InserirAutomovelViewModel inserirAutomovelViewModel)
    {
        var resultadosGrupos = _repositorioGrupoAutomoveis.SelecionarTodos();

        var grupos = resultadosGrupos.Value;
        
        inserirAutomovelViewModel.Grupos = grupos.Select(g =>
            new SelectListItem(g.Grupo.ToString(),g.Id.ToString()));
        
        return inserirAutomovelViewModel;
    }
    
    private EditarAutomovelViewModel? CarregarInformacoes(EditarAutomovelViewModel editarAutomovelViewModel)
    {
        var resultadosGrupos = _repositorioGrupoAutomoveis.SelecionarTodos();

        var grupos = resultadosGrupos.Value;
        
        editarAutomovelViewModel.Grupos = grupos.Select(g =>
            new SelectListItem(g.Grupo.ToString(),g.Id.ToString()));
        
        return editarAutomovelViewModel;
    }

    #endregion
}