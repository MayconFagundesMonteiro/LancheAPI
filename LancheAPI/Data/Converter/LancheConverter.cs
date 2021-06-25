using LancheAPI.Data.Converter.Interface;
using LancheAPI.Data.VO;
using LancheAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace LancheAPI.Data.Converter
{
    public class LancheConverter : IParser<Lanche, LancheVO>, IParser<LancheVO, Lanche>
    {
        public LancheVO Parse(Lanche origin)
        {
            if (origin == null) return null;
            return new LancheVO()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                DescricaoCurta = origin.DescricaoCurta,
                UrlCapa = origin.UrlCapa,
                UrlImagem = origin.UrlImagem,
                Preco = origin.Preco,
                Categoria = origin.Categoria
            };
        }

        public Lanche Parse(LancheVO origin)
        {
            if (origin == null) return null;
            return new Lanche()
            {
                Id = origin.Id,
                Nome = origin.Nome,
                DescricaoCurta = origin.DescricaoCurta,
                UrlCapa = origin.UrlCapa,
                UrlImagem = origin.UrlImagem,
                Preco = origin.Preco,
                Categoria = origin.Categoria
            };
        }

        public List<Lanche> Parse(List<LancheVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<LancheVO> Parse(List<Lanche> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
