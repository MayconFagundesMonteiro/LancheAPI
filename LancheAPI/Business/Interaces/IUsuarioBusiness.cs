using LancheAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheAPI.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        Usuario CriarUsuario(Usuario usuario);
        Usuario AtualizarUsuario(Usuario usuario);
        List<Usuario> ListarTodosUsuarios();
        void DeletarUsuarios(int id);
        Usuario EncontrarPorId(int id);
    }
}
