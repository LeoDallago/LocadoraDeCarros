using LocadoraDeCarros.Dominio.ModuloFuncionario;

namespace LocadoraDeCarros.Testes.Unitarios.ModuloFuncionario;


[TestClass]
[TestCategory("Teste Unitario Funcionario")]
public class TesteUnitario
{
    [TestMethod]
    public void Deve_Inserir_Funcionario()
    {
        //Arrange
        Funcionario funcionarioTeste;
        
        //Act
        funcionarioTeste = new Funcionario("fulano",DateTime.Now, 100m);
        
        //Assert
        Assert.AreEqual("fulano",funcionarioTeste.Nome);
    }

    [TestMethod]
    public void Deve_Atualizar_Funcionario()
    {
        //Arrange
        var funcionario = new Funcionario("fulano",DateTime.Now, 100m);
        
        //Act
        funcionario.Salario = 200m;
        
        //Assert
        Assert.AreNotEqual(100m, funcionario.Salario);
    }
}