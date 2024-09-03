using System.Diagnostics;
using AutoMapper;
using LocadoraDeCarros.Aplicacao.Servicos;
using Microsoft.AspNetCore.Mvc;
using LocadoraDeCarros.WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace LocadoraDeCarros.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly AluguelService _aluguelService; 
    private IMapper _mapper;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AluguelService aluguelService, IMapper mapper)
    {
        _logger = logger;
        _aluguelService = aluguelService;
        _mapper = mapper;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var alugueis = _aluguelService.SelecionarTodos();
        
        var alugueisNaoConcluidos = _mapper.Map<IEnumerable<ListarAluguelViewModel>>(alugueis.Value).Where(model => model.Concluido == false);
        return View(alugueisNaoConcluidos);
    }
}