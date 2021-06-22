using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Data.VO
{
    public class UsuarioVO
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public int NumeroResidencia { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
