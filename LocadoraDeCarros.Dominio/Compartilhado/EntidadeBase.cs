using LocadoraDeCarros.Dominio.ModuloUsuario;

namespace LocadoraDeCarros.Dominio.Compartilhado;

public class EntidadeBase
{
    public int Id { get; set; }
    
    public int UsuarioId { get; set; }
    
    public Usuario? Usuario { get; set; }
}