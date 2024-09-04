using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirCondutorViewModel
{
    [Required(ErrorMessage = "O nome do condutor é obrigatório")]
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O telefone do condutor é obrigatório")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O CPF do condutor é obrigatório")]
    public string CPF { get; set; }
    
    [Required(ErrorMessage = "A CNH do condutor é obrigatório")]
    public string CNH { get; set; }
    
    [Required(ErrorMessage = "A validade do condutor é obrigatório")]
    public DateTime Validade { get; set; }
    
    
    public int ClienteId { get; set; }
    
    public IEnumerable<SelectListItem>? Clientes { get; set; }
}

public class EditarCondutorViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do condutor é obrigatório")]
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O telefone do condutor é obrigatório")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "O CPF do condutor é obrigatório")]
    public string CPF { get; set; }
    
    [Required(ErrorMessage = "A CNH do condutor é obrigatório")]
    public string CNH { get; set; }
    
    [Required(ErrorMessage = "A validade do condutor é obrigatório")]
    public DateTime Validade { get; set; }
    
    
    public int ClienteId { get; set; }
    
    public IEnumerable<SelectListItem>? Clientes { get; set; }
}

public class ListarCondutorViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public string CPF { get; set; }
    
    public string CNH { get; set; }
    
    public string Validade { get; set; }
    
    public int ClienteId { get; set; }
}

public class DetalhesCondutorViewModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Email { get; set; }
    
    public string Telefone { get; set; }
    
    public string CPF { get; set; }
    
    public string CNH { get; set; }
    
    public DateTime Validade { get; set; }

    public int ClienteId { get; set; }
}