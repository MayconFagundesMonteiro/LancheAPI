using LancheAPI.Model;
using LancheAPI.Model.Context;
using LancheAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }


        public Usuario AtualizarUsuario(Usuario usuario)
        {
            var result = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(usuario.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuario);
                    _context.SaveChanges();
                    return usuario;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return null;
            }
        }

        public Usuario CriarUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarUsuarios(int id)
        {
            var result = _context.Usuarios.SingleOrDefault(u => u.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Usuarios.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Usuario> ListarTodosUsuarios()
        {
            return _context.Usuarios.ToList();
        }
    }
}
