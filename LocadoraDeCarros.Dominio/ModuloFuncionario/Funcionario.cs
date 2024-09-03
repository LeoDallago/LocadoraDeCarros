using LocadoraDeCarros.Dominio.Compartilhado;

namespace LocadoraDeCarros.Dominio.ModuloFuncionario;

public class Funcionario : EntidadeBase
{
    public string Nome { get; set; }
    
    public DateTime Admissao { get; set; }
    
    public decimal Salario { get; set; }

    public Funcionario()
    {
        
    }

    public Funcionario(string nome, DateTime admissao, decimal salario)
    {
        Nome = nome;
        Admissao = admissao;
        Salario = salario;
    }
}