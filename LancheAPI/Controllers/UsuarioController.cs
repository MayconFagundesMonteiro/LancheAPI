using LancheAPI.Model;
using LancheAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LancheAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository usuarioRepositoty)
        {
            _repository = usuarioRepositoty;
        }

        [HttpGet]
        public IActionResult Get() //Lista todos os usuarios cadastrados
        {
            return Ok(_repository.ListarTodosUsuarios());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario) //Cria um novo Usuario
        {
            if (usuario == null) return BadRequest();
            return Ok(_repository.CriarUsuario(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario usuario) //Atualiza Cadastro Usuario
        {
            if (usuario == null) return BadRequest();
            return Ok(_repository.AtualizarUsuario(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //Deleta Usuarios
        {
            _repository.DeletarUsuarios(id);
            return NoContent();
        }
    }
}
