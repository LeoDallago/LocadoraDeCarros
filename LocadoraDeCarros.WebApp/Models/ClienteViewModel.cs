using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirClienteViewModel
{
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O Email é obrigatório")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O Telefone é obrigatório")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O Estado é obrigatório")]
    public string Estado { get; set; }
    
    [Required(ErrorMessage = "A Cidade é obrigatória")]
    public string Cidade { get; set; }
    
    [Required(ErrorMessage = "O Bairro é obrigatório")]
    public string Bairro { get; set; }
    
    [Required(ErrorMessage = "A Rua é obrigatória")]
    public string Rua { get; set; }
    
    [Required(ErrorMessage = "O Numero da Casa é obrigatório")]
    public string Numero { get; set; }
    
    [Required(ErrorMessage = "O Tipo de Cliente é obrigatório")]
    public string TipoCliente { get; set; }
}

public class EditarClienteViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O Email é obrigatório")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O Telefone é obrigatório")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O Estado é obrigatório")]
    public string Estado { get; set; }
    
    [Required(ErrorMessage = "A Cidade é obrigatória")]
    public string Cidade { get; set; }
    
    [Required(ErrorMessage = "O Bairro é obrigatório")]
    public string Bairro { get; set; }
    
    [Required(ErrorMessage = "A Rua é obrigatória")]
    public string Rua { get; set; }
    
    [Required(ErrorMessage = "O Numero da Casa é obrigatório")]
    public string Numero { get; set; }
    
    [Required(ErrorMessage = "O Tipo de Cliente é obrigatório")]
    public string TipoCliente { get; set; }
}

public class ListarClienteViewModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Telefone { get; set; }
    
    public string TipoCliente { get; set; }
}

public class DetalhesClienteViewModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string Estado { get; set; }
    
    public string Cidade { get; set; }
    
    public string Bairro { get; set; }
    
    public string Rua { get; set; }
    
    public string Numero { get; set; }
    
    public string TipoCliente { get; set; }
}