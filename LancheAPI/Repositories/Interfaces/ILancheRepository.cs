using LancheAPI.Models;
using System.Collections.Generic;

namespace LancheAPI.Repositories.Interfaces
{
    public interface ILancheRepository : IGenericRepository<Lanche>
    {
        List<Lanche> EncontrarPorNome(string nome);
        List<Lanche> LanchesPorCategoria(string categoria);
    }
}
