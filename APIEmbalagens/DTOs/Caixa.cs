using System.ComponentModel.DataAnnotations;

namespace APIEmbalagens.DTOs
{
    public class Caixa
    {
        public int Id { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Comprimento { get; set; }

        public double Volume => Altura * Largura * Comprimento;
    }


}
