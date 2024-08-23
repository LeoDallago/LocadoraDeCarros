using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Dominio.ModuloPlanos;

public class Planos : EntidadeBase
{
    public string Plano { get; set; }
    
    public decimal PrecoDiaria { get; set; }
    
    public decimal PrecoKm { get; set; }
    
    public decimal KmDisponivel { get; set; }
    
    public decimal KmExtrapolado { get; set; }
    
    public int GrupoId { get; set; }
    
    public GrupoAutomoveis Grupo { get; set; }


    public Planos()
    {
        
    }

    public Planos(
        string plano,
        decimal precoDiaria,
        decimal precoKm,
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
        decimal precoDiaria,
        decimal kmDisponivel,
        decimal kmExtrapolado,
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
        decimal precoDiaria,
        decimal precoKm,
        decimal kmDisponivel,
        decimal kmExtrapolado,
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