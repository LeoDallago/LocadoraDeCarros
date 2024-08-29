﻿using LocadoraDeCarros.Dominio.Compartilhado;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;

namespace LocadoraDeCarros.Dominio.ModuloAluguel;

public class Aluguel : EntidadeBase
{

    public int CondutorId { get; set; }

    public Condutor Condutor { get; set; }

    public int AutomovelId { get; set; }

    public Automovel Automovel { get; set; }
    
    public DateTime DataSaida { get; set; }
    
    public DateTime DataRetorno { get; set; }
    
    public int PlanoId { get; set; }

    public Planos Plano { get; set; }
    
    public int TaxaId { get; set; }

    public Taxa Taxa { get; set; }
    
    public bool Concluido { get; set; }
    
    public decimal ValorTotal { get; set; }

    
    public Aluguel()
    {
        
    }
    
    public Aluguel(
        Condutor condutor,
        Automovel automovel,
        DateTime dataSaida,
        DateTime dataRetorno,
        Planos plano,
        Taxa taxa,
        bool concluido,
        decimal valorTotal
        )
    {
        Condutor = condutor;
        Automovel = automovel;
        DataSaida = dataSaida;
        DataRetorno = dataRetorno;
        Plano = plano;
        Taxa = taxa;
        Concluido = concluido;
        ValorTotal = valorTotal;
    }

    public void ConcluirAluguel()
    {
        Concluido = true;
    }
    
    public Aluguel(
        int condutorId,
        Condutor condutor,
        int automovelId,
        Automovel automovel,
        DateTime dataSaida,
        DateTime dataRetorno,
        int planoId,
        Planos plano,
        int taxaId,
        Taxa taxa,
        bool concluido,
        decimal valorTotal
        )
    {
        CondutorId = condutorId;
        Condutor = condutor;
        AutomovelId = automovelId;
        Automovel = automovel;
        DataSaida = dataSaida;
        DataRetorno = dataRetorno;
        PlanoId = planoId;
        Plano = plano;
        TaxaId = taxaId;
        Taxa = taxa;
        Concluido = concluido;
        ValorTotal = valorTotal;
    }
    
    //todo fazer calcular valor total
}
