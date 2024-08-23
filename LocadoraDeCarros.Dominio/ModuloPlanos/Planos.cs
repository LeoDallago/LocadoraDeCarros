using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Dominio.ModuloPlanos;

public class Planos : EntidadeBase
{
    public string Plano { get; set; }
    
    public string PrecoDiaria { get; set; }
    
    public string PrecoKm { get; set; }
    
    public string KmDisponivel { get; set; }
    
    public string KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
    
    public GrupoAutomoveis Grupo { get; set; }


    public Planos()
    {
        
    }

    public Planos(
        string plano,
        string precoDiaria,
        string precoKm,
        int grupoId,
        GrupoAutomoveis grupo
        )
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        PrecoKm = precoKm;
        GrupoId = grupoId;
        Grupo = grupo;
    }

    public Planos(
        string plano,
        string precoDiaria,
        string kmDisponivel,
        string kmExtrapolado,
        int grupoId,
        GrupoAutomoveis grupo
        )
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        KmDisponivel = kmDisponivel;
        KmExtrapolado = kmExtrapolado;
        GrupoId = grupoId;
        Grupo = grupo;
    }

    public Planos(
        string plano,
        string precoDiaria,
        string precoKm,
        string kmDisponivel,
        string kmExtrapolado,
        int grupoId,
        GrupoAutomoveis grupo
        )
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        PrecoKm = precoKm;
        KmDisponivel = kmDisponivel;
        KmExtrapolado = kmExtrapolado;
        GrupoId = grupoId;
        Grupo = grupo;
    }
}