using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloCondutor;


[TestClass]
[TestCategory("Testes Unitarios Modulo Condutor")]
public class Teste_Unitario
{
    [TestMethod]
    public void Deve_Inserir_Condutor()
    {
        //Arrange
        Cliente cliente = new Cliente();
        Condutor condutor;
        
        //Act
        condutor = new Condutor(
            "teste",
            "teste@teste.com",
            "12345",
            "12332112322",
            "123456789",
            DateTime.Now,
            cliente
            );
        
        //Assert
        Assert.AreEqual(condutor.Nome,"teste");
    }

    [TestMethod]
    public void Deve_Editar_Condutor()
    {
        //Arrange
        Cliente cliente = new Cliente();
        Condutor condutor;
        condutor = new Condutor(
            "teste",
            "teste@teste.com",
            "12345",
            "12332112322",
            "123456789",
            DateTime.Now,
            cliente
        );
        
        //Act
        condutor.Telefone = "54321";
        
        //Assert
        Assert.AreEqual(condutor.Telefone, "54321");
    }
}