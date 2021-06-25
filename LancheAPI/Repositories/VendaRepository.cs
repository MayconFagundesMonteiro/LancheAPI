using LancheAPI.Models;
using LancheAPI.Models.Context;
using LancheAPI.Models.ViewModels;
using LancheAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly AppDbContext _context;

        public VendaRepository(AppDbContext context)
        {
            _context = context;
        }

        public VendaViewModel AtualizarVenda(VendaViewModel vendaViewModel)
        {
            var result = _context.Venda.SingleOrDefault(v => v.Codigo.Equals(vendaViewModel.Codigo));
            if (result == null) return null;
            try
            {
                var venda = new Venda()
                {
                    Id = result.Id,
                    Codigo = vendaViewModel.Codigo,
                    IdUsuario = vendaViewModel.IdUsuario,
                    MomentoVenda = vendaViewModel.MomentoVenda,
                    Total = vendaViewModel.Total
                };
                List<VendaItensViewModel> viResult = new List<VendaItensViewModel>();

                foreach (var lanche in vendaViewModel.Lanches)
                {
                    var resultVI = _context.VendaItens.SingleOrDefault(vi => vi.Id.Equals(lanche.Id));
                    var vendaItens = new VendaItens()
                    {
                        Id = resultVI.Id,
                        CodigoVenda = venda.Codigo,
                        IdLanche = lanche.IdLanche,
                        Quantidade = lanche.Quantidade
                    };


                    if (resultVI == null) return null;
                    _context.Entry(resultVI).CurrentValues.SetValues(vendaItens);
                    viResult.Add(lanche);

                }
                _context.Entry(result).CurrentValues.SetValues(venda);
                _context.SaveChanges();

                var vendaResult = _context.Venda.SingleOrDefault(v => v.Id.Equals(venda.Id));
                return new VendaViewModel()
                {
                    Codigo = vendaResult.Codigo,
                    IdUsuario = vendaResult.IdUsuario,
                    Lanches = viResult,
                    MomentoVenda = vendaResult.MomentoVenda,
                    Total = vendaResult.Total
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public VendaViewModel CriarVenda(VendaViewModel vendaViewModel)
        {
            if (vendaViewModel.IdUsuario == 0) return null;
            try
            {
                Venda venda = new Venda()
                {
                    Codigo = Guid.NewGuid().ToString(),
                    IdUsuario = vendaViewModel.IdUsuario,
                    MomentoVenda = DateTime.Now,
                    Total = 0
                };

                foreach (var c in vendaViewModel.Lanches)
                {
                    VendaItens vendaItens = new VendaItens()
                    {
                        IdLanche = c.IdLanche,
                        CodigoVenda = venda.Codigo,
                        Quantidade = c.Quantidade
                    };

                    _context.VendaItens.Add(vendaItens);
                    var lancheResult = _context.Lanches.SingleOrDefault(l => l.Id.Equals(vendaItens.IdLanche));
                    if (lancheResult == null) return null;
                    venda.Total += lancheResult.Preco;
                }

                _context.Venda.Add(venda);
                _context.SaveChanges();

                var vendaResult = _context.Venda.SingleOrDefault(v => v.Codigo.Equals(venda.Codigo));

                List<VendaItensViewModel> vendaItensResult = new List<VendaItensViewModel>();
                foreach (var line in _context.VendaItens.Where(vi => vi.CodigoVenda.Equals(venda.Codigo)))
                {
                    var vendaItensViewModel = new VendaItensViewModel()
                    {
                        Id = line.Id,
                        IdLanche = line.IdLanche,
                        CodigoVenda = line.CodigoVenda,
                        Quantidade = line.Quantidade
                    };
                    vendaItensResult.Add(vendaItensViewModel);
                }

                return new VendaViewModel()
                {
                    Id = vendaResult.Id,
                    Codigo = vendaResult.Codigo,
                    IdUsuario = vendaResult.IdUsuario,
                    Lanches = vendaItensResult,
                    MomentoVenda = vendaResult.MomentoVenda,
                    Total = vendaResult.Total
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeletarVenda(int id)
        {
            var result = _context.Venda.SingleOrDefault(v => v.Id.Equals(id));
            if(result != null)
            {
                try
                {
                    foreach(var line in _context.VendaItens.Where(vi => vi.CodigoVenda.Equals(result.Codigo)))
                    {
                        _context.Remove(line);
                    }

                    _context.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public List<VendaViewModel> ListarVendas()
        {
            List<VendaViewModel> vendaVM = new List<VendaViewModel>();
            foreach (var venda in _context.Venda)
            {
                var vendaFor = new VendaViewModel()
                {
                    Id = venda.Id,
                    Codigo = venda.Codigo,
                    IdUsuario = venda.IdUsuario,
                    MomentoVenda = venda.MomentoVenda,
                    Total = venda.Total
                };
                vendaVM.Add(vendaFor);
            }

            foreach (var line in vendaVM)
            {
                List<VendaItensViewModel> vendaItemVM = new List<VendaItensViewModel>();
                foreach (var resultItens in _context.VendaItens.Where(vi => vi.CodigoVenda.Equals(line.Codigo)))
                {
                    var resultItensVM = new VendaItensViewModel()
                    {
                        Id = resultItens.Id,
                        CodigoVenda = resultItens.CodigoVenda,
                        IdLanche = resultItens.IdLanche,
                        Quantidade = resultItens.Quantidade
                    };
                    vendaItemVM.Add(resultItensVM);
                }
                line.Lanches = vendaItemVM;
            }
            return vendaVM;
        }

        public VendaViewModel ListarVendasPorId(int id)
        {
            var vendaResult = _context.Venda.SingleOrDefault(v => v.Id.Equals(id));
            if (vendaResult == null) return null;
            List<VendaItensViewModel> vendasVM = new List<VendaItensViewModel>();
            foreach (var line in _context.VendaItens.Where(vi => vi.CodigoVenda.Equals(vendaResult.Codigo)))
            {
                var vIVM = new VendaItensViewModel()
                {
                    Id = line.Id,
                    CodigoVenda = line.CodigoVenda,
                    IdLanche = line.IdLanche,
                    Quantidade = line.Quantidade
                };
                vendasVM.Add(vIVM);
            }

            return new VendaViewModel()
            {
                Id = vendaResult.Id,
                Codigo = vendaResult.Codigo,
                IdUsuario = vendaResult.IdUsuario,
                Lanches = vendasVM,
                MomentoVenda = vendaResult.MomentoVenda,
                Total = vendaResult.Total
            };
        }
    }
}
