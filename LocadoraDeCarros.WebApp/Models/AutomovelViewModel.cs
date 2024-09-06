using System.ComponentModel.DataAnnotations;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirAutomovelViewModel
{
    public IFormFile Foto { get; set; }
    public string Marca { get; set; }
    
    [Required(ErrorMessage = "O nome do veiculo é obrigatório")]
    public string Modelo { get; set; }
    
    [Required(ErrorMessage = "O cor do veiculo é obrigatório")]
    public string Cor { get; set; }
    
    [Required(ErrorMessage = "O tipo de combustivel é obrigatório")]
    public string TipoCombustivel { get; set; }
    
    [Required(ErrorMessage = "A capacidade de combustivel eh obrigatória")]
    public string CapacidadeCombustivel { get; set; }
    
    [Required(ErrorMessage = "O ano do veiculo é obrigatório")]
    public string Ano { get; set; }
    
    public int GrupoId { get; set; }
    
    public IEnumerable<SelectListItem>? Grupos { get; set; }
}

public class EditarAutomovelViewModel
{
    public int Id { get; set; }
    
    public string Marca { get; set; }
    
    [Required(ErrorMessage = "O nome do veiculo é obrigatório")]
    public string Modelo { get; set; }
    
    [Required(ErrorMessage = "O cor do veiculo é obrigatório")]
    public string Cor { get; set; }
    
    [Required(ErrorMessage = "O tipo de combustivel é obrigatório")]
    public string TipoCombustivel { get; set; }
    
    [Required(ErrorMessage = "A capacidade de combustivel eh obrigatória")]
    public string CapacidadeCombustivel { get; set; }
    
    [Required(ErrorMessage = "O ano do veiculo é obrigatório")]
    public string Ano { get; set; }
    
    public int GrupoId { get; set; }
    
    public IEnumerable<SelectListItem>? Grupos { get; set; }
}

public class ListarAutomovelViewModel
{
    public int Id { get; set; }
    
    public string Marca { get; set; }
    
    public string Modelo { get; set; }
    
    public string Cor { get; set; }

    public string TipoCombustivel { get; set; }
    
    public string CapacidadeCombustivel { get; set; }
    
    public string Ano { get; set; }
    
    public int GrupoId { get; set; }
    
}

public class DetalhesAutomovelViewModel
{
    public string Foto  { get; set; }
    
    public int Id { get; set; }
    
    public string Marca { get; set; }
    
    public string Modelo { get; set; }
    
    public string Cor { get; set; }

    public string TipoCombustivel { get; set; }
    
    public string CapacidadeCombustivel { get; set; }
    
    public string Ano { get; set; }
    
    public int GrupoId { get; set; }
    
}