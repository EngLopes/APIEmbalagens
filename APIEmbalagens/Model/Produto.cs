using System.ComponentModel.DataAnnotations;

namespace APIEmbalagens.Model
{
    public class Produto
    {
       [Key]
       public int Id { get; set; }
       public string Nome { get; set; } = string.Empty;
       public double Altura { get; set; }
       public double Largura { get; set; }
       public double Comprimento { get; set; }
       public double VolumeTotal => Altura * Largura * Comprimento;

    }
}
