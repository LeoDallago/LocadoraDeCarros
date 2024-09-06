using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirAluguelViewModel
{
    [Required(ErrorMessage = "CONDUTOR é obrigatório")]
    public int CondutorId { get; set; }
    
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    
    [Required(ErrorMessage = "AUTOMOVEL é obrigatório")]
    public int AutomovelId { get; set; }
    
    public IEnumerable<SelectListItem>? Automoveis { get; set; }
    
    [Required(ErrorMessage = "DATA DE SAIDA é obrigatório")]
    public DateTime DataSaida { get; set; }
    
    [Required(ErrorMessage = "DATA DE RETORNO é obrigatório")]
    public DateTime DataRetorno { get; set; }
    
    [Required(ErrorMessage = "PLANOS é obrigatório")]
    public int PlanoId { get; set; }
    
    public IEnumerable<SelectListItem>? Planos { get; set; }
    
    [Required(ErrorMessage = "TAXAS é obrigatório")]
    public int TaxaId { get; set; }
    
    public IEnumerable<SelectListItem>? Taxas { get; set; }
    
    public bool Concluido { get; set; }
    
    public decimal ValorTotal { get; set; }
}

public class EditarAluguelViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "CONDUTOR é obrigatório")]
    public int CondutorId { get; set; }
    
    public IEnumerable<SelectListItem>? Condutores { get; set; }
    
    [Required(ErrorMessage = "AUTOMOVEL é obrigatório")]
    public int AutomovelId { get; set; }
    
    public IEnumerable<SelectListItem>? Automoveis { get; set; }
    
    [Required(ErrorMessage = "DATA DE SAIDA é obrigatório")]
    public DateTime DataSaida { get; set; }
    
    [Required(ErrorMessage = "DATA DE RETORNO é obrigatório")]
    public DateTime DataRetorno { get; set; }
    
    [Required(ErrorMessage = "PLANOS é obrigatório")]
    public int PlanoId { get; set; }
    
    public IEnumerable<SelectListItem>? Planos { get; set; }
    
    [Required(ErrorMessage = "TAXAS é obrigatório")]
    public int TaxaId { get; set; }
    
    public IEnumerable<SelectListItem>? Taxas { get; set; }
    
    public bool Concluido { get; set; }
    
    public decimal ValorTotal { get; set; }
}

public class ListarAluguelViewModel
{
    public int Id { get; set; }
    
    public int CondutorId { get; set; }
    
    public string Condutor { get; set; }
    
    public int AutomovelId { get; set; }
    
    public string Automovel { get; set; }
    
    public DateTime DataSaida { get; set; }
    
    public DateTime DataRetorno { get; set; }
    
    public int PlanoId { get; set; }
    
    public int TaxaId { get; set; }
    
    
    public bool Concluido { get; set; }
    
    public string ValorTotal { get; set; }
}

public class DetalhesAluguelViewModel
{
    public int Id { get; set; }
    
    public int CondutorId { get; set; }
    
    
    public int AutomovelId { get; set; }
    
    
    public DateTime DataSaida { get; set; }
    
    public DateTime DataRetorno { get; set; }
    
    public int PlanoId { get; set; }
    
    
    public int TaxaId { get; set; }
    
    
    public bool Concluido { get; set; }
    
    public string ValorTotal { get; set; }
}