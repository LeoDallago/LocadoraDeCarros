using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraDeCarros.WebApp.Controllers;

public class TaxaController : WebControllerBase
{
    private TaxaService _taxaService;
    private readonly IMapper _mapper;

    public TaxaController(TaxaService taxaService, IMapper mapper)
    {
        _taxaService = taxaService;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var taxas = _taxaService.SelecionarTodos();

        var listarTaxaVm = _mapper.Map<IEnumerable<ListarTaxaViewModel>>(taxas.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarTaxaVm);
    }
    

    public IActionResult Inserir()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Inserir(InserirTaxaViewModel inserirTaxaViewModel)
    {
        if (!ModelState.IsValid) 
            return View(inserirTaxaViewModel);
        
        var novaTaxa = _mapper.Map<Taxa>(inserirTaxaViewModel);
        
        var resultado = _taxaService.Inserir(novaTaxa);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }

        ApresentarMensagemSucesso($"O registro {inserirTaxaViewModel.Nome} foi INSERIDO com sucesso!");

        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var taxa = _taxaService.SelecionarPorId(id);
        
        if (taxa.IsFailed)
        {
            ApresentarMensagemFalha(taxa.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        var editarTaxaViewModel = _mapper.Map<EditarTaxaViewModel>(taxa.Value);
        
        return View(editarTaxaViewModel);
    }

    [HttpPost]
    public IActionResult Editar(EditarTaxaViewModel editarTaxaViewModel)
    {
        if (!ModelState.IsValid) 
            return View(editarTaxaViewModel);
        
        var editarTaxaVm = _mapper.Map<Taxa>(editarTaxaViewModel);
        
        var resultado = _taxaService.Editar(editarTaxaViewModel.Id, editarTaxaVm);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
           
            return RedirectToAction(nameof(Listar));
        }
       
        ApresentarMensagemSucesso($"O registro {editarTaxaVm.Nome} foi EDITADO com sucesso!");
       
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var taxa = _taxaService.SelecionarPorId(id);
        
        var excluirTaxaVm = _mapper.Map<ListarTaxaViewModel>(taxa.Value);
        
        return View(excluirTaxaVm);
    }

    [HttpPost]
    public IActionResult Excluir(ListarTaxaViewModel excluirTaxaViewModel)
    {
        var resultado = _taxaService.Excluir(excluirTaxaViewModel.Id);
        
        if (resultado.IsFailed)
        {
            ApresentarMensagemFalha(resultado.ToResult());
            
            return RedirectToAction(nameof(Listar));
        }
        
        ApresentarMensagemSucesso($"O registro foi EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }
}