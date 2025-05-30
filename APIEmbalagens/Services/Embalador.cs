using APIEmbalagens.DTOs;
using APIEmbalagens.Model;

public class Embalador
{
    private List<Caixa> tiposCaixas;

    public Embalador()
    {
        tiposCaixas = new List<Caixa>
        {
            new() { Id = 1, Altura = 30, Largura = 40, Comprimento = 80 },
            new() { Id = 2, Altura = 80, Largura = 50, Comprimento = 40 },
            new() { Id = 3, Altura = 50, Largura = 80, Comprimento = 60 } 
        };
    }
    //Varre pedido por pedido para encontrar a melhor caixa possível para alocar o produto
    public List<PedidoEmbrulhado> EmpacotarPedidos(List<Pedido> pedidos)
    {
        var resultado = new List<PedidoEmbrulhado>();

        foreach (var pedido in pedidos)
        {
            var caixasUsadas = new List<CaixaEmbalada>();
            var produtosSemCaixa = new List<Produto>();

            var produtosOrdenados = pedido.Produtos
                .OrderByDescending(p => p.VolumeTotal)
                .ToList();

            foreach (var produto in produtosOrdenados)
            {
                bool isAlocado = false;

                if (caixasUsadas.Any())
                {
                    foreach (var cx in caixasUsadas)
                    {
                        var tipo = tiposCaixas.First(c => c.Id == cx.TipoCaixaId);

                        double volumeRestante = tipo.Volume - cx.Produtos.Sum(p => p.VolumeTotal);

                        if (produto.VolumeTotal <= volumeRestante &&
                            produto.Altura <= tipo.Altura &&
                            produto.Largura <= tipo.Largura &&
                            produto.Comprimento <= tipo.Comprimento)
                        {
                            cx.Produtos.Add(produto);
                            isAlocado = true;
                            break;
                        }
                    }
                }

                if (!isAlocado)
                {
                    foreach (var tipo in tiposCaixas.OrderBy(c => c.Volume))
                    {
                        if (produto.Altura <= tipo.Altura &&
                            produto.Largura <= tipo.Largura &&
                            produto.Comprimento <= tipo.Comprimento)
                        {
                            caixasUsadas.Add(new CaixaEmbalada
                            {
                                TipoCaixaId = tipo.Id,
                                Produtos = new List<Produto> { produto }
                            });
                            break;
                        }

                        if (tipo == tiposCaixas.OrderBy(c => c.Volume).Last()) produtosSemCaixa.Add(produto);
                    }
                }
            }

            resultado.Add(new PedidoEmbrulhado
            {
                PedidoId = pedido.Id,
                Caixas = caixasUsadas,
                ProdutosSemCaixa = produtosSemCaixa
            });
        }

        return resultado;
    }
}
