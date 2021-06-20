using LancheAPI.Business.Interfaces;
using LancheAPI.Model;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioBusiness(IUsuarioRepository repository)
        {
            _repository = repository;
        }
        public Usuario AtualizarUsuario(Usuario usuario)
        {
            return _repository.AtualizarUsuario(usuario);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            return _repository.CriarUsuario(usuario);
        }

        public void DeletarUsuarios(int id)
        {
            _repository.DeletarUsuarios(id);
        }

        public Usuario EncontrarPorId(int id)
        {
            return _repository.EncontrarPorId(id);
        }

        public List<Usuario> ListarTodosUsuarios()
        {
            return _repository.ListarTodosUsuarios();
        }
    }
}
