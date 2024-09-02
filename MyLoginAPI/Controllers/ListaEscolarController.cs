using Microsoft.AspNetCore.Mvc;
using MyLoginAPI.Models;
using MyLoginAPI.Data; // Certifique-se de que o namespace para o DbContext está correto
using System.Linq;

namespace MyLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaEscolarController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ListaEscolarController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Rota para obter o total de listas escolares
        [HttpGet("total")]
        public ActionResult<int> GetTotalListasEscolares()
        {
            // Retorna o número total de listas escolares no banco de dados
            var totalListas = _context.ListasEscolares.Count();
            return Ok(totalListas);
        }

        // Outros métodos existentes (GetAllListasEscolares, CreateListaEscolar, UpdateListaEscolar, DeleteListaEscolar)
    }
}
