using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEmbalagens.Model;

namespace APIEmbalagens.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly PedidoContext _context;
        private readonly Embalador _embalagem;

        public PedidosController(PedidoContext context, Embalador embalagem)
        {
            _context = context;
            _embalagem = embalagem;
        }


        // POST: api/Pedidoes
        //Receber Pedidos e retornar pedidos alocados em caixas e seus tipos 
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(List<Pedido> pedidos)
        {
            

            try
            {
                return Ok(_embalagem.EmpacotarPedidos(pedidos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar pedido {ex.Message}");
            }
        }

       

    }
}
