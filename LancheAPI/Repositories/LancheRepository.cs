using LancheAPI.Models;
using LancheAPI.Models.Context;
using LancheAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheAPI.Repositories
{
    public class LancheRepository : GenericRepository<Lanche>, ILancheRepository
    {
        public LancheRepository(AppDbContext context) : base(context) {}

        public List<Lanche> EncontrarPorNome(string Nome)
        {
            return _context.Lanches.Where(l => l.Nome.ToLower().Contains(Nome.ToLower())).ToList();
        }
    }
}
