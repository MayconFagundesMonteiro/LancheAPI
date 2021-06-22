using LancheAPI.Models.Base;

namespace LancheAPI.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sobrenome { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public int NumeroResidencia { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
