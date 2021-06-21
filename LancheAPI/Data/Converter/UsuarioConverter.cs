using LancheAPI.Data.Converter.Interface;
using LancheAPI.Data.VO;
using LancheAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Data.Converter
{
    public class UsuarioConverter : IParser<Usuario, UsuarioVO>, IParser<UsuarioVO, Usuario>
    {
        public UsuarioVO Parse(Usuario origin)
        {
            if (origin == null) return null;
            return new UsuarioVO()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Endereco = origin.Endereco,
                Complemento = origin.Complemento,
                NumeroResidencia = origin.NumeroResidencia,
                Senha = origin.Senha,
                TipoConta = origin.TipoConta
            };
        }

        public Usuario Parse(UsuarioVO origin)
        {
            if (origin == null) return null;
            return new Usuario()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                Sobrenome = origin.Sobrenome,
                Endereco = origin.Endereco,
                Complemento = origin.Complemento,
                NumeroResidencia = origin.NumeroResidencia,
                Senha = origin.Senha,
                TipoConta = origin.TipoConta
            };
        }

        public List<Usuario> Parse(List<UsuarioVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<UsuarioVO> Parse(List<Usuario> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
