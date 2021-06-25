using LancheAPI.Business.Interfaces;
using LancheAPI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [Authorize]
    public class VendaController : Controller
    {
        private readonly IVendaBusiness _repository;

        public VendaController(IVendaBusiness repository)
        {
            _repository = repository;
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "employee, admin")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _repository.ListarVendasPorId(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [ProducesResponseType((200), Type = typeof(List<VendaViewModel>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "employee, admin")]
        [HttpGet]
        public IActionResult Get ()
        {
            return Ok(_repository.ListarVendas());
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles ="admin")]
        [HttpPut]
        public IActionResult Put([FromBody] VendaViewModel vendaVM)
        {
            if (vendaVM == null || !ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_repository.AtualizarVenda(vendaVM));
        }

        [ProducesResponseType((200), Type = typeof(VendaViewModel))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [HttpPost]
        public IActionResult Post ([FromBody] VendaViewModel vendaVM)
        {
            if (vendaVM == null || !ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_repository.CriarVenda(vendaVM));
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _repository.DeletarVenda(id);
            return NoContent();
        }
    }
}
