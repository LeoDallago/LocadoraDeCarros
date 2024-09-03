using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloFuncionario;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

[Authorize(Roles = "Empresa")]
public class FuncionarioController : WebControllerBase
{
    private readonly FuncionarioService _funcionarioService;
    private readonly IMapper _mapper;


    public FuncionarioController(FuncionarioService funcionarioService, IMapper mapper)
    {
        _funcionarioService = funcionarioService;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var resultado = _funcionarioService.SelecionarTodos();

        var listarFuncionariosVm = _mapper.Map<IEnumerable<ListarFuncionarioViewModel>>(resultado.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        return View(listarFuncionariosVm);
    }
    

    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirFuncionarioViewModel inserirFuncionarioViewModel)
    {
        if (!ModelState.IsValid) 
            return View(inserirFuncionarioViewModel);
        
        var novoFuncionario = _mapper.Map<Funcionario>(inserirFuncionarioViewModel);

        novoFuncionario.UsuarioId = UsuarioId.GetValueOrDefault();
        
        var resultado = _funcionarioService.Inserir(novoFuncionario);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro {novoFuncionario.Nome} foi INSERIDO com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _funcionarioService.SelecionarPorId(id);
        
        var editarFuncionarioVm = _mapper.Map<EditarFuncionarioViewModel>(resultado.Value);
        
        return View(editarFuncionarioVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarFuncionarioViewModel editarFuncionarioViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editarFuncionarioViewModel);
        }
        
        var editarfuncionario = _mapper.Map<Funcionario>(editarFuncionarioViewModel);
        
        var resultado = _funcionarioService.Editar(editarfuncionario,editarfuncionario.Id);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
           
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro {editarfuncionario.Nome} foi EDITADO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _funcionarioService.SelecionarPorId(id);
        
        var excluirFuncionarioVm = _mapper.Map<ListarFuncionarioViewModel>(resultado.Value);
        
        return View(excluirFuncionarioVm);
    }

    [HttpPost]
    public IActionResult Excluir(ListarFuncionarioViewModel excluirFuncionarioViewModel)
    {
        var funcionario = _funcionarioService.Excluir(excluirFuncionarioViewModel.Id);
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }
}