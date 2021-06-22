using System.ComponentModel.DataAnnotations;

namespace LancheAPI.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public class RegisterUsuarioViewModel
        {
            [Required(ErrorMessage = "O Campo {0} é obrigatório")]
            public string Nome { get; set; }
            public string Sobrenome { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
            public string Email { get; set; }
            public string Endereco { get; set; }
            public string Complemento { get; set; }
            public int NumeroResidencia { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public string Senha { get; set; }

            [Required]
            [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
            public string ConfirmarSenha { get; set; }
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            public string Role { get; set; }
        }

        public class LoginUsuarioViewModel
        {
            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
            public string Email { get; set; }

            [Required(ErrorMessage = "O campo {0} é obrigatório")]
            [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
            public string Senha { get; set; }
        }
    }
}
