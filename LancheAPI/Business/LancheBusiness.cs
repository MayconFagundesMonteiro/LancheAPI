using LancheAPI.Business.Interfaces;
using LancheAPI.Data.Converter;
using LancheAPI.Data.VO;
using LancheAPI.Repositories.Interfaces;
using System.Collections.Generic;

namespace LancheAPI.Business
{
    public class LancheBusiness : ILancheBusiness
    {
        private readonly ILancheRepository _repository;
        private readonly LancheConverter _converter;

        public LancheBusiness(ILancheRepository repository)
        {
            _repository = repository;
            _converter = new LancheConverter();
        }

        public LancheVO AtualizarLanche(LancheVO lanche)
        {
            var lancheEntity = _converter.Parse(lanche);
            lancheEntity = _repository.Atualizar(lancheEntity);
            return _converter.Parse(lancheEntity);
        }

        public LancheVO CriarLanche(LancheVO lanche)
        {
            var lacheEntity = _converter.Parse(lanche);
            lacheEntity = _repository.Criar(lacheEntity);
            return _converter.Parse(lacheEntity);
        }

        public void DeletarLanche(int id)
        {
            _repository.Deletar(id);
        }

        public LancheVO EncontrarPorId(int id)
        {
            return _converter.Parse(_repository.EncontrarPorId(id));
        }

        public List<LancheVO> EncontrarPorNome(string Nome)
        {
            return _converter.Parse(_repository.EncontrarPorNome(Nome));
        }

        public List<LancheVO> LanchesPorCategoria(string categoria)
        {
            return _converter.Parse(_repository.LanchesPorCategoria(categoria));
        }

        public List<LancheVO> ListarTodosLanches()
        {
            return _converter.Parse(_repository.ListarTodos());
        }
    }
}
