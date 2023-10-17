using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do Contato")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o Login do Contato")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do Contato")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite Perfil")]
        public PerfilEnum Perfil { get; set; }
        [Required(ErrorMessage = "Digite o senha do Contato")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {

            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();  
        }

        public string GerarNovaSenha()
        {
            string novasenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novasenha.GerarHash();
            return novasenha;
        }
        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }
    }
}
