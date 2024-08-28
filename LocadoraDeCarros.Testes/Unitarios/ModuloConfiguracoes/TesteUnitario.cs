using LocadoraDeCarros.Dominio.ModuloConfiguracoes;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloConfiguracoes;


[TestClass]
[TestCategory("testes unitarios configuracoes")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Configurar_Corretamente()
    {
        //Arrange
        Configuracoes novaConfig;
        
        //Act
        novaConfig = new Configuracoes(12,25,3,2);
        
        //Assert
        Assert.AreEqual(novaConfig.Gasolina,12);
    }

    [TestMethod]
    public void Deve_Editar_Corretamente()
    {
        //Arrange
       Configuracoes novaConfig = new Configuracoes(12,25,3,2);
       
       //Act
       novaConfig.Gasolina = 2.33m;
       
       //Assert
       Assert.AreNotEqual(novaConfig.Gasolina,12);
    }
}