using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloConfiguracoes;

public class Configuracoes : EntidadeBase
{

    public decimal Gasolina { get; set; }
    
    public decimal Gas  { get; set; }
    
    public decimal Diesel { get; set; }
    
    public decimal Alcool { get; set; }

    public Configuracoes()
    {
        
    }
    
    public Configuracoes(decimal gasolina, decimal gas, decimal diesel, decimal alcool)
    {
        Gasolina = gasolina;
        Gas = gas;
        Diesel = diesel;
        Alcool = alcool;
    }
    
}
