using APIEmbalagens.Model;

namespace APIEmbalagens.DTOs
{
    public class PedidoEmbrulhado
    {
        public int PedidoId { get; set; }
        public int qtdCaixas => Caixas.Count();
        public List<CaixaEmbalada> Caixas { get; set; }
        public List<Produto> ProdutosSemCaixa { get; set; }

        public PedidoEmbrulhado()
        {
            Caixas = new List<CaixaEmbalada>();
            ProdutosSemCaixa = new List<Produto>();
        }
    }
}
