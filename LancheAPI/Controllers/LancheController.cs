using LancheAPI.Business.Interfaces;
using LancheAPI.Data.VO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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


        [ProducesResponseType((200), Type = typeof(LancheVO))]  //Produces Reponses Cria Respostas customizadas para o swagger
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _lancheBusiness.EncontrarPorId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [ProducesResponseType((200), Type = typeof(List<LancheVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpGet]
        public IActionResult Get()
        {
            var lista = _lancheBusiness.ListarTodosLanches();
            return Ok(lista);
        }

        [ProducesResponseType((200), Type = typeof(LancheVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost]
        public IActionResult Post ([FromBody] LancheVO lanche)
        {
            if (!ModelState.IsValid || lanche == null) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_lancheBusiness.CriarLanche(lanche));
        }

        [ProducesResponseType((200), Type = typeof(LancheVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPut]
        public IActionResult Put ([FromBody] LancheVO lanche)
        {
            if (lanche == null) return BadRequest();
            return Ok(_lancheBusiness.AtualizarLanche(lanche));
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _lancheBusiness.DeletarLanche(id);
            return NoContent();
        }
    }
}
