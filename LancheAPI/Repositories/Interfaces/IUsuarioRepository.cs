using LancheAPI.Models;

namespace LancheAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Usuario Login(Usuario usuario);
    }
}
