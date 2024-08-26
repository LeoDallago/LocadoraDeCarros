using LocadoraDeCarros.Dominio.ModuloCliente;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloCliente;

[TestClass]
[TestCategory("Testes Unitarios Modulo Cliente")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Cliente()
    {
        //Arrange
        Cliente novoCLiente;
        
        //Act
        novoCLiente = new Cliente
        {
            Nome = "Juan",
            Email = "teste@test.com",
            Telefone = "123456789",
            Estado = "Sc",
            Cidade = "Lages",
            Bairro = "Centro",
            Rua = "teste",
            Numero = "123",
            TipoCliente = "Fisica"
        };
        
        //Assert
        Assert.AreEqual(novoCLiente.Nome, "Juan");
    }

    [TestMethod]
    public void Deve_Editar_Cliente()
    {
        //Arrange
        Cliente novoCLientene = new Cliente
        {
            Nome = "Juan",
            Email = "teste@test.com",
            Telefone = "123456789",
            Estado = "Sc",
            Cidade = "Lages",
            Bairro = "Centro",
            Rua = "teste",
            Numero = "123",
            TipoCliente = "Fisica"
        };
        
        //Act
        novoCLientene.Cidade = "Chapecó";
        
        //Assert
        Assert.AreNotEqual(novoCLientene.Cidade,"Lages");
    }
}