using LocadoraDeCarros.Dominio.ModuloTaxa;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloTaxa;


[TestClass]
[TestCategory("Teste Unitario Modulo Taxa")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Taxa()
    {
        //Arrange
        Taxa taxaTeste;
        
        //Act
        taxaTeste = new Taxa("texaTeste",10,"Diario");
        
        //Assert
        Assert.AreEqual(taxaTeste.PlanoCobranca,"Diario");
    }

    [TestMethod]
    public void Deve_Editar_Taxa()
    {
        //Arrange 
        var taxaTeste = new Taxa("taxaTeste",10,"Diario");
        
        //Act
        taxaTeste.Nome = "taxaEditada";
        
        //Assert
        Assert.AreNotEqual(taxaTeste.Nome, "taxaTeste");
    }
}