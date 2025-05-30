using APIEmbalagens.Model;

namespace APIEmbalagens.DTOs
{
    public class CaixaEmbalada
    {
        public int TipoCaixaId { get; set; }
        public List<Produto> Produtos { get; set; } 

        public CaixaEmbalada()
        {
            Produtos = new List<Produto>();
        }
    }
}
