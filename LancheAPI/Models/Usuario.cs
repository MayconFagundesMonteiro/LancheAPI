using LancheAPI.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Models
{
    public class Usuario : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public int NumeroResidencia { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public int TipoConta { get; set; }
    }
}
