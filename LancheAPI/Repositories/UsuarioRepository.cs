using LancheAPI.Models;
using LancheAPI.Models.Context;
using LancheAPI.Repositories.Interfaces;
using System.Linq;

namespace LancheAPI.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context) { }

        public Usuario Login(Usuario usuario)
        {
            var result = _context.Usuarios.SingleOrDefault(x => x.Nome.Equals(usuario.Nome) && x.Senha.Equals(usuario.Senha));
            if (result == null) return null;
            return result;
        }
    }
}
