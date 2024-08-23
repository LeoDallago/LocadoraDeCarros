using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloPlanos;


[TestClass]
[TestCategory("Teste unitario Planos")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Plano()
    {
        //Arrange
        var grupo = new GrupoAutomoveis("SUV");
        Planos plano;
        
        //Act
        plano = new Planos("Diario",50,5,2,grupo);
        
        //Assert
        Assert.AreEqual(plano.Plano, "Diario");
    }

    [TestMethod]
    public void Deve_Editar_Plano()
    {
        //Arrange
        var grupo = new GrupoAutomoveis("SUV");
        Planos plano;
        plano = new Planos("Diario",50,5,2,grupo);
        
        //Act
        plano.PrecoDiaria = 75;
        
        //Assert
        Assert.AreNotEqual(plano.PrecoDiaria,50);
    }
}