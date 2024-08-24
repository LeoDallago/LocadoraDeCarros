using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirTaxaViewModel
{
    [Required(ErrorMessage = "O nome da taxa ou serviço é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O preço é obrigatório")]
    public decimal Preco{ get; set; }
    
    [Required(ErrorMessage = "O tipo de plano é obrigatório")]
    public string PlanoCobranca{ get; set; }
}

public class EditarTaxaViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome da taxa ou serviço é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O preço é obrigatório")]
    public decimal Preco{ get; set; }
    
    [Required(ErrorMessage = "O tipo de plano é obrigatório")]
    public string PlanoCobranca{ get; set; }
}

public class ListarTaxaViewModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public decimal Preco{ get; set; }
    
    public string PlanoCobranca{ get; set; }
}