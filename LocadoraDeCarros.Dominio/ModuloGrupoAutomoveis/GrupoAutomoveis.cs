using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

public class GrupoAutomoveis : EntidadeBase
{
    public string Grupo { get; set; }
    
    public GrupoAutomoveis() { }

    public GrupoAutomoveis(string grupo)
    {
        Grupo = grupo;
    }
}