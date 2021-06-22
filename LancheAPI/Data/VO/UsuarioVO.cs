namespace LancheAPI.Data.VO
{
    public class UsuarioVO
    {
        public int Id { get; set; }
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
