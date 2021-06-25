using LancheAPI.Models;
using LancheAPI.Models.Context;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Repositories
{
    public class LancheRepository : GenericRepository<Lanche>, ILancheRepository
    {
        public LancheRepository(AppDbContext context) : base(context) {}

        public List<Lanche> EncontrarPorNome(string nome)
        {
            return _context.Lanches.Where(l => l.Nome.ToLower().Contains(nome.ToLower())).ToList();
        }

        public List<Lanche> LanchesPorCategoria(string categoria)
        {
            return _context.Lanches.Where(l => l.Categoria.ToLower().Contains(categoria.ToLower())).ToList();
        }
    }
}
