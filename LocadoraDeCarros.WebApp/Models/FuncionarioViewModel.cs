using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirFuncionarioViewModel
{
    [Required(ErrorMessage = "O nome do funcionario é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "A data de admissao e obrigatória")]
    public DateTime Admissao { get; set; }
    
    [Required(ErrorMessage = "O salario é obrigatório")]
    public decimal Salario { get; set; }
}

public class EditarFuncionarioViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do funcionario é obrigatório")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "A data de admissao e obrigatória")]
    public DateTime Admissao { get; set; }
    
    [Required(ErrorMessage = "O salario é obrigatório")]
    public decimal Salario { get; set; }
}

public class ListarFuncionarioViewModel
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public DateTime Admissao { get; set; }
    
    public decimal Salario { get; set; }
}