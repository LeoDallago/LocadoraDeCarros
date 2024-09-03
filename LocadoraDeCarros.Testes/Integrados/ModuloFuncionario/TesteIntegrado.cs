using LocadoraDeCarros.Dominio.ModuloFuncionario;
using LocadoraDeCarros.Dominio.ModuloUsuario;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloFuncionario;

namespace LocadoraDeCarros.Testes.Integrados.ModuloFuncionario;

[TestClass]
[TestCategory("Testes Integrados Funcionario")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioFuncionario _repositorioFuncionario;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.Funcionario.RemoveRange(_dbContext.Funcionario);
        _dbContext.SaveChanges();
        
        _repositorioFuncionario = new RepositorioFuncionario(_dbContext);
    }

    [TestMethod]
    public void Deve_inserir_funcionario()
    {
        //Arrange
        Funcionario funcionario = new Funcionario("test", DateTime.Now, 100m);
        funcionario.UsuarioId = 1;
        funcionario.Usuario = new Usuario();
        //Act
        _repositorioFuncionario.Inserir(funcionario);
        
        //Assert
        var funcionarioSelecionado = _repositorioFuncionario.SelecionarPorId(funcionario.Id);
        
        Assert.AreEqual(100m,funcionarioSelecionado.Salario);
    }

    [TestMethod]
    public void Deve_Atualizar_funcionario()
    {
        //Arrange
        Funcionario funcionario = new Funcionario("test", DateTime.Now, 100m);
        funcionario.UsuarioId = 1;
        funcionario.Usuario = new Usuario();
        _repositorioFuncionario.Inserir(funcionario);
        
        //Act
        funcionario.Salario = 200m;
        
        _repositorioFuncionario.Editar(funcionario);
        
        //Assert
        Assert.AreNotEqual(100m,funcionario.Salario);
    }

    [TestMethod]
    public void Deve_Excluir_funcionario()
    {
        //Arrange
        Funcionario funcionario = new Funcionario("test", DateTime.Now, 100m);
        funcionario.UsuarioId = 1;
        funcionario.Usuario = new Usuario();
        _repositorioFuncionario.Inserir(funcionario);
        
        //Act
        _repositorioFuncionario.Excluir(funcionario);
        
        //Assert
        var funcionarioSelecionado = _repositorioFuncionario.SelecionarPorId(funcionario.Id);
        
        Assert.IsNull(funcionarioSelecionado);
    }
}