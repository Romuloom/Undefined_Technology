using Microsoft.AspNetCore.Mvc;
using MyLoginAPI.Data;
using MyLoginAPI.Models;
using System.Linq;

namespace MyLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MetricsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<MetricsDto> GetMetrics()
        {
            var metrics = new MetricsDto
            {
                // Alterado para contar todos os pedidos, não apenas os "Em entrega"
                TotalPedidosParaEntrega = _context.Pedidos.Count(p => p.Status == "Em preparação"),

                // Conta total de produtos cadastrados
                TotalProdutosCadastrados = _context.Estoques.Sum(e => e.Quantidade),

                // Conta total de produtos que estão em quantidade mínima ou abaixo
                TotalProdutosEmEstoqueMinimo = _context.Estoques.Count(e => e.Quantidade <= e.QuantidadeMinima),

                // Conta total de registros em Listas Escolares como "novos clientes"
                TotalNovosClientes = _context.ListasEscolares.Count()
            };

            return Ok(metrics);
        }
    }

    public class MetricsDto
    {
        public int TotalPedidosParaEntrega { get; set; }
        public int TotalProdutosCadastrados { get; set; }
        public int TotalProdutosEmEstoqueMinimo { get; set; }
        public int TotalNovosClientes { get; set; }
    }
}
