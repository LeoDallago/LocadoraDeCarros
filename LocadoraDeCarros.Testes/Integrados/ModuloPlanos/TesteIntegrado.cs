using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.ModuloPlanos;

namespace LocadoraDeCarros.Testes.Integrados.ModuloPlanos;

[TestClass]
[TestCategory("Testes Integrados Planos")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;
    private RepositorioPlanos _repositorioPlanos;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.SaveChanges();
        
        _repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveis(_dbContext);
        _repositorioPlanos = new RepositorioPlanos(_dbContext);
    }
    
    [TestMethod]
    public void Deve_Inserir_Planos()
    {
        //Arrange
        var grupo = new GrupoAutomoveis("grupoteste");
        _repositorioGrupoAutomoveis.Inserir(grupo);
        var plano = new Planos("diario","50","5",grupo.Id,grupo);
        
        //Act
        _repositorioPlanos.Inserir(plano);
        
        //Assert
        Assert.AreEqual(plano.Plano, "diario");
    }

    [TestMethod]
    public void Deve_Atualizar_Planos()
    {
        //Arrange
        var grupo = new GrupoAutomoveis("grupoteste");
        _repositorioGrupoAutomoveis.Inserir(grupo);
        
        var plano = new Planos("diario","50","5",grupo.Id,grupo);
        _repositorioPlanos.Inserir(plano);
        
        plano.PrecoDiaria = "75";
        //Act
        _repositorioPlanos.Editar(plano);
        
        //Assert
        Assert.AreNotEqual(plano.PrecoDiaria, "50");
    }

    [TestMethod]
    public void Deve_Excluir_Planos()
    {
        //Arrange
        bool excluiu = false;
        var grupo = new GrupoAutomoveis("grupoteste");
        _repositorioGrupoAutomoveis.Inserir(grupo);
        
        var plano = new Planos("diario","50","5",grupo.Id,grupo);
        _repositorioPlanos.Inserir(plano);
        
        //Act
        _repositorioPlanos.Excluir(plano);
        excluiu = true;
        
        //Assert
        Assert.IsTrue(excluiu);
    }
}