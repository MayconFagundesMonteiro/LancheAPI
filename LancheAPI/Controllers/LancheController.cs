using LancheAPI.Business.Interfaces;
using LancheAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheAPI.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LancheController : Controller
    {
        private readonly ILancheBusiness _lancheBusiness;

        public LancheController(ILancheBusiness lanche)
        {
            _lancheBusiness = lanche;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lancheBusiness.EncontrarPorId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lista = _lancheBusiness.ListarTodosLanches();
            return Ok(lista);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] Lanche lanche)
        {
            if (lanche == null) return BadRequest();
            return Ok(_lancheBusiness.CriarLanche(lanche));
        }

        [HttpPut]
        public IActionResult Put ([FromBody] Lanche lanche)
        {
            if (lanche == null) return BadRequest();
            return Ok(_lancheBusiness.AtualizarLanche(lanche));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _lancheBusiness.DeletarLanche(id);
            return NoContent();
        }
    }
}
