using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class ConfiguracoesViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Digite o PREÇO da GASOLINA")]
    public decimal Gasolina { get; set; }
    
    [Required(ErrorMessage = "Digite o PREÇO do GAS")]
    public decimal Gas  { get; set; }
    
    [Required(ErrorMessage = "Digite o PREÇO do DIESEL")]
    public decimal Diesel { get; set; }
    
    [Required(ErrorMessage = "Digite o PREÇO do ALCOOL")]
    public decimal Alcool { get; set; }
}