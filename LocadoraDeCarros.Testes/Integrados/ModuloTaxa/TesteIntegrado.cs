using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloTaxa;

namespace LocadoraDeCarros.Testes.Integrados.ModuloTaxa;


[TestClass]
[TestCategory("Testes Integrados Taxa")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioTaxa _repositorioTaxa;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.Taxa.RemoveRange(_dbContext.Taxa);
        
        _dbContext.SaveChanges();
        
        _repositorioTaxa = new RepositorioTaxa(_dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Taxa()
    {
        //Arrange
        var taxa = new Taxa("taxaTeste", 10, "Fixo");
        
        //Act
        _repositorioTaxa.Inserir(taxa);
        
        //Assert
        var taxaSeleccionada = _dbContext.Taxa.FirstOrDefault(x => x.Id == taxa.Id);
        
        Assert.AreEqual(taxaSeleccionada.Nome, taxa.Nome);
    }

    [TestMethod]
    public void Deve_Editar_Taxa()
    {
        //Arrange
        var taxa = new Taxa("taxaTeste", 10, "Fixo");
        _repositorioTaxa.Inserir(taxa);

        taxa.Nome = "taxaEditada";
        
        //Act
        _repositorioTaxa.Editar(taxa);
        
        //Assert
        Assert.AreEqual(taxa.Nome,"taxaEditada");
    }

    [TestMethod]
    public void Deve_Excluir_Taxa()
    {
        //Arrange
        var taxa = new Taxa("taxaTeste", 10, "Fixo");
        _repositorioTaxa.Inserir(taxa);
        
        //Act
        _repositorioTaxa.Excluir(taxa);
        
        //Assert
        var taxaSelecionada = _repositorioTaxa.SelecionarPorId(taxa.Id);
        
        Assert.IsNull(taxaSelecionada);
    }
}