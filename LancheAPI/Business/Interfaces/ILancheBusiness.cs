using LancheAPI.Models;
using System.Collections.Generic;

namespace LancheAPI.Business.Interfaces
{
    public interface ILancheBusiness
    {
        Lanche CriarLanche(Lanche lanche);
        Lanche AtualizarLanche(Lanche lanche);
        List<Lanche> ListarTodosLanches();
        void DeletarLanche(int id);
        Lanche EncontrarPorId(int id);
    }
}
