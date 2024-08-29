using LocadoraDeCarros.Dominio.ModuloAluguel;
using LocadoraDeCarros.Dominio.ModuloAutomoveis;
using LocadoraDeCarros.Dominio.ModuloCliente;
using LocadoraDeCarros.Dominio.ModuloCondutor;
using LocadoraDeCarros.Dominio.ModuloGrupoAutomoveis;
using LocadoraDeCarros.Dominio.ModuloPlanos;
using LocadoraDeCarros.Dominio.ModuloTaxa;
using LocadoraDeCarros.Infra.Compartilhado;
using LocadoraDeCarros.Infra.ModuloAluguel;

namespace LocadoraDeCarros.Testes.Integrados.ModuloAluguel;


[TestClass]
[TestCategory("Testes Integrados aluguel")]
public class TesteIntegrado
{
    private LocadoraDeCarrosDbContext _dbContext;
    private RepositorioAluguel _repositorioAluguel;
    
    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new LocadoraDeCarrosDbContext();
        
        _dbContext.Aluguel.RemoveRange(_dbContext.Aluguel);
        _dbContext.SaveChanges();
        
        _repositorioAluguel = new RepositorioAluguel(_dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Aluguel()
    {
        //Arrange
        Cliente teste = new Cliente("fulano","fulano@fulano.com","1234","sc","laaaages","centro","test","12","Pessoa fisica");
        GrupoAutomoveis grupoTeste = new GrupoAutomoveis("SUV");
        
        Condutor condutor = new Condutor("leo","leo@leo.com.br","12345","123321123","3221212",DateTime.Now,teste );
        Automovel automovel = new Automovel("teste","test","azul","alcool","100","2000",grupoTeste);
        Planos planos = new Planos("test",10,100,1,grupoTeste);
        Taxa taxa = new Taxa("teste",10,"test");
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        
        //Act
        _repositorioAluguel.Inserir(aluguelTeste);
        
        //Assert
        var aluguel = _repositorioAluguel.SelecionarPorId(aluguelTeste.Id);
        
        Assert.IsNotNull(aluguel.Concluido);
        Assert.AreEqual(aluguel.ValorTotal, 1600);
    }

    [TestMethod]
    public void Deve_Editar_Aluguel()
    {
        //Assert
        Cliente teste = new Cliente("fulano","fulano@fulano.com","1234","sc","laaaages","centro","test","12","Pessoa fisica");
        GrupoAutomoveis grupoTeste = new GrupoAutomoveis("SUV");
        
        Condutor condutor = new Condutor("leo","leo@leo.com.br","12345","123321123","3221212",DateTime.Now,teste );
        Automovel automovel = new Automovel("teste","test","azul","alcool","100","2000",grupoTeste);
        Planos planos = new Planos("test",10,100,1,grupoTeste);
        Taxa taxa = new Taxa("teste",10,"test");
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        _repositorioAluguel.Inserir(aluguelTeste);
        aluguelTeste.ValorTotal = 2300;

        //Act
        _repositorioAluguel.Editar(aluguelTeste);
        
        //Assert
        Assert.AreEqual(aluguelTeste.ValorTotal,2300);
    }

    [TestMethod]
    public void Deve_Deletar_Aluguel()
    {
        //Assert
        Cliente teste = new Cliente("fulano","fulano@fulano.com","1234","sc","laaaages","centro","test","12","Pessoa fisica");
        GrupoAutomoveis grupoTeste = new GrupoAutomoveis("SUV");
        
        Condutor condutor = new Condutor("leo","leo@leo.com.br","12345","123321123","3221212",DateTime.Now,teste );
        Automovel automovel = new Automovel("teste","test","azul","alcool","100","2000",grupoTeste);
        Planos planos = new Planos("test",10,100,1,grupoTeste);
        Taxa taxa = new Taxa("teste",10,"test");
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        _repositorioAluguel.Inserir(aluguelTeste);
        
        //Act
        _repositorioAluguel.Excluir(aluguelTeste);
        
        //Assert
        var aluguel = _repositorioAluguel.SelecionarPorId(aluguelTeste.Id);
        
        Assert.IsNull(aluguel);
    }

    [TestMethod]
    public void Deve_Encerrar_Aluguel()
    {
        //Assert
        Cliente teste = new Cliente("fulano","fulano@fulano.com","1234","sc","laaaages","centro","test","12","Pessoa fisica");
        GrupoAutomoveis grupoTeste = new GrupoAutomoveis("SUV");
        
        Condutor condutor = new Condutor("leo","leo@leo.com.br","12345","123321123","3221212",DateTime.Now,teste );
        Automovel automovel = new Automovel("teste","test","azul","alcool","100","2000",grupoTeste);
        Planos planos = new Planos("test",10,100,1,grupoTeste);
        Taxa taxa = new Taxa("teste",10,"test");
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        _repositorioAluguel.Inserir(aluguelTeste);
        
        //Act
        var aluguel = _repositorioAluguel.SelecionarPorId(aluguelTeste.Id);
        aluguel.ConcluirAluguel();
        
        //Assert
        Assert.IsTrue(aluguel.Concluido);
    }

    [TestMethod]
    public void Deve_Excluir_Aluguel_Apenas_Se_Concluido()
    {
        //Assert
        Cliente teste = new Cliente("fulano","fulano@fulano.com","1234","sc","laaaages","centro","test","12","Pessoa fisica");
        GrupoAutomoveis grupoTeste = new GrupoAutomoveis("SUV");
        
        Condutor condutor = new Condutor("leo","leo@leo.com.br","12345","123321123","3221212",DateTime.Now,teste );
        Automovel automovel = new Automovel("teste","test","azul","alcool","100","2000",grupoTeste);
        Planos planos = new Planos("test",10,100,1,grupoTeste);
        Taxa taxa = new Taxa("teste",10,"test");
        Aluguel aluguelTeste;
        
        aluguelTeste = new Aluguel(
            condutor,
            automovel,
            DateTime.Now,
            DateTime.Now,
            planos,
            taxa,
            false,
            1600
        );
        _repositorioAluguel.Inserir(aluguelTeste);
        
        //Act
        var aluguelSelecionado = _repositorioAluguel.SelecionarPorId(aluguelTeste.Id);
            aluguelSelecionado.ConcluirAluguel();

            if (aluguelSelecionado.Concluido == true)
            {
                _repositorioAluguel.Excluir(aluguelSelecionado);
            }
            
        //Assert
        var aluguelExcluido = _repositorioAluguel.SelecionarPorId(aluguelSelecionado.Id);
        Assert.IsNull(aluguelExcluido);
    }
}