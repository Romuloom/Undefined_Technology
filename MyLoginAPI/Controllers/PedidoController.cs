using Microsoft.AspNetCore.Mvc;
using MyLoginAPI.Models;
using MyLoginAPI.Data; // Certifique-se de que o namespace para o DbContext está correto
using System.Collections.Generic;
using System.Linq;

namespace MyLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Rota para obter todos os pedidos
        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetAllPedidos()
        {
            // Retorna todos os pedidos do banco de dados
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        // Rota para obter o total de pedidos
        [HttpGet("total")]
        public ActionResult<int> GetTotalPedidos()
        {
            // Retorna a quantidade total de pedidos
            var totalPedidos = _context.Pedidos.Count();
            return Ok(totalPedidos);
        }

        // Rota para criar um novo pedido
        [HttpPost]
        public IActionResult CreatePedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
            {
                return BadRequest();
            }

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAllPedidos), new { id = pedido.Id }, pedido);
        }

        // Rota para atualizar um pedido existente
        [HttpPut("{id}")]
        public IActionResult UpdatePedido(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id || pedido == null)
            {
                return BadRequest();
            }

            var existingPedido = _context.Pedidos.Find(id);
            if (existingPedido == null)
            {
                return NotFound();
            }

            existingPedido.Valor = pedido.Valor;
            existingPedido.Data = pedido.Data;
            existingPedido.FormaPagamento = pedido.FormaPagamento;
            existingPedido.Status = pedido.Status;

            _context.Pedidos.Update(existingPedido);
            _context.SaveChanges();

            return NoContent();
        }

        // Rota para deletar um pedido
        [HttpDelete("{id}")]
        public IActionResult InactivatePedido(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null)
            {
                return NotFound();
            }

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
