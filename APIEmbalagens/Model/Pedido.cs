using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIEmbalagens.Model
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }
        public int NumPedido { get; set; }
        public string NomCliente { get; set; } = string.Empty;
        public List<Produto> Produtos { get; set; } 
        public Pedido()
        {
            Produtos = new List<Produto>();
        }
    }
}
