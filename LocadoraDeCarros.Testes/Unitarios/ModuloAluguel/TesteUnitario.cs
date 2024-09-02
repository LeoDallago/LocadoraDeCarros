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

    [TestMethod]
    public void Deve_Calcular_Valor_Aluguel_Plano_Cobranca_livre()
    {
        var planoLivre = new Planos("Livre",200);
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now.AddDays(1),
            planoLivre,
            taxa,
            false
        );

        var resultado = aluguelTeste.Calcular();
        
        //Assert
        Assert.AreEqual(200m, resultado);
    }
    
    [TestMethod]
    public void Deve_Calcular_Valor_Aluguel_Plano_Cobranca_diario()
    {
        var planoDiario = new Planos("Diario",200, 100m);
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now.AddDays(1),
            planoDiario,
            taxa,
            false
        );
        aluguelTeste.KmRodados = 10;
        
        var resultado = aluguelTeste.Calcular();
        
        //Assert
        Assert.AreEqual(1200m, resultado);
    }
    
    [TestMethod]
    public void Deve_Calcular_Valor_Aluguel_Plano_Cobranca_controlado_dentro_do_limite()
    {
        var planoControlado = new Planos("Controlado",200, 100m,20m);
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now.AddDays(1),
            planoControlado,
            taxa,
            false
        );
        aluguelTeste.KmRodados = 10;
        
        var resultado = aluguelTeste.Calcular();
        
        //Assert
        Assert.AreEqual(200m, resultado);
    }
    
    [TestMethod]
    public void Deve_Calcular_Valor_Aluguel_Plano_Cobranca_controlado_extrapolando_do_limite()
    {
        var planoControlado = new Planos("Controlado",200, 100m,20m);
        Condutor condutor = new Condutor();
        Automovel automovel = new Automovel();
        Taxa taxa = new Taxa();
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now.AddDays(1),
            planoControlado,
            taxa,
            false
        );
        aluguelTeste.KmRodados = 30;
        
        var resultado = aluguelTeste.Calcular();
        
        //Assert
        Assert.AreEqual(1200m, resultado);
    }
}