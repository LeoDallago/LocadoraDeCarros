using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloCondutor;

namespace LocadoraDeCarros.Testes.Integrados.ModuloCondutor;


[TestClass]
[TestCategory("Testes integrados Modulo Condutor")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioCondutor _repositorioCondutor;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.Condutor.RemoveRange(_dbContext.Condutor);
        _dbContext.SaveChanges();
        
        _repositorioCondutor = new RepositorioCondutor(_dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Condutor()
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
        Condutor novoCondutor = new Condutor(
            "test",
            "test@test.com",
            "12345",
            "12332112333",
            "1234567897",
            DateTime.Now,
            novoCLiente
            );
        
        //Act
        _repositorioCondutor.Inserir(novoCondutor);
        
        //Assert
        var condutor = _repositorioCondutor.SelecionarPorId(novoCondutor.Id);
        
        Assert.AreEqual(condutor.Nome, novoCondutor.Nome);
        
    }

    [TestMethod]
    public void Deve_Editar_Condutor()
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
        Condutor novoCondutor = new Condutor(
            "test",
            "test@test.com",
            "12345",
            "12332112333",
            "1234567897",
            DateTime.Now,
            novoCLiente
        );
        _repositorioCondutor.Inserir(novoCondutor);
        novoCondutor.Nome = "Editado";
        
        //Act
        _repositorioCondutor.Editar(novoCondutor);
        
        //Assert
        var condutor = _repositorioCondutor.SelecionarPorId(novoCondutor.Id);
        Assert.AreNotEqual(condutor.Nome, "test");
    }

    [TestMethod]
    public void Deve_Excluir_Condutor()
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
        Condutor novoCondutor = new Condutor(
            "test",
            "test@test.com",
            "12345",
            "12332112333",
            "1234567897",
            DateTime.Now,
            novoCLiente
        );
        _repositorioCondutor.Inserir(novoCondutor);
        
        //Act
        _repositorioCondutor.Excluir(novoCondutor);
        
        //Assert
        var condutor = _repositorioCondutor.SelecionarPorId(novoCondutor.Id);
        
        Assert.IsNull(condutor);
    }
}