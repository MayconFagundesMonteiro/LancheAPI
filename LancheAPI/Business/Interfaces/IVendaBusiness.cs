using LancheAPI.Models.ViewModels;
using System.Collections.Generic;

namespace LancheAPI.Business.Interfaces
{
    public interface IVendaBusiness
    {
        List<VendaViewModel> ListarVendas();
        VendaViewModel ListarVendasPorId(int id);
        VendaViewModel CriarVenda(VendaViewModel vendaViewModel);
        VendaViewModel AtualizarVenda(VendaViewModel vendaViewModel);
        void DeletarVenda(int id);
    }
}
