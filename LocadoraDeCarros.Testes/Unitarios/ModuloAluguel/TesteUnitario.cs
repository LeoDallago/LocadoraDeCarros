using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloAluguel;


[TestClass]
[TestCategory("testes unitarios modulo aluguel")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Aluguel()
    {
        //Arrange
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Planos planos = new Planos();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        //Act
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
            );
        
        //Assert
        Assert.IsFalse(aluguelTeste.Concluido);
    }

    [TestMethod]
    public void Deve_Atualizar_Aluguel()
    {
        //Arrange
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Planos planos = new Planos();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        
        //Act
        aluguelTeste.Concluido = true;
        
        //Assert
        Assert.IsTrue(aluguelTeste.Concluido);
    }

    [TestMethod]
    public void Deve_Encerrar_Aluguel()
    {
        //Arrange
        var aluguel = new Aluguel();
        aluguel.Concluido = false;

        //Act
        aluguel.ConcluirAluguel();

        //Assert
        Assert.IsTrue(aluguel.Concluido);
    }
}