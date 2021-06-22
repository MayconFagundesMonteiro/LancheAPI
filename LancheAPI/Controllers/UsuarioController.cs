using LancheAPI.Business.Interfaces;
using LancheAPI.Data.VO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LancheAPI.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]

    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBisiness)
        {
            _usuarioBusiness = usuarioBisiness;
        }

        [HttpGet]
        public IActionResult Get() //Lista todos os usuarios cadastrados
        {
            return Ok(_usuarioBusiness.ListarTodosUsuarios());
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioVO usuario) //Cria um novo Usuario
        {
            if (!ModelState.IsValid || usuario == null) return BadRequest(ModelState.Values.SelectMany(x => x.Errors));
            return Ok(_usuarioBusiness.CriarUsuario(usuario));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UsuarioVO usuario) //Atualiza Cadastro Usuario
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.AtualizarUsuario(usuario));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) //Deleta Usuarios
        {
            _usuarioBusiness.DeletarUsuarios(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) //Encontra Usuario por ID
        {
            var usuario = _usuarioBusiness.EncontrarPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioVO usuarioVO)
        {
            if (usuarioVO == null) return BadRequest(new { message = "Usuario ou senha Invalidos" });
            return Ok(_usuarioBusiness.Login(usuarioVO));
        }
    }
}
