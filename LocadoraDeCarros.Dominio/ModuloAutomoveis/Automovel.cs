using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Dominio.ModuloAutomoveis;

public class Automovel : EntidadeBase
{
    public string Marca { get; set; }
    
    public string Modelo { get; set; }
    
    public string Cor { get; set; }
    
    public string TipoCombustivel { get; set; }
    
    public string CapacidadeCombustivel { get; set; }
    
    public string Ano { get; set; }

    
    #region Grupo automovel

    public int GrupoId { get; set; }
    
    public GrupoAutomoveis Grupo { get; set; }

    #endregion

    
    public Automovel()
    {
        
    }

    public Automovel(string marca, string modelo, string cor, string tipoCombustivel, string capacidadeCombustivel, string ano, GrupoAutomoveis grupo)
    {
        Marca = marca;
        Modelo = modelo;
        Cor = cor;
        TipoCombustivel = tipoCombustivel;
        CapacidadeCombustivel = capacidadeCombustivel;
        Ano = ano;
        Grupo = grupo;
    }
}