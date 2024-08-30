using AutoMapper;
using FluentResults;
using LocadoraDeCarros.Aplicacao;
using LocadoraDeCarros.Aplicacao.Servicos;
using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.WebApp.Controllers.Compartilhado;
using LocadoraDeCarros.WebApp.Extensions;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Controllers;

public class AluguelController : WebControllerBase
{
    private readonly AluguelService _aluguelService;
    private readonly CondutorService _condutorService;
    private readonly AutomoveisService _automoveisService;
    private readonly PlanosService _planosService;
    private readonly TaxaService _taxaService;
    private readonly IMapper _mapper;


    public AluguelController(
        AluguelService aluguelService,
        CondutorService condutorService,
        AutomoveisService automoveisService,
        PlanosService planosService,
        TaxaService taxaService,
        IMapper mapper
        )
    {
        _aluguelService = aluguelService;
        _condutorService = condutorService;
        _automoveisService = automoveisService;
        _planosService = planosService;
        _taxaService = taxaService;
        _mapper = mapper;
    }

    public IActionResult Listar()
    {
        var alugueis = _aluguelService.SelecionarTodos();

        var listarALuguelVm = _mapper.Map<IEnumerable<ListarAluguelViewModel>>(alugueis.Value);
        
        ViewBag.Mensagem = TempData.DesserializarMensagemViewModel();
        
        return View(listarALuguelVm);
    }
    

    public IActionResult Inserir()
    {
        return View(CarregarInformacoes(new InserirAluguelViewModel()));
    }

    [HttpPost]
    public IActionResult Inserir(InserirAluguelViewModel inserirAluguelViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(inserirAluguelViewModel);
        }
        
        var novoAluguel = _mapper.Map<Aluguel>(inserirAluguelViewModel);

        int condutorId = inserirAluguelViewModel.CondutorId;
        int automovelId = inserirAluguelViewModel.AutomovelId;
        int planoId = inserirAluguelViewModel.PlanoId;
        int taxaId = inserirAluguelViewModel.TaxaId;
        
        
       var resultado =_aluguelService.Inserir(novoAluguel, condutorId, automovelId, planoId, taxaId);
       
       ApresentarMensagemSucesso("Aluguel INSERIDO com sucesso!");
       
       return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var resultado = _aluguelService.SelecionarPorId(id);
        
        var editarAluguelVm = _mapper.Map<EditarAluguelViewModel>(resultado.Value);
        
        return View(CarregarInformacoes(editarAluguelVm));
    }

    [HttpPost]
    public IActionResult Editar(EditarAluguelViewModel editarAluguelViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(editarAluguelViewModel);
        }
        
        var editarAluguelVm = _mapper.Map<Aluguel>(editarAluguelViewModel);
        
        _aluguelService.Editar(
            editarAluguelVm.Id,
            editarAluguelVm,
            editarAluguelVm.CondutorId,
            editarAluguelVm.AutomovelId,
            editarAluguelVm.PlanoId,
            editarAluguelVm.TaxaId
            );
        
        ApresentarMensagemSucesso("Aluguel EDITADO com sucesso!");
       
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Excluir(int id)
    {
        var resultado = _aluguelService.SelecionarPorId(id);
        
        var detalhesAluguelVm = _mapper.Map<DetalhesAluguelViewModel>(resultado.Value);
        
        if (detalhesAluguelVm.Concluido == false)
        {
            ApresentarMensagemInSucesso("Aluguel não concluido");

            return RedirectToAction(nameof(Listar));
        }
        
        return View(detalhesAluguelVm);
    }

    [HttpPost]
    public IActionResult Excluir(DetalhesAluguelViewModel detalhesAluguelViewModel)
    {
        _aluguelService.Excluir(detalhesAluguelViewModel.Id);
     
        ApresentarMensagemSucesso("Aluguel EXCLUIDO com sucesso!");
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Detalhes(int id)
    {
        var resultado = _aluguelService.SelecionarPorId(id);
        
        var detalhesAluguelVm = _mapper.Map<DetalhesAluguelViewModel>(resultado.Value);
        
        return View(detalhesAluguelVm);
    }


    public IActionResult Concluir(int id)
    {
        var resultado = _aluguelService.SelecionarPorId(id);
        
        var detalhesAluguelVm = _mapper.Map<EditarAluguelViewModel>(resultado.Value);
        
        return View(detalhesAluguelVm);
    }

    [HttpPost]
    public IActionResult Concluir(EditarAluguelViewModel editarAluguelViewModel)
    {
        editarAluguelViewModel.Concluido = true;
       var editarAluguelVm = _mapper.Map<Aluguel>(editarAluguelViewModel);
        
       _aluguelService.Editar(
           editarAluguelVm.Id,
           editarAluguelVm,
           editarAluguelVm.CondutorId,
           editarAluguelVm.AutomovelId,
           editarAluguelVm.PlanoId,
           editarAluguelVm.TaxaId
       );
       ApresentarMensagemSucesso("Aluguel CONCLUIDO com sucesso!");
        
       return RedirectToAction(nameof(Listar));
    }

    #region Metodos

    private InserirAluguelViewModel? CarregarInformacoes(InserirAluguelViewModel inserirAluguelViewModel)
    {
        var condutores = _condutorService.SelecionarTodos();
        var grupoCondutores = condutores.Value;
        
        inserirAluguelViewModel.Condutores = grupoCondutores.Select(c =>  new SelectListItem(c.Nome, c.Id.ToString()));

        var automoveis = _automoveisService.SelecionarTodos();
        var grupoAutomoveis = automoveis.Value;
        
        inserirAluguelViewModel.Automoveis = grupoAutomoveis.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

        var planos = _planosService.SelecionarTodos();
        var grupoPlanos = planos.Value;
        
        inserirAluguelViewModel.Planos = grupoPlanos.Select(c => new SelectListItem(c.Plano,c.Id.ToString()));

        var taxas = _taxaService.SelecionarTodos();
        var grupoTaxas = taxas.Value;
        
        inserirAluguelViewModel.Taxas = grupoTaxas.Select(c => new SelectListItem(c.Nome,c.Id.ToString()));
        
        return inserirAluguelViewModel;
    }

    private EditarAluguelViewModel? CarregarInformacoes(EditarAluguelViewModel editarAluguelViewModel)
    {
        var condutores = _condutorService.SelecionarTodos();
        var grupoCondutores = condutores.Value;
        
        editarAluguelViewModel.Condutores = grupoCondutores.Select(c =>  new SelectListItem(c.Nome, c.Id.ToString()));

        var automoveis = _automoveisService.SelecionarTodos();
        var grupoAutomoveis = automoveis.Value;
        
        editarAluguelViewModel.Automoveis = grupoAutomoveis.Select(c => new SelectListItem(c.Modelo, c.Id.ToString()));

        var planos = _planosService.SelecionarTodos();
        var grupoPlanos = planos.Value;
        
        editarAluguelViewModel.Planos = grupoPlanos.Select(c => new SelectListItem(c.Plano,c.Id.ToString()));

        var taxas = _taxaService.SelecionarTodos();
        var grupoTaxas = taxas.Value;
        
        editarAluguelViewModel.Taxas = grupoTaxas.Select(c => new SelectListItem(c.Nome,c.Id.ToString()));
        
        return editarAluguelViewModel;
    }
    #endregion
}