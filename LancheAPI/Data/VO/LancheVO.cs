using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Data.VO
{
    public class LancheVO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="O Campo {0} é obrigatorio")]
        public string Nome { get; set; }
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatorio")]
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public string UrlCapa { get; set; }
        public string UrlImagem { get; set; }
    }
}
