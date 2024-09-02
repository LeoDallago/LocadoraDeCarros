using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Infra.Compartilhado;
//using LocadoraDeCarros.Infra.Migrations;
using LocadoraDeCarros.Infra.ModuloAutomovel;
using GrupoAutomoveis = LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis.GrupoAutomoveis;

namespace LocadoraDeCarros.Testes.Integrados.ModuloAutomoveis;


[TestClass]
[TestCategory("Teste Integrado Automoveis")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioAutomovel _repositorioAutomovel;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.grupoAutomoveis.RemoveRange(_dbContext.grupoAutomoveis);
        _dbContext.Automovel.RemoveRange(_dbContext.Automovel);

        _dbContext.SaveChanges();
        
        _repositorioAutomovel = new RepositorioAutomovel(_dbContext);
    }
    
    [TestMethod]
    public void Deve_Inserir_Automovel()
    {
        //Arrange
        var novoGrupo = new GrupoAutomoveis("suv");
        var novoAutomovel = new Automovel("test","test","cor","tipo","capacidade","ano",novoGrupo);
        
        //Act
        _repositorioAutomovel.Inserir(novoAutomovel);
        
        //Assert
        var veiculo = _repositorioAutomovel.SelecionarPorId(novoAutomovel.Id);
        Assert.AreEqual(veiculo.Marca,"test");
    }

    [TestMethod]
    public void Deve_Atualizar_Automovel()
    {
        //Arrange
        var novoGrupo = new GrupoAutomoveis("suv");
        var novoAutomovel = new Automovel("test","test","cor","tipo","capacidade","ano",novoGrupo);
        _repositorioAutomovel.Inserir(novoAutomovel);
        novoAutomovel.Marca = "fiat";
        
        //Act
        _repositorioAutomovel.Editar(novoAutomovel);
        
        //Assert
        Assert.AreEqual(novoAutomovel.Marca, "fiat");
    }

    [TestMethod]
    public void Deve_Excluir_Automovel()
    {
        //Arrange
        bool excluiu = false;
        var novoGrupo = new GrupoAutomoveis("suv");
        var novoAutomovel = new Automovel("test","test","cor","tipo","capacidade","ano",novoGrupo);
        _repositorioAutomovel.Inserir(novoAutomovel);
        
        //Act
        _repositorioAutomovel.Excluir(novoAutomovel);
        excluiu = true;
        
        //Assert
        Assert.IsTrue(excluiu);
    }
}