using LancheAPI.Model;
using System.Collections.Generic;

namespace LancheAPI.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario CriarUsuario(Usuario usuario);
        Usuario AtualizarUsuario(Usuario usuario);
        List<Usuario> ListarTodosUsuarios();
        void DeletarUsuarios(int id);
    }
}
