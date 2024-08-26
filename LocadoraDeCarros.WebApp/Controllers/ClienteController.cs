using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class ClienteController : WebControllerBase
{
    private readonly ClienteService _clienteService;
    private readonly IMapper _mapper;
    
    public ClienteController(ClienteService clienteService, IMapper mapper)
    {
        _clienteService = clienteService;
        _mapper = mapper;
    }


    public IActionResult Listar()
    {
        var resultado = _clienteService.SelecionarTodos();

        var listarClientesVm = _mapper.Map<IEnumerable<ListarClienteViewModel>>(resultado.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarClientesVm);
    }
    
    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirClienteViewModel inserirClienteVm)
    {
        if (!ModelState.IsValid) 
            return View(inserirClienteVm);
        
        var novoCLiente = _mapper.Map<Cliente>(inserirClienteVm);

        var resultado = _clienteService.Inserir(novoCLiente);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro {novoCLiente.Nome} foi INSERIDO com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int Id)
    {
        var cliente = _clienteService.SelecionarPorId(Id);
        
        var editarClienteVm = _mapper.Map<EditarClienteViewModel>(cliente.Value);
        
        return View(editarClienteVm);
    }

    [HttpPost]
    public IActionResult Editar(EditarClienteViewModel editarClienteVm)
    {
        if (!ModelState.IsValid)
        {
            return View(editarClienteVm);
        }
        
        var editarCLienteVm = _mapper.Map<Cliente>(editarClienteVm);
        
        var resultado = _clienteService.Editar(editarCLienteVm, editarClienteVm.Id);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
           
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro {editarClienteVm.Nome} foi EDITADO com sucesso!");
        
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var cliente = _clienteService.SelecionarPorId(id);
        
        if (cliente.IsFailed)
        {
            ApresentarMensagemFalha(cliente.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        var detalhesClienteVm = _mapper.Map<DetalhesClienteViewModel>(cliente.Value);
        
        return View(detalhesClienteVm);
    }


    [HttpPost]
    public IActionResult Excluir(DetalhesClienteViewModel detalhesClienteVm)
    {
        var cliente = _clienteService.Excluir(detalhesClienteVm.Id);
        
        if (cliente.IsFailed)
        {
            ApresentarMensagemFalha(cliente.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var cliente = _clienteService.SelecionarPorId(id);
        
        if (cliente.IsFailed)
        {
            ApresentarMensagemFalha(cliente.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        var detalhesClienteVm = _mapper.Map<DetalhesClienteViewModel>(cliente.Value);
        
        return View(detalhesClienteVm);
    }
}