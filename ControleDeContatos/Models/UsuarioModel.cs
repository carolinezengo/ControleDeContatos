using ControleDeContatos.Enums;
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

    }
}
