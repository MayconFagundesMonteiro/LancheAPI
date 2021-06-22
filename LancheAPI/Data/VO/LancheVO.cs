using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Data.VO
{
    public class LancheVO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string UrlCapa { get; set; }
        public string UrlImagem { get; set; }
    }
}
