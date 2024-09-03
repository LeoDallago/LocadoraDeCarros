using Microsoft.AspNetCore.Identity;

namespace LocadoraDeCarros.Dominio.ModuloUsuario;

public class Usuario : IdentityUser<int>
{
    public Usuario()
    {
        EmailConfirmed = true;
    }
}