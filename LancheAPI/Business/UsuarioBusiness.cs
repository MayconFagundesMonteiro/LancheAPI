using LancheAPI.Business.Interfaces;
using LancheAPI.Models;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IGenericRepository<Usuario> _repository;

        public UsuarioBusiness(IGenericRepository<Usuario> repository)
        {
            _repository = repository;
        }
        public Usuario AtualizarUsuario(Usuario usuario)
        {
            return _repository.Atualizar(usuario);
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            return _repository.Criar(usuario);
        }

        public void DeletarUsuarios(int id)
        {
            _repository.Deletar(id);
        }

        public Usuario EncontrarPorId(int id)
        {
            return _repository.EncontrarPorId(id);
        }

        public List<Usuario> ListarTodosUsuarios()
        {
            return _repository.ListarTodos();
        }
    }
}
