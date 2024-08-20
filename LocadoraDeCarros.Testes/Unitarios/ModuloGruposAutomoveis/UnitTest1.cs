using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Testes;

[TestClass]
[TestCategory("testes unitarios")]
public class UnitTest1
{
    [TestMethod]
    public void Deve_Inserir_Grupo()
    {
        //Arrange
        GrupoAutomoveis novoGrupo;
        
        //Act
        novoGrupo = new GrupoAutomoveis("Grupo teste");
        
        //Assert
        Assert.IsNotNull(novoGrupo.Grupo);
    }

    [TestMethod]
    public void Deve_Atualizar_Grupo()
    {
        //Arrange
        GrupoAutomoveis novoGrupo = new GrupoAutomoveis("Grupo");
        
        //Act
        novoGrupo.Grupo = "GrupoEditado";
        
        //Assert
        Assert.AreNotEqual("Grupo",novoGrupo.Grupo);
    }
}