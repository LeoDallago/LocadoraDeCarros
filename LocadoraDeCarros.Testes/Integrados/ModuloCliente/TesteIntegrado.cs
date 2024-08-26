using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloCliente;

namespace LocadoraDeCarros.Testes.Integrados.ModuloCliente;

[TestClass]
[TestCategory("Testes Integrados Modulo Cliente")]

public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioCliente _repositorioCliente;
    
    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.Cliente.RemoveRange(_dbContext.Cliente);
        _dbContext.SaveChanges();
        
        _repositorioCliente = new RepositorioCliente(_dbContext);
    }


    [TestMethod]
    public void Deve_Inserir_Cliente()
    {
        //Arrange
        Cliente novoCLiente = new Cliente
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
        _repositorioCliente.Inserir(novoCLiente);
        
        //Assert
        var clienteSelecionado = _repositorioCliente.SelecionarPorId(novoCLiente.Id);
        
        Assert.AreEqual(novoCLiente.Nome, clienteSelecionado.Nome);
    }

    [TestMethod]
    public void Deve_Editar_Cliente()
    {
        //Arrange
        Cliente novoCLiente = new Cliente
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
        _repositorioCliente.Inserir(novoCLiente);
        
        //Act
        novoCLiente.Nome = "Juan Editado";
        _repositorioCliente.Editar(novoCLiente);
        
        //Assert
        Assert.AreNotEqual(novoCLiente.Nome, "Juan");
    }

    [TestMethod]
    public void Deve_Deletar_Cliente()
    {
        //Arrange
        Cliente novoCLiente = new Cliente
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
        _repositorioCliente.Inserir(novoCLiente);
        
         //Act
         _repositorioCliente.Excluir(novoCLiente);
         
         //Assert
         var clienteSelecionado = _repositorioCliente.SelecionarPorId(novoCLiente.Id);
         Assert.IsNull(clienteSelecionado);
    }
}