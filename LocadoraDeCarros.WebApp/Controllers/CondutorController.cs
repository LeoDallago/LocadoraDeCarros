using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers;

[Authorize (Roles = "Empresa")]
public class CondutorController : WebControllerBase
{
    private readonly CondutorService _condutorService;
    private readonly ClienteService _clienteService;
    private readonly IMapper _mapper;
    
    public CondutorController(CondutorService condutorService, ClienteService clienteService, IMapper mapper)
    {
        _condutorService = condutorService;
        _clienteService = clienteService;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var condutores = _condutorService.SelecionarTodos();
        
        var listarCondutorVm = _mapper.Map<IEnumerable<ListarCondutorViewModel>>(condutores.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarCondutorVm);
    }

    public IActionResult Inserir()
    {
        return View(CarregarInformacoes(new InserirCondutorViewModel()));
    }

    [HttpPost]
    public IActionResult Inserir(InserirCondutorViewModel inserirCondutorVm)
    {
        if (!ModelState.IsValid)
        {
            return View(inserirCondutorVm);
        }
        
        var novoCondutor = _mapper.Map<Condutor>(inserirCondutorVm);

        novoCondutor.UsuarioId = UsuarioId.GetValueOrDefault();
        
        int clienteId = inserirCondutorVm.ClienteId;
        
        _condutorService.Inserir(novoCondutor, clienteId);
        
        ApresentarMensagemSucesso($"{novoCondutor.Nome} inserido com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var condutor = _condutorService.SelecionarPorId(id);
        
        var editarCondutorVm = _mapper.Map<EditarCondutorViewModel>(condutor.Value);
        
        return View(CarregarInformacoes(editarCondutorVm));
    }

    [HttpPost]
    public IActionResult Editar(EditarCondutorViewModel editarCondutorVm)
    {
        if (!ModelState.IsValid)
        {
            return View(editarCondutorVm);
        }

        var editarCondutorViewModel = _mapper.Map<Condutor>(editarCondutorVm);
        
        _condutorService.Editar(editarCondutorViewModel.Id,editarCondutorViewModel, editarCondutorVm.ClienteId);
        
        ApresentarMensagemSucesso($"{editarCondutorVm.Nome} EDITADO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
        
    }

    public IActionResult Excluir(int id)
    {
        var condutor = _condutorService.SelecionarPorId(id);
        
        var detalhesCondutor = _mapper.Map<DetalhesCondutorViewModel>(condutor.Value);
        
        return View(detalhesCondutor);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesCondutorViewModel excluirCondutorVm)
    {
        _condutorService.Excluir(excluirCondutorVm.Id);
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var condutor = _condutorService.SelecionarPorId(id);
        
        var detalhesCondutorVm = _mapper.Map<DetalhesCondutorViewModel>(condutor.Value);
        
        return View(detalhesCondutorVm);
    }
    
    #region Metodos

    private InserirCondutorViewModel? CarregarInformacoes(InserirCondutorViewModel inserirCondutorViewModel)
    {
        var resultadosClientes = _clienteService.SelecionarTodos();

        var grupos = resultadosClientes.Value;
        
        inserirCondutorViewModel.Clientes = grupos.Select(g =>
            new SelectListItem(g.Nome,g.Id.ToString()));
        
        return inserirCondutorViewModel;
    }
    
    private EditarCondutorViewModel? CarregarInformacoes(EditarCondutorViewModel editarCondutorViewModel)
    {
        var resultadosClientes = _clienteService.SelecionarTodos();

        var grupos = resultadosClientes.Value;
        
        editarCondutorViewModel.Clientes = grupos.Select(g =>
            new SelectListItem(g.Nome,g.Id.ToString()));
        
        return editarCondutorViewModel;
    }

    #endregion
}