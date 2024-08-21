using System.ComponentModel.DataAnnotations;

namespace LocadoraDeCarros.WebApp.Models;

public class InserirGrupoAutomoveisViewModel
{
    [Required(ErrorMessage = "O nome do grupo é obrigatório")]
    public string Grupo { get; set; }
}

public class EditarGrupoAutomoveisViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome do grupo é obrigatório")]
    public string Grupo { get; set;}
}

public class ListarGrupoAutomoveisViewModel
{
    public int Id { get; set; }
    
    public string Grupo { get; set; }
}

public class DetalhesGrupoAutomoveisViewModel
{
    public int Id { get; set; }
    
    public string Grupo { get; set; }
}

