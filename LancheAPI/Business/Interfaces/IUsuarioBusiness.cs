using LancheAPI.Data.VO;
using System.Collections.Generic;

namespace LancheAPI.Business.Interfaces
{
    public interface IUsuarioBusiness
    {
        UsuarioVO CriarUsuario(UsuarioVO usuario);
        UsuarioVO AtualizarUsuario(UsuarioVO usuario);
        List<UsuarioVO> ListarTodosUsuarios();
        void DeletarUsuarios(int id);
        UsuarioVO EncontrarPorId(int id);
    }
}
