using Microsoft.AspNetCore.Mvc;
using MyLoginAPI.Models;
using MyLoginAPI.Data; // Certifique-se de que o namespace para o DbContext está correto
using System.Linq;

namespace MyLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EstoqueController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Rota para obter o total de itens no estoque
        [HttpGet("total")]
        public ActionResult<int> GetTotalEstoque()
        {
            // Soma as quantidades de todos os produtos no estoque
            var totalEstoque = _context.Estoques.Sum(e => e.Quantidade);
            return Ok(totalEstoque);
        }

        // Outras rotas (GetAllEstoque, AddProduto, UpdateEstoque) podem permanecer inalteradas
    }
}
