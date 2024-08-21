using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloAutomovel;

[TestClass]
[TestCategory("Teste Unitario Automovel")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Veiculo()
    {
        //Arrange
        GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("grupoteste");
        Automovel novoAutomovel;
        
        //Act
        novoAutomovel = new Automovel(
            "marca",
            "modelo",
            "cor",
            "combustivel",
            "capacidade",
            "2000",
            grupoAutomoveis
            );
        
        //Assert
        Assert.IsNotNull(novoAutomovel);
        Assert.AreEqual(novoAutomovel.Marca, "marca");
    }

    [TestMethod]
    public void Deve_Editar_Veiculo()
    {
        //Arrange
        GrupoAutomoveis grupoAutomoveis = new GrupoAutomoveis("grupoteste");
        Automovel novoAutomovel = new Automovel(
            "marca",
            "modelo",
            "cor",
            "combustivel",
            "capacidade",
            "2000",
            grupoAutomoveis
        );
        
        //Act
        novoAutomovel.Marca = "Fiat";
        
        //Assert
        Assert.AreEqual(novoAutomovel.Marca, "Fiat");
    }
}