using Microsoft.EntityFrameworkCore;

namespace APIEmbalagens.Model
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options)
        : base(options)
        {
        }

        public DbSet<Pedido> PedidoItems { get; set; } = null!;
    }
}
