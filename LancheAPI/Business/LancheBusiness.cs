using LancheAPI.Business.Interfaces;
using LancheAPI.Models;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class LancheBusiness : ILancheBusiness
    {
        private readonly IGenericRepository<Lanche> _repository;

        public LancheBusiness(IGenericRepository<Lanche> repository)
        {
            _repository = repository;
        }

        public Lanche AtualizarLanche(Lanche lanche)
        {
           return _repository.Atualizar(lanche);
        }

        public Lanche CriarLanche(Lanche lanche)
        {
            return _repository.Criar(lanche);
        }

        public void DeletarLanche(int id)
        {
            _repository.Deletar(id);
        }

        public Lanche EncontrarPorId(int id)
        {
            return _repository.EncontrarPorId(id);
        }

        public List<Lanche> ListarTodosLanches()
        {
            return _repository.ListarTodos();
        }
    }
}
