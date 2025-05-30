using Xunit;
using APIEmbalagens.Model; 

public class EmbaladorTests
{
    [Fact]
    public void EmpacotarPedidos_DeveAlocarProdutosNasCaixasCorretamente()
    {
        var embalador = new Embalador();

        var pedidos = new List<Pedido>
        {
            new Pedido
            {
                Id = 1,
                Produtos = new List<Produto>
                {
                    new Produto { Altura = 10, Largura = 10, Comprimento = 10},
                    new Produto { Altura = 20, Largura = 20, Comprimento = 20},
                }
            }
        };

        var resultado = embalador.EmpacotarPedidos(pedidos);

        Assert.NotNull(resultado);
        Assert.Single(resultado);
        Assert.NotEmpty(resultado[0].Caixas);
    }

    [Fact]
    public void EmpacotarPedidos_ProdutoNaoCabeEmNenhumaCaixa()
    {
        var embalador = new Embalador();

        var pedidos = new List<Pedido>
        {
            new Pedido
            {
                Id = 2,
                Produtos = new List<Produto>
                {
                    new Produto { Altura = 100, Largura = 100, Comprimento = 100 } 
                }
            }
        };

        var resultado = embalador.EmpacotarPedidos(pedidos);

        Assert.Single(resultado);
        Assert.Empty(resultado[0].Caixas);
        Assert.Single(resultado[0].ProdutosSemCaixa); 
    }

    [Fact]
    public void EmpacotarPedidos_PedidoVazio()
    {
        var embalador = new Embalador();

        var pedidos = new List<Pedido>
        {
            new Pedido
            {
                Id = 3,
                Produtos = new List<Produto>() 
            }
        };

        var resultado = embalador.EmpacotarPedidos(pedidos);

        Assert.Single(resultado);
        Assert.Empty(resultado[0].Caixas);
        Assert.Empty(resultado[0].ProdutosSemCaixa);
    }

}
