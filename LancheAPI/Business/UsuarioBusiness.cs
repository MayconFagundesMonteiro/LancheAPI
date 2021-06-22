using LancheAPI.Business.Interfaces;
using LancheAPI.Data.Converter;
using LancheAPI.Data.VO;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class UsuarioBusiness : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioConverter _converter;

        public UsuarioBusiness(IUsuarioRepository repository)
        {
            _repository = repository;
            _converter = new UsuarioConverter();
        }
        public UsuarioVO AtualizarUsuario(UsuarioVO usuario)
        {
            var usuariosEntity = _converter.Parse(usuario); //Converte para VO
            usuariosEntity = _repository.Atualizar(usuariosEntity); //Chama o Repositorio
            return _converter.Parse(usuariosEntity); // Devolve como VO
        }

        public UsuarioVO CriarUsuario(UsuarioVO usuario)
        {
            var usuarioEntity = _converter.Parse(usuario);
            usuarioEntity = _repository.Criar(usuarioEntity);
            return _converter.Parse(usuarioEntity);
        }

        public void DeletarUsuarios(int id)
        {
            _repository.Deletar(id);
        }

        public UsuarioVO EncontrarPorId(int id)
        {
            return _converter.Parse(_repository.EncontrarPorId(id));
        }

        public List<UsuarioVO> ListarTodosUsuarios()
        {
            return _converter.Parse(_repository.ListarTodos());
        }

        public UsuarioVO Login(UsuarioVO usuarioVO)
        {
            var usuaroEntity = _converter.Parse(usuarioVO);
            usuaroEntity = _repository.Login(usuaroEntity);
            return _converter.Parse(usuaroEntity);
        }
    }
}
