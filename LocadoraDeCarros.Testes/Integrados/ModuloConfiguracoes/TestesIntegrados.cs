using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloConfiguracoes;

namespace LocadoraDeCarros.Testes.Integrados.ModuloConfiguracoes;


[TestClass]
[TestCategory("Testes Integrados configuracoes")]
public class TestesIntegrados
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioConfiguracoes _repositorioConfiguracoes;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        _repositorioConfiguracoes = new RepositorioConfiguracoes(_dbContext);
    }

    [TestMethod]
    public void Deve_Editar_Configuracoes()
    {
        //Arrange
        int id = 1;
        var config = _repositorioConfiguracoes.SelecionarPorId(id);
        
        //Act
        config.Diesel = 2.34m;
        _repositorioConfiguracoes.Editar(config);
        
        //Assert
        Assert.AreEqual(config.Diesel, 2.34m);
    }
}