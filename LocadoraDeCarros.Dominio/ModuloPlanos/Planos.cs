using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Dominio.ModuloPlanos;

public class Planos : EntidadeBase
{
    public string Plano { get; set; }
    
    public decimal PrecoDiaria { get; set; }
    
    public decimal PrecoKm { get; set; }
    
    public decimal KmDisponivel { get; set; }
    
    public decimal KmLivre { get; set; }
    
    public int GrupoId { get; set; }
    
    public GrupoAutomoveis Grupo { get; set; }


    public Planos()
    {
        
    }

    public Planos(string plano, decimal precoDiaria)
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
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
        decimal kmLivre,
        int grupoId,
        GrupoAutomoveis grupo
        )
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        KmDisponivel = kmDisponivel;
        KmLivre = kmLivre;
        GrupoId = grupoId;
        Grupo = grupo;
    }

    public Planos(
        string plano,
        decimal precoDiaria,
        decimal precoKm,
        decimal kmDisponivel,
        decimal kmLivre,
        int grupoId,
        GrupoAutomoveis grupo
        )
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        PrecoKm = precoKm;
        KmDisponivel = kmDisponivel;
        KmLivre = kmLivre;
        GrupoId = grupoId;
        Grupo = grupo;
    }

    public Planos(string plano, int precoDiaria, decimal precoKm)
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        PrecoKm = precoKm;
    }
    
    public Planos(string plano, int precoDiaria, decimal precoKm,decimal kmLivre)
    {
        Plano = plano;
        PrecoDiaria = precoDiaria;
        PrecoKm = precoKm;
        KmLivre = kmLivre;
    }
}