using LancheAPI.Business.Interfaces;
using LancheAPI.Models.ViewModels;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class VendaBusiness : IVendaBusiness
    {
        private readonly IVendaRepository _repository;

        public VendaBusiness(IVendaRepository repository)
        {
            _repository = repository;
        }


        public VendaViewModel AtualizarVenda(VendaViewModel vendaViewModel)
        {
            return _repository.AtualizarVenda(vendaViewModel);
        }

        public VendaViewModel CriarVenda(VendaViewModel vendaViewModel)
        {
            return _repository.CriarVenda(vendaViewModel);
        }

        public void DeletarVenda(int id)
        {
            _repository.DeletarVenda(id);
        }

        public List<VendaViewModel> ListarVendas()
        {
            return _repository.ListarVendas();
        }

        public VendaViewModel ListarVendasPorId(int id)
        {
            return _repository.ListarVendasPorId(id);
        }
    }
}
