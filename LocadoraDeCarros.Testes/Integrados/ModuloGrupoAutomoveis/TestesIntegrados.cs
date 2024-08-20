using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Testes.Integrados.ModuloGrupoAutomoveis;


[TestClass]
[TestCategory("Integrados Grupo Automoveis")]

public class TestesIntegrados
{
   private LocadoraDeCarrosDbContext _dbContext;
   private RepositorioGrupoAutomoveis _repositorioGrupoAutomoveis;

   [TestInitialize]
   public void Inicializar()
   {
      _dbContext = new LocadoraDeCarrosDbContext();
      
      _dbContext.grupoAutomoveis.RemoveRange(_dbContext.grupoAutomoveis);
      
      _dbContext.SaveChanges();
      
      _repositorioGrupoAutomoveis = new RepositorioGrupoAutomoveis(_dbContext);
   }
   
   [TestMethod]
   public void Inserir_Grupo_Corretamente()
   {
      //Arrange 
      var novoGrupo = new GrupoAutomoveis("grupoAutomoveis");
      
      //Act
      _repositorioGrupoAutomoveis.Inserir(novoGrupo);
      
      //Assert
      var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(novoGrupo.Id);
      
      Assert.AreEqual(grupoSelecionado.Grupo, novoGrupo.Grupo);
   }

   [TestMethod]
   public void Editar_Grupo_Corretamente()
   {
      //Arrange
      var novoGrupo = new GrupoAutomoveis("grupoAutomoveis");
      _repositorioGrupoAutomoveis.Inserir(novoGrupo);
      
      novoGrupo.Grupo = "grupoAutomoveisEditado";
      
      //Act
      _repositorioGrupoAutomoveis.Editar(novoGrupo);
      
      //Assert
      Assert.AreNotEqual("grupoAutomoveis", novoGrupo.Grupo);
   }

   [TestMethod]
   public void Excluir_Grupo_Corretamente()
   {
      //Arrange
      var novoGrupo = new GrupoAutomoveis("grupoAutomoveis");
      _repositorioGrupoAutomoveis.Inserir(novoGrupo);

      //Act
      _repositorioGrupoAutomoveis.Excluir(novoGrupo);
      
      //Assert
      var grupoSelecionado = _repositorioGrupoAutomoveis.SelecionarPorId(novoGrupo.Id);
      
      Assert.IsNull(grupoSelecionado);
   }
}