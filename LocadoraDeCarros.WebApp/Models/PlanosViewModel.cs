using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirPlanoViewModel
{
    [Required(ErrorMessage = "O Plano é obrigatório")]
    public string Plano { get; set; }
    
    public string PrecoDiaria { get; set; }
    
    public string PrecoKm { get; set; }
    
    public string KmDisponivel { get; set; }
    
    public string KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
    
    public IEnumerable<SelectListItem>? Grupos { get; set; }
}

public class EditarPlanoViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O Plano é obrigatório")]
    public string Plano { get; set; }
    
    public string PrecoDiaria { get; set; }
    
    public string PrecoKm { get; set; }
    
    public string KmDisponivel { get; set; }
    
    public string KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
    
    public IEnumerable<SelectListItem>? Grupos { get; set; }
}

public class ListarPlanoViewModel
{
    public int Id { get; set; }
    
    public string Plano { get; set; }
    
    public string PrecoDiaria { get; set; }
    
    public string PrecoKm { get; set; }
    
    public string KmDisponivel { get; set; }
    
    public string KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
}

public class DetalhesPlanoViewModel
{
    public int Id { get; set; }
    
    public string Plano { get; set; }
    
    public string PrecoDiaria { get; set; }
    
    public string PrecoKm { get; set; }
    
    public string KmDisponivel { get; set; }
    
    public string KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
}

